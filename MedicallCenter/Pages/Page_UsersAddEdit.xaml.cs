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
            currentuser = user;

            if (currentuser.id != 0)
            {
                InputDate();
                btnEditUser.Visibility = Visibility.Visible;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new Page_Users());
        }


        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (GetData())
            {
                CurrentData.db.User.AddOrUpdate(currentuser);
                CurrentData.db.SaveChanges();
                MessageBox.Show("Запись успешно добавлена");
                Manager.frame.Navigate(new Page_Users());
            }

        }
        private void InputDate()
        {
            tbNameUser.Text = currentuser.name;
            tbLoginUser.Text = currentuser.login;
            tbPasswordUser.Text = currentuser.password;
            ComboPolUser.Text = currentuser.pol;
            tbAgeUser.Text = Convert.ToString(currentuser.age);
        }


        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (GetData())
            {
                CurrentData.db.User.AddOrUpdate(currentuser);
                CurrentData.db.SaveChanges();
                MessageBox.Show("Запись успешно отредактирована");
                Manager.frame.Navigate(new Page_Users());
            }
        }
        private bool GetData()
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                if (tbNameUser.Text == "")
                {
                    stringBuilder.Append("Поле имя: пусто\n");
                    tbNameUser.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                if (tbLoginUser.Text == "")
                {
                    stringBuilder.Append("Поле логин: пусто\n");
                    tbLoginUser.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                if (tbPasswordUser.Text == "")
                {
                    stringBuilder.Append("Поле пароль: пусто\n");
                    tbPasswordUser.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                if (ComboPolUser.Text == "")
                {
                    stringBuilder.Append("Поле пол: пусто\n");
                    ComboPolUser.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                if (tbAgeUser.Text == "")
                {
                    stringBuilder.Append("Поле возраст: пусто\n");
                    tbAgeUser.BorderBrush = new SolidColorBrush(Colors.Red);
                }

                MessageBox.Show(stringBuilder.ToString());
                currentuser.name = tbNameUser.Text;
                currentuser.login = tbLoginUser.Text;
                currentuser.password = tbPasswordUser.Text;
                currentuser.pol = ComboPolUser.Text;
                currentuser.age = Convert.ToInt16(tbAgeUser.Text);
                return true;


            }catch(Exception ex)
            {
                return false;
            }
        }

    }
}
