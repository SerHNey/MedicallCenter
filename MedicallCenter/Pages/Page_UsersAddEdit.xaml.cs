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
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Page_UsersAddEdit : Page
    {
        User currentuser = new User();
        public Page_UsersAddEdit(User user)
        {
            InitializeComponent();
            SaveChang();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new Page_Users());
        }


        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (GetData())
            {
                CurrentData.db.User.Add(currentuser);
                SaveChang();
                MessageBox.Show("Запись успешно добавлена");
            }

        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {

                btnAddUser.IsEnabled = false;
                //currentuser = DataGridUser.SelectedItem as User;
                tbNameUser.Text = currentuser.name;
                tbLoginUser.Text = currentuser.login;
                tbPasswordUser.Text = currentuser.password;
                tbPolUser.Text = currentuser.pol;
                tbAgeUser.Text = Convert.ToString(currentuser.age);
                btnEditUser.Visibility = Visibility.Hidden;
                btnSaveUser.Visibility = Visibility.Visible;
        }

        private void btnSaveUser_Click(object sender, RoutedEventArgs e)
        {
            if (GetData())
            {
                CurrentData.db.User.AddOrUpdate(currentuser);
                SaveChang();
                MessageBox.Show("Запись успешно добавлена");
                btnEditUser.Visibility = Visibility.Visible;
                btnSaveUser.Visibility = Visibility.Hidden;
            }
        }
        private bool GetData()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (tbNameUser.Text.Length < 0)
                stringBuilder.Append("Поле имя: пусто\n");
            if (tbLoginUser.Text.Length < 0)
                stringBuilder.Append("Поле логин: пусто\n");
            if (tbPasswordUser.Text.Length < 0)
                stringBuilder.Append("Поле пароль: пусто\n");
            if (tbPolUser.Text.Length < 0)
                stringBuilder.Append("Поле пол: пусто\n");
            if (tbAgeUser.Text.Length < 0)
                stringBuilder.Append("Поле возраст: пусто\n");
            if (stringBuilder.ToString() == "")
            {

                currentuser.name = tbNameUser.Text;
                currentuser.login = tbLoginUser.Text;
                currentuser.password = tbPasswordUser.Text;
                currentuser.pol = tbPolUser.Text;
                currentuser.age =Convert.ToInt16(tbAgeUser.Text);
                return true;
            }
            return false;
        }
        private void SaveChang()
        {
            CurrentData.db.SaveChanges();
        }
    }
}
