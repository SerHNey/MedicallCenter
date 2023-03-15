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
    public partial class Page_ServiceeAddEdit : Page
    {
        private Service currentServis = new Service();
        public Page_ServiceeAddEdit(Service service)
        {
            InitializeComponent();
            currentServis = service;
            if (currentServis.id != 0)
            {
                OutInfoEditService();
                btnEditService.Visibility = Visibility.Visible;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new Page_Servicee());
        }

        private void dntAddService_Click(object sender, RoutedEventArgs e)
        {
            if (GetData())
            {
                CurrentData.db.Service.Add(currentServis);
                CurrentData.db.SaveChanges();
                Manager.frame.Navigate(new Page_Servicee());
                MessageBox.Show("Запись успешно добавлена");
            }
        }


        private bool GetData()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (tbNameService.Text != "")
                stringBuilder.Append("Заполните поле услуга: пусто\n");
            if (tbPriceService.Text != "")
                stringBuilder.Append("Заполните поле цена: пусто\n");
            {
                    currentServis.service1 = tbNameService.Text;
                    currentServis.kod_service = Convert.ToInt16(tbKodService.Text);
                    try
                    {
                        currentServis.price = Convert.ToDouble(tbPriceService.Text);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        currentServis.price = 0;
                        MessageBox.Show($"Цена содержить недопустимые символы или находится без значения");
                        return false;
                    }
                }
            MessageBox.Show(stringBuilder.ToString());
            return false;
        }
        // Закидывает старые данные в поля для изменения, выбранного элемента
        private void OutInfoEditService()
        {
            tbKodService.Text = Convert.ToString(currentServis.kod_service);
            tbNameService.Text = currentServis.service1;
            tbPriceService.Text = Convert.ToString(currentServis.price);
        }

        private void btnEditService_Click(object sender, RoutedEventArgs e)
        {
            if (GetData())
            {
                CurrentData.db.Service.AddOrUpdate(currentServis);
                CurrentData.db.SaveChanges();
                MessageBox.Show("Запись успешно изменена");
            }
        }

    }
}
