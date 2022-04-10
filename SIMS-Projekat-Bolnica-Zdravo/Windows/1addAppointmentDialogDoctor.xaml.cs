using CrudModel;
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
using System.Windows.Shapes;

namespace SIMS_Projekat_Bolnica_Zdravo.Windows
{
    /// <summary>
    /// Interaction logic for _1addAppointmentDialogDoctor.xaml
    /// </summary>
    public partial class _1addAppointmentDialogDoctor : Window
    {
        public _1addAppointmentDialogDoctor()
        {
            InitializeComponent();
            this.DataContext = new PatientFileStorage();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (PatientsG.SelectedIndex == -1)
            {
                MessageBox.Show("No row selected!");
                return;
            }
            this.Close();
            addAppointmentDialogDoctor dia = new addAppointmentDialogDoctor((Patient)PatientsG.SelectedItem, desc.Text);
            dia.ShowDialog();
        }

        private void searchPN_KeyUp(object sender, KeyEventArgs e)
        {
            var filtered = PatientFileStorage.patientList.Where(patient => patient.name.StartsWith(searchPN.Text));

            PatientsG.ItemsSource = filtered;
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
        private void searchPS_KeyUp(object sender, KeyEventArgs e)
        {
            var filtered = PatientFileStorage.patientList.Where(patient => patient.surname.StartsWith(searchPS.Text));

            PatientsG.ItemsSource = filtered;
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
        private void searchPI_KeyUp(object sender, KeyEventArgs e)
        {
            var filtered = PatientFileStorage.patientList.Where(patient => patient.userID.ToString().StartsWith(searchPI.Text));

            PatientsG.ItemsSource = filtered;
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


    }
}
