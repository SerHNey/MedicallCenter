using MedicallCenter;
using MedicallCenter.Clasees;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
        private int pageNumber = 0;
        private int maxpage = 0;
        private int pageSize = 20;
        List<Service> services = new List<Service>();

        public Page_Servicee()
        {
            InitializeComponent();
            if (CurrentData.worker.Type1.id != 1)
            {
                btnDeleteService.Visibility = Visibility.Hidden;
                btnAddeditService.Visibility = Visibility.Hidden;
            }

            services = CurrentData.db.Service.ToList();
            maxpage = services.Count / pageSize;
            DisplayDataInGrid();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new Page_Home(CurrentData.worker));
        }
        private void DisplayDataInGrid()
        {
            var currentPageData = services.Skip(pageNumber * pageSize).Take(pageSize); // отображаем только данные для текущей страницы
            DataGridService.ItemsSource = currentPageData; // отображаем данные в DataGrid
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (pageNumber < maxpage)
            {
                pageNumber++; // переход на следующую страницу
                DisplayDataInGrid(); // отображение данных
            }
        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (pageNumber > 0)
            {
                pageNumber--; // переход на предыдущую страницу
                DisplayDataInGrid(); // отображение данных
            }
        }
        private void search_GotFocus(object sender, RoutedEventArgs e)
        {
            if (search.Text == "Поиск")
                search.Text = "";   
            else if (search.Text == "")
                search.Text = "Поиск";
        }
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (search.Text != "Поиск" && search.Text != "" && DataGridService != null)
            {
                string s_text = search.Text.ToLower();
                services = CurrentData.services;
                var s1 = services.Where(n => n.service1.ToLower().Contains(s_text)).ToList();
                var s2 = services.Where(n => n.kod_service.ToString().ToLower().Contains(s_text)).ToList();
                var s3 = services.Where(n => n.price.ToString().ToLower().Contains(s_text)).ToList();
                services = s1.Concat(s3.Concat(s2)).ToList();
                DisplayDataInGrid();


            }
            else
            {
                if (DataGridService != null)
                {
                    services = CurrentData.services;
                    DisplayDataInGrid();
                }

            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Service service = DataGridService.SelectedValue as Service;
            if (CurrentData.worker.Type1.id == 1)
                Manager.frame.Navigate(new Page_ServiceeAddEdit(service));
        }

        private void bntDeleteService_Click(object sender, RoutedEventArgs e)
        {
            var serviceForDelete = DataGridService.SelectedItems.Cast<Service>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {serviceForDelete} записи", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    CurrentData.db.Service.RemoveRange(serviceForDelete);
                    CurrentData.db.SaveChanges();
                    DisplayDataInGrid();
                    MessageBox.Show("Записи успешно удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private void btn_AddEditService_Click(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new Page_ServiceeAddEdit(currentServis));
        }
    }
}
