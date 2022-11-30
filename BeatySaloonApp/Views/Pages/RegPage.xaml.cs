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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
           
            if (ReturnPasswordTextBox.Text == PasswordTextBox.Text)
            {
                Users user = new Users() { 
                    IdRole = 2,
                    UserName = NameTextBox.Text,
                    UserLastName = SurnameTextBox.Text,
                    UserOtherName = PatronymicTextBox.Text,
                    UserLogin = LoginTextBox.Text,
                    UserPassword = PasswordTextBox.Text
                };
                UsersController obj = new UsersController();
                
                if (obj.AddUser(user))
                {
                    MessageBox.Show("Вы успешно зарегистрировались!");
                    this.NavigationService.Navigate(new AuthPage());
                }
               
            }
            else
            {
                MessageBox.Show("Пароли не совпадают!");
            }

        }
    }
}
