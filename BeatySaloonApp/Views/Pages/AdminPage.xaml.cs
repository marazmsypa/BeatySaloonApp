using Microsoft.Win32;
using System;
using System.Drawing;
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
using System.IO;
using BeatySaloonApp.Controllers;
using BeatySaloonApp.Models;

namespace BeatySaloonApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        ServiceCategoryesController obj = new ServiceCategoryesController();
        public AdminPage()
        {
            List<ServiceCategoryes> list = obj.GetCategories();
            string[] names = new string[list.Count];
            InitializeComponent();
            int i = 0;
            foreach (var item in list)
            {
                names[i] = item.CategoryTitle;
                    i++;
            }
            IdCategoryComboBox.ItemsSource = names;
        }

        
        string filePath;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        ServiceCategoryesController servObj = new ServiceCategoryesController();
        ServiceCategoryes services = new ServiceCategoryes();
        private void AddImageButton_Click(object sender, RoutedEventArgs e)
        {
           
            openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
            }
            services.CategoryImage = File.ReadAllBytes(filePath);
            Image img = new Image()
            {
                Source = new BitmapImage(new Uri(filePath)),
                Width = 200,
                Height = 200
                
            };
            var list = CategotyStackPanel.Children.OfType<Image>().ToList();
            foreach (UIElement cb in list)
                CategotyStackPanel.Children.Remove(cb);
            CategotyStackPanel.Children.Add(img); 
        }
        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (CategotyNameTextBox.Text != "")
            {
                services.CategoryTitle = CategotyNameTextBox.Text;
                if (servObj.AddCaterogy(services))
                {
                    MessageBox.Show("Категория успешно добавлена");
                }
            }
            else
            {
                MessageBox.Show("Введите название категории");
            }
        }
        ServicesController servicesObj = new ServicesController();
        private void AddServicesButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (NameServiceTextBox.Text != "" && NewCostServiceTextBox.Text != "")
            {
                Services service = new Services() {
                   id = 101,
                   title = NameServiceTextBox.Text,
                   cost = Convert.ToDouble(NewCostServiceTextBox.Text),
                   durationInSeconds = Convert.ToInt32(CostTextBox.Text),
                   discount = Convert.ToInt32(DiscountServiceTextBox.Text),
                   categoryId = IdCategoryComboBox.SelectedIndex + 1,
                };
                if (servicesObj.AddService(service))
                {
                    servicesObj.AddService(service);
                    MessageBox.Show("Все заебись");
                }
                   
                
                
            }
        }
    }
}
