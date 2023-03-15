using MedicallCenter;
using MedicallCenter.Clasees;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Page_Authorization : Page
    {
        CaptchaWindow captchaWindow;
        private bool isFailedToSignIn;
        public Page_Authorization()
        {
            InitializeComponent();
            captchaWindow = new CaptchaWindow();
        }

        List<Worker> workers = new List<Worker>();

        private void cbShowPassword_Click(object sender, RoutedEventArgs e)
        {
            if (cbShowPassword.IsChecked == true)
            {
                tboxPassword.Text = pboxPassword.Password;

                pboxPassword.Visibility = Visibility.Hidden;
                tboxPassword.Visibility = Visibility.Visible;
            }
            else
            {
                pboxPassword.Visibility = Visibility.Visible;
                tboxPassword.Visibility = Visibility.Hidden;
            }
            
        }

        private void AddToHistory(Worker worker)
        {

            HistoryHot historyHot = new HistoryHot();
            historyHot.login = worker.login;
            historyHot.name = worker.name;
            historyHot.role = worker.Type1.id;
            historyHot.data = DateTime.Now;
            historyHot.block = "Нет";
            CurrentData.db.HistoryHot.Add(historyHot);
            CurrentData.db.SaveChanges();
        }


        private void bLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text;
            string password = pboxPassword.Password;
            bool isAuth = false;
            workers = CurrentData.db.Worker.ToList();
            foreach(Worker worker in workers)
            {
                if (worker.login == login && worker.password == password)
                {
                        CurrentData.worker = worker;
                        Manager.StartTimer();
                        Manager.frame.Navigate(new Page_Home(worker));
                        isAuth= true;
                    AddToHistory(worker);
                        break;
                }
            }
            if (!isAuth)
            {
                MessageBox.Show("Логин или пароль неверен");
                if (captchaWindow.IsPassedCaptcha)
                {
                    SignInButtonBlock();
                }
                else if (isFailedToSignIn)
                {
                    captchaWindow.Show();
                }
                isFailedToSignIn = true;
            }


        }
        public async void SignInButtonBlock()
        {
            bLogin.IsEnabled = false;
            await Task.Run(() => Thread.Sleep(10000));
            bLogin.IsEnabled = true;
            captchaWindow.IsPassedCaptcha = false;
        }

        private void bVod_Click(object sender, RoutedEventArgs e)
        {
            workers = CurrentData.db.Worker.ToList();
            Worker worker = workers[0];
            CurrentData.worker = worker;
            CurrentData.worker.name = "Неизвестный";
            Manager.StartTimer();
            Manager.frame.Navigate(new Page_Home(worker));

        }
    }
}
