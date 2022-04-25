using CrudModel;
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
    public partial class ShowAppointment : Page
    {
        private AppointmentController AC;
        public static ShowAppointmentPatientDTO appointment;
        public ShowAppointment(ShowAppointmentPatientDTO SAP)
        {
            appointment = SAP;
            ChangeAppointment.initialize = true;
            AC = new AppointmentController();
            InitializeComponent();
            this.DataContext = new {
                loggedPatient = PatientWindow.loggedPatient,
                appointment = SAP
            };
        }
        public ShowAppointment()
        {
            ChangeAppointment.initialize = true;
            AC = new AppointmentController();
            InitializeComponent();
            this.DataContext = new
            {
                loggedPatient = PatientWindow.loggedPatient,
                appointment = appointment
            };
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Cancel_Appointment(object sender, RoutedEventArgs e)
        {
            if (appointment.Date_T.Date < DateTime.Today)
            {
                MessageBox.Show("Ne Možete menjati odradjene preglede");
                return;
            }
            AC.removeAppointment(appointment.id);
            PatientWindow.NavigatePatient.Navigate(new PatientAppointments());
        }
        private void Change_Date(object sender, RoutedEventArgs e)
        {
            if (appointment.Date_T.Date < DateTime.Today)
            {
                MessageBox.Show("Ne Možete menjati odradjene preglede");
                return;
            }
            PatientWindow.NavigatePatient.Navigate(new ChangeAppointment(int.Parse(appointment.doctorID), appointment.Date_T, appointment.id));
        }
        private void Show_Home(object sender, RoutedEventArgs e)
        {
            PatientWindow.NavigatePatient.Navigate(new PatientAppointments());
        }
    }
}
