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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BeatySaloonApp.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        ServicesController obj = new ServicesController();
        
        public ServicePage()
        {
            InitializeComponent();
            ServicesListView.ItemsSource = obj.GetServices(Properties.Settings.Default.selectedCategory);
            switch (Properties.Settings.Default.selectedCategory)
            {
                case 1:
                    servicePage.Title = "Женский зал";
                    break;
                case 2:
                    servicePage.Title = "Мужской зал";
                    break;
                case 3:
                    servicePage.Title = "Уход за ногтями";
                    break;
                case 4:
                    servicePage.Title = "Уход за лицом и телом";
                    break;
                case 5:
                    servicePage.Title = "Перманентный макияж";
                    break;
                case 6:
                    servicePage.Title = "Ресницы какие-то";
                    break;
            }
        }

        private void ServicesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Properties.Settings.Default.activeUser == String.Empty)
            {
                MessageBox.Show("Войдите в аккаунт для записи!");
            }
            else
            {
                ThicknessAnimation blockArive = new ThicknessAnimation();
                blockArive.Duration = TimeSpan.FromSeconds(0.3);
                blockArive.From = recordingData.Margin;
                blockArive.To = new Thickness(0);
                recordingData.BeginAnimation(Rectangle.MarginProperty, blockArive);
            }
            
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            ThicknessAnimation blockLeave = new ThicknessAnimation();
            blockLeave.Duration = TimeSpan.FromSeconds(0.3);
            blockLeave.From = recordingData.Margin;
            blockLeave.To = new Thickness(3000, 0, 0, 0);
            recordingData.BeginAnimation(Rectangle.MarginProperty, blockLeave);
        }
        DateTime selectedDate;
        private void calendarPicker_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedDate = calendarPicker.SelectedDate.Value;
            dateTextBox.Text = selectedDate.ToShortDateString();
            
        }
        RecordsController objRecords = new RecordsController();
        UsersController objUsers = new UsersController(); 
       
        private void RecordButton_Click(object sender, RoutedEventArgs e)
        {
            List<Services> services = obj.GetServices(Properties.Settings.Default.selectedCategory);
            if (dateTextBox.Text == "")
            {
                MessageBox.Show("Вы не выбрали дату!");
            }
            else
            {
                if (objRecords.GetRecord(selectedDate.ToShortDateString(), TimeTextBox.Text).recordDate == dateTextBox.Text || objRecords.GetRecord(selectedDate.ToShortDateString(), TimeTextBox.Text).recordDate == TimeTextBox.Text)
                {
                    MessageBox.Show("Запись на это время уже существует");
                }
                else
                {
                    List<Records> listRecords = objRecords.GetAllRecords();
                    Records record = new Records()
                    {
                        idRecord = (listRecords.Count) + 1,
                        recordDate = selectedDate.ToShortDateString(),
                        recordTime = TimeTextBox.Text,
                        clientName = objUsers.CheckUser(Properties.Settings.Default.activeUser).UserName,
                        clientSurname = objUsers.CheckUser(Properties.Settings.Default.activeUser).UserLastName,
                        serviceName = services[ServicesListView.SelectedIndex].title

                    };
                    objRecords.AddRecord(record);
                    
                        MessageBox.Show("Запись успешно добавлена");
                    
                }
            }
            
        }
    }
}
