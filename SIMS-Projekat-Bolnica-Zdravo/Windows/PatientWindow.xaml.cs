﻿using ConsoleApp.serialization;
using CrudModel;
using SIMS_Projekat_Bolnica_Zdravo.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace SIMS_Projekat_Bolnica_Zdravo.Windows
{
    public partial class PatientWindow : Window
    {
        PatientController PC = new PatientController();
        static public int loggedPatient
        {
            get;
            set;
        }
        public PatientWindow()
        {
            InitializeComponent();
            loggedPatient = 5;
            this.DataContext = loggedPatient;
        }

        private void Show_Notes(object sender, RoutedEventArgs e)
        {
            PatientNotes pn = new PatientNotes();
            pn.Show();
            this.Close();
        }

        private void Appointments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddAppointment(object sender, RoutedEventArgs e)
        {
            AddAppointmentDialogPatient Add = new AddAppointmentDialogPatient();
            Add.Show();
            this.Close();
        }

        private void Show_Appointment(object sender, RoutedEventArgs e)
        {
            ShowAppointmentDialogPatient Show = new ShowAppointmentDialogPatient((Appointment)Appointments.SelectedItem);
            Show.Show();
            this.Close();
        }

        private void signout_Click(object sender, RoutedEventArgs e)
        {
            var dia = new MainWindow();
            dia.Show();
            this.Close();
        }
    }
}
