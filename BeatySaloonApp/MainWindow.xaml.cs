using BeatySaloonApp.Views.Pages;
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

namespace BeatySaloonApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainPage());
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            var curentPage = e.Content;
            if (MainFrame.CanGoBack)
            {
                BackButton.Visibility = Visibility.Visible;
            }
            if (!MainFrame.CanGoBack)
            {
                BackButton.Visibility = Visibility.Collapsed;
            }
            if (curentPage is AuthPage || curentPage is RegPage)
            {
                AuthButton.Visibility = Visibility.Collapsed;
            }
            if (!(curentPage is AuthPage) && !(curentPage is RegPage))
            {
                AuthButton.Visibility = Visibility.Visible;
            }
            if (curentPage is MainPage && Properties.Settings.Default.activeUser != String.Empty)
            {
                AuthButton.Visibility = Visibility.Collapsed;
                BackButton.Visibility = Visibility.Collapsed;
            }
            if (Properties.Settings.Default.activeUser != String.Empty)
            {
                ExitButton.Visibility = Visibility.Visible;
            }
            if (Properties.Settings.Default.activeUser == String.Empty)
            {
                ExitButton.Visibility = Visibility.Collapsed;
            }
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AuthPage());
           

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.activeUser = String.Empty;
            Properties.Settings.Default.Save();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.activeUser = String.Empty;
            Properties.Settings.Default.Save();
            MainFrame.Navigate(new AuthPage());
        }
    }
}
