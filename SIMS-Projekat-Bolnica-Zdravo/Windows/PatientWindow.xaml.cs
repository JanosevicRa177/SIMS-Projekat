using CrudModel;
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
        static public Patient loggedPatient
        {
            get;
            set;
        }
        public PatientWindow()
        {
            InitializeComponent();
            this.DataContext = loggedPatient;
            if (loggedPatient == null) 
            {
                loggedPatient = PatientFileStorage.GetPatientByID(5);
                loggedPatient.AddNote(new Note("Beleska1", "Neki kontent 1"));
                loggedPatient.AddNote(new Note("Beleska2", "Neki kontent 2"));
                loggedPatient.AddNote(new Note("Beleska3", "Neki kontent 3"));
                loggedPatient.AddNote(new Note("Beleska4", "Neki kontent 4"));
            }
           
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
