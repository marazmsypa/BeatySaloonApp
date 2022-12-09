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
        string generatedText = "";
        public RegPage()
        {
            string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lower = "zyxwvutsrqponmlkjihgfedcba";
            string digit = "1234567890";
            InitializeComponent();
            generatedText = "";
            Random rnd = new Random();
            for (int i = 0; i < rnd.Next(5, 10); i++)
            {
                char capchaChar = 'a';
                switch (rnd.Next(1, 4))
                {
                    case 1:
                        capchaChar = upper[rnd.Next(0, 26)];
                        break;
                    case 2:
                        capchaChar = lower[rnd.Next(0, 26)];
                        break;
                    case 3:
                        capchaChar = digit[rnd.Next(0, 10)];
                        break;
                }
                generatedText += capchaChar.ToString();
                TextBlock capchaSymbol = new TextBlock()
                {
                    Text = capchaChar.ToString(),
                    LayoutTransform = new RotateTransform(rnd.Next(-90, 91)),
                    FontSize = rnd.Next(18, 35),
                    Margin = new Thickness(rnd.Next(-5, -1)) 
                };
                capchaStack.Children.Add(capchaSymbol);
            }
            
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            UsersController obj = new UsersController();
            if (PasswordTextBox.Text != "" && LoginTextBox.Text != "")
            {
                if (ReturnPasswordTextBox.Text == PasswordTextBox.Text)
                {
                    if (generatedText == SymbolsTextBox.Text)
                    {
                        if (obj.CheckUser(LoginTextBox.Text).UserLogin == null)
                        {
                            Users user = new Users()
                            {
                                IdRole = 2,
                                UserName = NameTextBox.Text,
                                UserLastName = SurnameTextBox.Text,
                                UserOtherName = PatronymicTextBox.Text,
                                UserLogin = LoginTextBox.Text,
                                UserPassword = PasswordTextBox.Text
                            };


                            if (obj.AddUser(user))
                            {
                                MessageBox.Show("Вы успешно зарегистрировались!");
                                this.NavigationService.Navigate(new AuthPage());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пользователь с данным логином уже существует!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы неправильно ввели капчу!");
                    }

                }
                else
                {
                    MessageBox.Show("Пароли не совпадают!");
                }
            }
            else
            {
                MessageBox.Show("Вы не ввелилогин или пароль!");
            }
        }

        private void newCaptcha_Click(object sender, RoutedEventArgs e)
        {
            var list = capchaStack.Children.OfType<TextBlock>().ToList();
            foreach (UIElement cb in list)
                capchaStack.Children.Remove(cb);
            string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lower = "zyxwvutsrqponmlkjihgfedcba";
            string digit = "1234567890";
            InitializeComponent();
            generatedText = "";
            Random rnd = new Random();
            for (int i = 0; i < rnd.Next(5, 10); i++)
            {
                char capchaChar = 'a';
                switch (rnd.Next(1, 4))
                {
                    case 1:
                        capchaChar = upper[rnd.Next(0, 26)];
                        break;
                    case 2:
                        capchaChar = lower[rnd.Next(0, 26)];
                        break;
                    case 3:
                        capchaChar = digit[rnd.Next(0, 10)];
                        break;
                }
                generatedText += capchaChar.ToString();
                TextBlock capchaSymbol = new TextBlock()
                {
                    Text = capchaChar.ToString(),
                    LayoutTransform = new RotateTransform(rnd.Next(-45, 46)),
                    FontSize = rnd.Next(18, 35),
                    Margin = new Thickness(rnd.Next(-5,-1))
                };
                capchaStack.Children.Add(capchaSymbol);
            }
        }

        
    }
}
