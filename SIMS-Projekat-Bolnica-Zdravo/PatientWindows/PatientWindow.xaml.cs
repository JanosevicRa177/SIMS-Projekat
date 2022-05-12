using ConsoleApp.serialization;
using CrudModel;
using Notification.Wpf;
using SIMS_Projekat_Bolnica_Zdravo.Controllers;
using SIMS_Projekat_Bolnica_Zdravo.PatientWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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

namespace SIMS_Projekat_Bolnica_Zdravo.Windows
{
    public partial class PatientWindow : Window
    {
        private PatientController PC = new PatientController();
        private MainHamburgerMenu MainHamburger;
        private AppointmentNotificationController ANC = new AppointmentNotificationController();
        public static NavigationService NavigatePatient;
        static public PatientCrAppDTO loggedPatient
        {
            get;
            set;
        }
        public static LoginPatient LP
        {
            set;
            get;
        }
        public PatientWindow(LoginPatient LP2, int patientID)
        {
            LP = LP2;
            InitializeComponent();
            NavigatePatient = PatientFrame.NavigationService;
            loggedPatient = PC.GetPatientDTOByID(patientID);
            PatientFrame.Content = new PatientAppointments();
            this.DataContext = loggedPatient;
            ShowNotes();
            MainHamburger = new MainHamburgerMenu(this);
        }
        private async void ShowNotes()
        {
            var notificationManager = new NotificationManager();
            await Task.Delay(1000);
            MainHamburger.Show();
            ObservableCollection<AppointmentNotification> notifications = ANC.GetAppointmentNotificationrByPatientID(loggedPatient.id);
            foreach (AppointmentNotification an in notifications)
            {
                if (an.viewed)
                {
                    continue;
                }
                NotificationWindow nw = new NotificationWindow(an.title, an.content);
                nw.Show();
                an.viewed = true;
                await Task.Delay(3500);
                nw.Close();
                ANC.UpdateAppointmentNotification(an);
            }
        }
        private void Show_Notes(object sender, RoutedEventArgs e)
        {
            AddAppointment.selectedDoctor = -1;
            AddAppointment.initialize = true;
            AddAppointment.empty = false;
            PatientFrame.NavigationService.Navigate(new PatientNotes());
        }
        private void Show_Home(object sender, RoutedEventArgs e)
        {
            AddAppointment.selectedDoctor = -1;
            AddAppointment.initialize = true;
            AddAppointment.empty = false;
            PatientFrame.NavigationService.Navigate(new PatientAppointments());
        }

        public void signout()
        {
            LP.Show();
            loggedPatient = null;
            this.Close();
        }

        private void hamburger_Menu_Click(object sender, RoutedEventArgs e)
        {
            MainHamburger.Activate();
            MainHamburger.Topmost = true;
            if (MainHamburger.closed) 
            {
                MainHamburger.Open_menu();
                return;
            }
            MainHamburger.Close_menu();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            MainHamburger.Close();
        }
    }
}
