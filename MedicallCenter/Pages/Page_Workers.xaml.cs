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
    /// Логика взаимодействия для Workers.xaml
    /// </summary>
    public partial class Page_Workers : Page
    {
        public Page_Workers()
        {
            InitializeComponent();

            DataGridWorkers.ItemsSource = EntitiesMedical.GetEntities().Worker.ToList();
            
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
                    EntitiesMedical.GetEntities().Worker.RemoveRange(workersForDelete);
                    EntitiesMedical.GetEntities().SaveChanges();
                    DataGridWorkers.ItemsSource = EntitiesMedical.GetEntities().Worker.ToList();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
