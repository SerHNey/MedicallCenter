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
        private Service currentServis = new Service();
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

        private void dntAddService_Click(object sender, RoutedEventArgs e)
        {
            GetInfoNewService();
            SaveChang();
            tbNameService.Text = null;
            tbPriceService.Text = null;
        }

        private void btnEditService_Click(object sender, RoutedEventArgs e)
        {
            bool save = false;
            bntDeleteService.Content = "Сохранить";
            if (DataGridService.SelectedItem != null)
            {
                OutInfoEditService();
            }
        }
        private void SaveChang()
        {
            EntitiesMedical.GetEntities().Service.Add(currentServis);
            EntitiesMedical.GetEntities().SaveChanges();
            DataGridService.ItemsSource = EntitiesMedical.GetEntities().Service.ToList();
        }
        // Заполяент объёект
        private void GetInfoNewService()
        {
            currentServis.service1 = tbNameService.Text;
            currentServis.price = Convert.ToDouble(tbPriceService.Text);
        }
        // Закидывает старые данные в поля для изменения, выбранного элемента
        private void OutInfoEditService()
        {
            currentServis = DataGridService.SelectedItem as Service;
            tbNameService.Text = currentServis.service1;
            tbPriceService.Text = Convert.ToString(currentServis.price);
        }
    }
}
