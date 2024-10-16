
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
using UI.ViewModel;

namespace UI.View
{
    public partial class DetailsForm : Window
    {
        DetailViewModel detailViewModel;
        public DetailsForm()

        {
            InitializeComponent();
            detailViewModel = new DetailViewModel();
            this.DataContext = detailViewModel;

        }

     
        //private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    TextBox textBox = sender as TextBox;
        //    if (textBox != null)
        //    {
        //        // Check if the current text is the placeholder text
        //        if (textBox.Text == "Enter your firstname" ||
        //            textBox.Text == "Enter your lastname" ||
        //            textBox.Text == "Enter company name" ||
        //            textBox.Text == "+(245) 451 45123" ||
        //            textBox.Text == "example@gmail.com" ||
        //            textBox.Text == "Address1" ||
        //            textBox.Text == "Enter your city")
        //        {
        //            textBox.Text = string.Empty;   // Clear the placeholder text
        //            textBox.Foreground = Brushes.Black;  // Change text color to black
        //        }
        //    }
        //}

        //private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    TextBox textBox = sender as TextBox;
        //    if (textBox != null)
        //    {
        //        // Restore placeholder text if the textbox is empty
        //        if (string.IsNullOrWhiteSpace(textBox.Text))
        //        {
        //            if (textBox.Name == "Firsttxt")
        //                textBox.Text = "Enter your firstname";
        //            else if (textBox.Name == "Lasttxt")
        //                textBox.Text = "Enter your lastname";
        //            else if (textBox.Name == "Companytxt")
        //                textBox.Text = "Enter company name";
        //            else if (textBox.Name == "Phonetxt")
        //                textBox.Text = "+(245) 451 45123";
        //            else if (textBox.Name == "Emailtxt")
        //                textBox.Text = "example@gmail.com";
        //            else if (textBox.Name == "Addresstxt")
        //                textBox.Text = "Address1";
        //            else if (textBox.Name == "Citytxt")
        //                textBox.Text = "Enter your city";

        //            textBox.Foreground = Brushes.Gray;  // Reset text color to gray
        //        }
        //    }
        //}
    }
}
