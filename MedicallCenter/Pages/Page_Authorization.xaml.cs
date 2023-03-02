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

namespace MedicalCenter.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Page_Authorization : Page
    {
        public Page_Authorization()
        {
            InitializeComponent();
        }

        private void cbShowPassword_Click(object sender, RoutedEventArgs e)
        {
            if (cbShowPassword.IsChecked == true)
            {
                tboxPassword.Text = pboxPassword.Password;

                pboxPassword.Visibility = Visibility.Hidden;
                tboxPassword.Visibility = Visibility.Visible;
            }
            else
            {
                pboxPassword.Visibility = Visibility.Visible;
                tboxPassword.Visibility = Visibility.Hidden;
            }
            
        }
    }
}
