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
        }
        private void ShowNotes()
        {
            var notificationManager = new NotificationManager();
            ObservableCollection<AppointmentNotification> notifications = ANC.GetAppointmentNotificationrByPatientID(loggedPatient.id);
            foreach (AppointmentNotification an in notifications)
            {
                if (an.viewed)
                {
                    continue;
                }
                notificationManager.Show(an.title, an.content);
                an.viewed = true;
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

        private void signout_Click(object sender, RoutedEventArgs e)
        {
            LP.Show();
            loggedPatient = null;
            this.Close();
        }
    }
}
