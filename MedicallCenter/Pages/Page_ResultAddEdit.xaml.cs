using MedicallCenter;
using MedicallCenter.Clasees;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для Result.xaml
    /// </summary>
    public partial class Page_ResultAddEdit : Page
    {
        private Result currentresult = new Result();
        public Page_ResultAddEdit(Result currentresult2)
        {
            InitializeComponent();
            currentresult = currentresult2;
            ComboUser112.ItemsSource = CurrentData.db.User.ToList();
            ComboWorker.ItemsSource= CurrentData.db.Worker.ToList();
            ComboService.ItemsSource= CurrentData.db.Service.ToList();
            //InputDate();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new Page_Result(CurrentData.worker));
        }

       
        private void InputDate()
        {
            ComboUser112.Text = CurrentData.results.Where(x => x.User.name == currentresult.User.name).FirstOrDefault().User.name;
            ComboWorker.Text = CurrentData.results.Where(x => x.Worker.name == currentresult.Worker.name).FirstOrDefault().Worker.name;
            ComboService.Text = CurrentData.results.Where(x => x.Service.service1 == currentresult.Service.service1).FirstOrDefault().Service.service1;
            tbResultResult.Text = currentresult.result1;
            tbDateResult.Text = currentresult.date;
        }


        private void btnEditResult_Click(object sender, RoutedEventArgs e)
        {
            InputDate();
               // btnEditSecodnResult.Visibility = Visibility.Visible;
        }

        private void btnEditSecodnResult_Click(object sender, RoutedEventArgs e)
        {
            if (GetData())
            {
                CurrentData.db.Result.AddOrUpdate(currentresult);
                SaveChang();
                MessageBox.Show("Запись успешно добавлена");
                btnEditResult.Visibility = Visibility.Visible;
                btnEditSecodnResult.Visibility = Visibility.Hidden;
            }
        }

        private bool GetData()
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (stringBuilder.ToString() == "")
            {
                currentresult.id_user = CurrentData.users.FirstOrDefault(x => x.name == ComboUser112.Text).id;
                currentresult.id_lab = CurrentData.workers.FirstOrDefault(x => x.name == ComboWorker.Text).id;
                currentresult.id_service = CurrentData.services.FirstOrDefault(x => x.service1 == ComboService.Text).id;
                currentresult.result1 = tbResultResult.Text;
                currentresult.date = tbDateResult.Text;
                return true;
            }
            return false;
        }
        private void SaveChang()
        {
            CurrentData.db.SaveChanges();
        }

        private void bntAddResult_Click(object sender, RoutedEventArgs e)
        {
            if (GetData()) 
            {
                CurrentData.db.Result.Add(currentresult);
                SaveChang();
                MessageBox.Show("Запись успешно добавлена");
                Manager.frame.Navigate(new Page_Result(CurrentData.worker));
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (currentresult.id != 0)
            {
                InputDate();
            }
        }
    }
}
