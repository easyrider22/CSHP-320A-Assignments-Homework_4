using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace Homework4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>    

    public partial class MainWindow : Window
    {

        

        public List<ZipCode> zipCode = new List<ZipCode>();
        public MainWindow()
        {
            InitializeComponent();
        }

        public class ZipCode
        {
            public string USzip { get; set; }
            public string CANzip { get; set; }
            
        } // end of class ZipCode  


        void zipValidateFail()
        {
            uxSubmitButton.IsEnabled = false;   
        }
        
        private void uxZipTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            Regex zipUS = new Regex(@"^\d{5}(?:[-\s]\d{4})?$");
            Regex zipCAN = new Regex(@"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$");
            
            string zipCode = uxZipTextBox.Text;
            for(int x=0; x <= uxZipTextBox.MaxLength; x++)
            {
            

                if (zipUS.IsMatch(zipCode)) {
                    uxSubmitButton.IsEnabled = true;
                    break;
                }

            else if (zipCAN.IsMatch(zipCode)) {
                    uxSubmitButton.IsEnabled = true;
                    break;
                }

            else if (zipCode.Length == uxZipTextBox.MaxLength) { 
                    MessageBox.Show("Failed to Validate Zip Code: " + uxZipTextBox.Text);
                    uxZipTextBox.Text = null;
                    break;
                }

                else
                {
                    zipValidateFail();                    
                }
                
            }            

        }

        private void uxSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Valid Zip Code: " + uxZipTextBox.Text);
            uxZipTextBox.Text = null;
        }
    }
}
