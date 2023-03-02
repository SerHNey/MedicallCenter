using MedicallCenter;
using MedicallCenter.Clasees;
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
    /// Логика взаимодействия для Servicee.xaml
    /// </summary>
    public partial class Page_Servicee : Page
    {
        public Page_Servicee()
        {
            InitializeComponent();
            DataGridService.ItemsSource = EntitiesMedical.GetEntities().Service.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new Page_Home(CurrentData.worker));
        }

        private void bntDeleteService_Click(object sender, RoutedEventArgs e)
        {
            var serviceForDelete = DataGridService.SelectedItems.Cast<Service>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {serviceForDelete} записи", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    EntitiesMedical.GetEntities().Service.RemoveRange(serviceForDelete);
                    EntitiesMedical.GetEntities().SaveChanges();
                    DataGridService.ItemsSource = EntitiesMedical.GetEntities().Service.ToList();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
            }
        }
    }
}
