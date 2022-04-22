﻿using CrudModel;
using SIMS_Projekat_Bolnica_Zdravo.Controllers;
using SIMS_Projekat_Bolnica_Zdravo.DoctorWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class _1addAppointmentDialogDoctor : Window
    {
        public addAppointmentDialogDoctor nextW
        {
            set;get;
        }

        private PatientController PC;

        public _1addAppointmentDialogDoctor()
        {
            InitializeComponent();
            PC = new PatientController();
            this.nextW = null;
            this.DataContext = PC.getAllPatientsChooseDTO();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (PatientsG.SelectedIndex == -1)
            {
                var dial = new DialogWindow("No row selected!", "Cancel", "Ok", null);
                dial.Show();
                return;
            }
            this.Hide();
            if (nextW == null)
            {
                var dia = new addAppointmentDialogDoctor((PatientCrAppDTO)PatientsG.SelectedItem, desc.Text, this);
                dia.Show();
            }
            else nextW.Show();
        }

        private void searchP_KeyUp(object sender, KeyEventArgs e)
        {
            IEnumerable<PatientCrAppDTO> filteredList;
            string name,id,surname;
            name = (searchPN.Text.Equals("name")) ? "" : searchPN.Text;
            surname = (searchPS.Text.Equals("surname")) ? "" : searchPS.Text;
            id = (searchPI.Text.Equals("id")) ? "" : searchPI.Text;
            filteredList = PC.getAllPatientsChooseDTO().Where(patient => patient.name.StartsWith(name));
            filteredList = filteredList.Where(patient => patient.surname.StartsWith(surname));
            filteredList = filteredList.Where(patient => patient.id.ToString().StartsWith(id));
            PatientsG.ItemsSource = filteredList;
        }

        private void searchPN_GotFocus(object sender, RoutedEventArgs e)
        {
            if (searchPN.Text.Equals("name"))
            searchPN.Text = "";
        }

        private void searchPN_LostFocus(object sender, RoutedEventArgs e)
        {
            if(searchPN.Text.Equals(""))
                searchPN.Text = "name";
        }

        private void searchPS_GotFocus(object sender, RoutedEventArgs e)
        {
            if (searchPS.Text.Equals("surname"))
                searchPS.Text = "";
        }

        private void searchPS_LostFocus(object sender, RoutedEventArgs e)
        {
            if (searchPS.Text.Equals(""))
                searchPS.Text = "surname";
        }

        private void searchPI_GotFocus(object sender, RoutedEventArgs e)
        {
            if (searchPI.Text.Equals("id"))
                searchPI.Text = "";
        }

        private void searchPI_LostFocus(object sender, RoutedEventArgs e)
        {
            if (searchPI.Text.Equals(""))
                searchPI.Text = "id";
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            var dia = new DialogWindow("Are you sure you wanna cancel?", "No", "Yes", this);
            dia.Show();
        }
    }
}
