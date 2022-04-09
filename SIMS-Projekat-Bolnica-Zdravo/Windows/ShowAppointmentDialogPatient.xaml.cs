using CrudModel;
using System;
using System.Collections.Generic;
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
    public partial class ShowAppointmentDialogPatient : Window
    {
        static Appointment appointment;
        public ShowAppointmentDialogPatient(Appointment appointment1)
        {
            appointment = appointment1;
            this.DataContext = new
            {
                patient = new PatientWindow(),
                appointment = appointment
            };
            InitializeComponent();
        }
        public ShowAppointmentDialogPatient()
        {
            this.DataContext = new
            {
                patient = new PatientWindow(),
                appointment = appointment
            };
            InitializeComponent();
        }

        private void Show_Notes(object sender, RoutedEventArgs e)
        {
            PatientNotes pn = new PatientNotes();
            pn.Show();
            this.Close();
        }

        private void Show_Home(object sender, RoutedEventArgs e)
        {
            PatientWindow pt = new PatientWindow();
            pt.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Cancel_Appointment(object sender, RoutedEventArgs e)
        {
            AppointmentFileStorage.appointmentList.Remove(appointment);
            PatientWindow.loggedPatient.medicalRecord.appointment.Remove(appointment);
            appointment.doctor.appointment.Remove(appointment);
            PatientWindow pt = new PatientWindow();
            pt.Show();
            this.Close();
        }
        private void Change_Date(object sender, RoutedEventArgs e)
        {
            ChangeAppointmentDialogPatient pt = new ChangeAppointmentDialogPatient(appointment);
            pt.Show();
            this.Close();
        }
    }
}
