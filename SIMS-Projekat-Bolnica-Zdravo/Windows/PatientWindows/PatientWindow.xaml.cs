﻿using ConsoleApp.serialization;
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
using SIMS_Projekat_Bolnica_Zdravo.Model;

namespace SIMS_Projekat_Bolnica_Zdravo.Windows
{
    public partial class PatientWindow : Window
    {
        private PatientController PC = new PatientController();
        private AppointmentNotificationController ANC = new AppointmentNotificationController();
        public static NavigationService NavigatePatient;
        MainHamburgerMenu MainHamburger;
        public static Boolean menuClosed = true;
        static public PatientCrAppDTO LoggedPatient
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
            LoggedPatient = PC.GetPatientDTOByID(patientID);
            PatientFrame.Content = new PatientAppointments(this);
            this.DataContext = LoggedPatient;
            ShowNotes();
        }
        private async void ShowNotes()
        {
            var notificationManager = new NotificationManager();
            await Task.Delay(1000);
            ObservableCollection<AppointmentNotification> notifications = ANC.GetAppointmentNotificationrByPatientID(LoggedPatient.id);
            foreach (AppointmentNotification an in notifications)
            {
                if (an.Viewed)
                {
                    continue;
                }
                NotificationWindow nw = new NotificationWindow(an.Title, an.Content);
                nw.Top = this.Top + 84;
                nw.Left = this.Left;
                nw.Topmost = true;
                nw.Show();
                an.Viewed = true;
                await Task.Delay(3000);
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

        public void SignOut()
        {
            LP.Show();
            LoggedPatient = null;
            this.Close();
        }

        private void hamburger_Menu_Click(object sender, RoutedEventArgs e)
        {
            if (menuClosed) 
            {
                MainHamburger = new MainHamburgerMenu(this);
                MainHamburger.Top = this.Top + 84;
                MainHamburger.Left = this.Left;
                MainHamburger.Activate();
                MainHamburger.Topmost = true;
                MainHamburger.Show();
                menuClosed = false;
                return;
            }
            menuClosed = true;
            MainHamburger.Close_menu();
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (MainHamburger != null)
            {
                menuClosed = true;
                MainHamburger.Close();
            }
        }
    }
}