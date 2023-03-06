using MedicallCenter.Pages.WIndows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MedicallCenter
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void add_locBtn_Click(object sender, RoutedEventArgs e)
        {
            var comboBox = (ComboBox)((Button)sender).Tag;
            addService addService = new addService(comboBox);
            addService.Show();
        }

        private void del_location_Click(object sender, RoutedEventArgs e)
        {
            var comboBox = (ComboBox)((Button)sender).Tag;
            var list = comboBox.ItemsSource as List<Service>;
            list.Remove(comboBox.SelectedItem as Service);
            comboBox.ItemsSource = list;
            comboBox.Items.Refresh();
        }
    }
}
