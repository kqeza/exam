using ex.Services;
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
using System.Windows.Shapes;

namespace ex.Views
{
    public partial class Login : Window
    {
        private DataServices _ds = new DataServices();
        public Login()
        {
            InitializeComponent();
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Password;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                txtError.Text = "Введите логин и пароль";
                txtError.Visibility = Visibility.Visible;
                return;
            }

            var user = _ds.Authenticate(login, password);
            if (user != null)
            {
                App.CurrentUser = user;
                new MainWindow().Show();
                Close();
            }
            else
            {
                txtError.Text = "Неверный логин или пароль";
                txtError.Visibility = Visibility.Visible;
            }
        }
    }
}
