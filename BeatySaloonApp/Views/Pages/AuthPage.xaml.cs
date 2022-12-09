using BeatySaloonApp.Controllers;
using BeatySaloonApp.Models;
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

namespace BeatySaloonApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        UsersController users = new UsersController();
        public AuthPage()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text == "" || PasswordPasswordBox.Password == "")
            {
                MessageBox.Show("Вы не ввели логин или пароль!");
            }
            else
            {
                if (users.GetUser(LoginTextBox.Text, PasswordPasswordBox.Password).UserLogin == null)
                {
                    MessageBox.Show("Такого пользователя нет!");
                }
                else
                {
                    Users activeUser = users.GetUser(LoginTextBox.Text, PasswordPasswordBox.Password);
                    Properties.Settings.Default.activeUser = activeUser.UserLogin;
                    Properties.Settings.Default.Save();
                    this.NavigationService.Navigate(new MainPage());
                }
            }
            
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegPage());
        }
    }
}
