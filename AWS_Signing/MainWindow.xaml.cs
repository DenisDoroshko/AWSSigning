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

namespace AWSSigning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tokenBox.Focus();
        }

        private void signButton_Click(object sender, RoutedEventArgs e)
        {
            var token = tokenBox.Text;
            var result = SignInManager.SignIn(token);
            if (result.Result)
            {
                MessageBox.Show("Signed!");
            }
            else
            {
                MessageBox.Show($"Something wrong. {result.ErrorMessage}");
            }

            tokenBox.Text = "";
        }
    }
}
