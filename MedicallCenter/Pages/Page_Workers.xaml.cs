using MedicallCenter;
using MedicallCenter.Clasees;
using Newtonsoft.Json.Linq;
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
using System.Xml.Linq;

namespace MedicalCenter.Pages
{
    /// <summary>
    /// Логика взаимодействия для Workers.xaml
    /// </summary>
    public partial class Page_Workers : Page
    {
        private Worker curerentworker = new Worker();
        public Page_Workers()
        {
            InitializeComponent();

            DataGridWorkers.ItemsSource = CurrentData.db.Worker.ToList();
            ComboService.ItemsSource = CurrentData.db.Service.ToList();
            ComboDolgnost.ItemsSource = CurrentData.db.Type.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new Page_Home(CurrentData.worker));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var workersForDelete = DataGridWorkers.SelectedItems.Cast<Worker>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие записи {workersForDelete.Count()} элементов","Внимание",
                MessageBoxButton.YesNo,MessageBoxImage.Question)== MessageBoxResult.Yes)
            {
                try
                {
                    CurrentData.db.Worker.RemoveRange(workersForDelete);
                    CurrentData.db.SaveChanges();
                    DataGridWorkers.ItemsSource = CurrentData.db.Worker.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnAddWorker_Click(object sender, RoutedEventArgs e)
        {
            if (GetData())
            {
                CurrentData.db.Worker.Add(curerentworker);
                SaveChang();
                MessageBox.Show("Добавлено");
            }
        }

        private void btnEditWorker_Click(object sender, RoutedEventArgs e)
        {
            if(DataGridWorkers.SelectedItem != null)
            {
                curerentworker = DataGridWorkers.SelectedItem as Worker;
                tbNameWorker.Text = curerentworker.name;
                tbLoginWorker.Text = curerentworker.login;
                tbPasswordWorker.Text = curerentworker.password;
                tbIpWorker.Text = curerentworker.ip;
                tbLasneterWorker.Text = curerentworker.lastenter;
                JArray json = JArray.Parse(curerentworker.services);
                ComboDolgnost.Text = CurrentData.types.Where(x => x.role == curerentworker.Type1.role).FirstOrDefault().role;


                btnEditSecondWorker.Visibility = Visibility.Visible;
            }

        }

        private void btnEditSecondWorker_Click(object sender, RoutedEventArgs e)
        {
            if(GetData())
            {
                CurrentData.db.Worker.AddOrUpdate(curerentworker);
                SaveChang();

                MessageBox.Show("Запись успешно изменена");
                btnEditSecondWorker.Visibility = Visibility.Hidden;
                btnEditWorker.IsEnabled = IsEnabled.Equals(true);
            }
        }
        private void SaveChang()
        {
            CurrentData.db.SaveChanges();
            DataGridWorkers.ItemsSource = CurrentData.db.Worker.ToList();
        }
        private bool GetData()
        {
            StringBuilder stringBuilder= new StringBuilder();
            if(tbNameWorker.Text.Length < 0) 
                stringBuilder.Append("Поле имя: пусто\n");
            if (tbLoginWorker.Text.Length < 0)
                stringBuilder.Append("Поле логин: пусто\n");
            if (tbPasswordWorker.Text.Length < 0)
                stringBuilder.Append("Поле пароль: пусто\n");
            if (tbIpWorker.Text.Length < 0)
                stringBuilder.Append("Поле ip: пусто\n");
            if (tbLasneterWorker.Text.Length < 0)
                stringBuilder.Append("Поле время: пусто\n");
            if (ComboService.SelectedItem == null)
                stringBuilder.Append("Поле услуги: пусто\n");
            if (ComboDolgnost.SelectedItem == null)
                stringBuilder.Append("Поле должность: пусто\n");
            if(stringBuilder.ToString() == "")
            {
                curerentworker.name = tbNameWorker.Text;
                curerentworker.login = tbLoginWorker.Text;
                curerentworker.password = tbPasswordWorker.Text;
                curerentworker.ip = tbIpWorker.Text;
                curerentworker.lastenter = tbLasneterWorker.Text;
                curerentworker.services = ComboService.SelectedValue.ToString();
                curerentworker.type = CurrentData.db.Type.ToList().Where(x => x.role == ComboDolgnost.Text).FirstOrDefault().id;
                return true;
            }
            return false;
        }
    }
}
