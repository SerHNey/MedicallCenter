using MedicalCenter;
using MedicalCenter.Pages;
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
using MedicallCenter.Clasees;

namespace MedicallCenter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Manager.frame = MainFrame;
            Manager.frame.Navigate(new Page_Authorization());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentData.db = new EntitiesMedical();
            CurrentData.results = CurrentData.db.Result.ToList();
            CurrentData.users = CurrentData.db.User.ToList();
            CurrentData.services = CurrentData.db.Service.ToList();
            CurrentData.workers = CurrentData.db.Worker.ToList();
            CurrentData.types = CurrentData.db.Type.ToList();
            CurrentData.historyHots = CurrentData.db.HistoryHot.ToList();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Manager.KillTimer();
        }
    }
}
