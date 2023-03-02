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
    /// Логика взаимодействия для Result.xaml
    /// </summary>
    public partial class Page_Result : Page
    {
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
                    EntitiesMedical.GetEntities().SaveChanges();
                    DataGridResult.ItemsSource = EntitiesMedical.GetEntities().Result.ToList();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
