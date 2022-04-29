using ConsoleApp.serialization;
using CrudModel;
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
        PatientController PC = new PatientController();
        public static NavigationService NavigatePatient;
        static public PatientCrAppDTO loggedPatient
        {
            get;
            set;
        }
        public static Window MW
        {
            set;
            get;
        }
        public PatientWindow(MainWindow MW2)
        {
            MW = MW2;
            InitializeComponent();
            NavigatePatient = PatientFrame.NavigationService;
            loggedPatient = PC.GetPatientDTOByID(5);
            PatientFrame.Content = new PatientAppointments();
            this.DataContext = loggedPatient;
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
            MW.Show();
            this.Close();
        }
    }
}
