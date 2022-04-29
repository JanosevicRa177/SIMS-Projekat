﻿using CrudModel;
using SIMS_Projekat_Bolnica_Zdravo.Controllers;
using SIMS_Projekat_Bolnica_Zdravo.Windows;
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
using static SIMS_Projekat_Bolnica_Zdravo.Controllers.AppointmentController;

namespace SIMS_Projekat_Bolnica_Zdravo.PatientWindows
{
    public partial class PatientAppointments : Page
    {
        private AppointmentController AC;
        public PatientAppointments()
        {
            AC = new AppointmentController();
            InitializeComponent();
            this.DataContext = AC.getAllPatientsAppointments(PatientWindow.loggedPatient.id);
        }
        private void Show_Appointment(object sender, RoutedEventArgs e)
        {
            PatientWindow.NavigatePatient.Navigate(new ShowAppointment((ShowAppointmentPatientDTO)Appointments.SelectedItem));
        }
        private void Appointments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void AddAppointment(object sender, RoutedEventArgs e)
        {
            PatientWindow.NavigatePatient.Navigate(new AddAppointment());
        }
    }
}