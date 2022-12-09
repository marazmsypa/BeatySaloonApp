using BeatySaloonApp.Controllers;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        ServiceCategoryesController obj = new ServiceCategoryesController();
        public MainPage()
        {
            InitializeComponent();
            CategoriesListView.ItemsSource = obj.GetCategories();
        }
        
        private void CategoriesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            


                switch (CategoriesListView.SelectedIndex)
                {
                    case 0:
                        Properties.Settings.Default.selectedCategory = 1;
                        Properties.Settings.Default.Save();
                        this.NavigationService.Navigate(new ServicePage());
                        break;
                    case 1:
                        Properties.Settings.Default.selectedCategory = 2;
                        Properties.Settings.Default.Save();
                        this.NavigationService.Navigate(new ServicePage());
                        break;
                    case 2:
                        Properties.Settings.Default.selectedCategory = 3;
                        Properties.Settings.Default.Save();
                        this.NavigationService.Navigate(new ServicePage());
                        break;
                    case 3:
                        Properties.Settings.Default.selectedCategory = 4;
                        Properties.Settings.Default.Save();
                        this.NavigationService.Navigate(new ServicePage());
                        break;
                    case 4:
                        Properties.Settings.Default.selectedCategory = 5;
                        Properties.Settings.Default.Save();
                        this.NavigationService.Navigate(new ServicePage());
                        break;
                    case 5:
                        Properties.Settings.Default.selectedCategory = 6;
                        Properties.Settings.Default.Save();
                        this.NavigationService.Navigate(new ServicePage());
                        break;
                case 6:
                    Properties.Settings.Default.selectedCategory = 7;
                    Properties.Settings.Default.Save();
                    this.NavigationService.Navigate(new ServicePage());
                    break;
                case 7:
                    Properties.Settings.Default.selectedCategory = 8;
                    Properties.Settings.Default.Save();
                    this.NavigationService.Navigate(new ServicePage());
                    break;

            }
        }
    }
}
