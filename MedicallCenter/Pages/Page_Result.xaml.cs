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
    /// Логика взаимодействия для Result.xaml
    /// </summary>
    public partial class Page_Result : Page
    {
        private Result currentresult = new Result();

        public Page_Result()
        {
            InitializeComponent();
            DataGridResult.ItemsSource = EntitiesMedical.GetEntities().Result.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new Page_Home(CurrentData.worker));
        }

        private void btnDeleteResult_Click(object sender, RoutedEventArgs e)
        {
            var resultForDelete = DataGridResult.SelectedItems.Cast<Result>().ToList();
            if(MessageBox.Show($"Вы точно хотите удалить следующие {resultForDelete} записи","Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question)== MessageBoxResult.Yes)
            {
                try
                {
                    EntitiesMedical.GetEntities().Result.RemoveRange(resultForDelete);
                    SaveChang();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnEditResult_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridResult.SelectedItem != null)
                currentresult = DataGridResult.SelectedItem as Result;
            Manager.frame.Navigate(new Page_ResultAddEdit(currentresult));

        }

        private void SaveChang()
        {
            CurrentData.db.SaveChanges();
            DataGridResult.ItemsSource = CurrentData.db.Result.ToList();
        }

        private void bntAddResult_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridResult.SelectedItem != null)
                currentresult = new Result();
            Manager.frame.Navigate(new Page_ResultAddEdit(currentresult));
        }
    }
}
