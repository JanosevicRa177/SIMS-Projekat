using CrudModel;
using Notification.Wpf;
using SIMS_Projekat_Bolnica_Zdravo.Controllers;
using SIMS_Projekat_Bolnica_Zdravo.Windows;
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
using static SIMS_Projekat_Bolnica_Zdravo.Controllers.AppointmentController;

namespace SIMS_Projekat_Bolnica_Zdravo.PatientWindows
{
    public partial class PatientAppointments : Page
    {
        private AppointmentController AC;
        private AppointmentNotificationController ANC;
        public static PatientWindow patientWindow;
        public ObservableCollection<ShowAppointmentPatientDTO> patientAppointmens;
        public PatientAppointments(PatientWindow patientWindow1)
        {
            patientWindow = patientWindow1;
            AC = new AppointmentController();
            ANC = new AppointmentNotificationController();
            patientAppointmens = AC.getAllPatientsAppointments(PatientWindow.LoggedPatient.id);
            ObservableCollection<ShowAppointmentPatientDTO> removeAppointmens = new ObservableCollection<ShowAppointmentPatientDTO>();
            foreach (var appoinment in patientAppointmens)
            {
                if (appoinment.Date < DateTime.Today)
                {
                    removeAppointmens.Add(appoinment);
                }
            }
            foreach (var appoinment in removeAppointmens)
            {
                patientAppointmens.Remove(appoinment);
            }
            this.DataContext = patientAppointmens;
            InitializeComponent();
        }
        public PatientAppointments()
        {
            AC = new AppointmentController();
            ANC = new AppointmentNotificationController();
            patientAppointmens = AC.getAllPatientsAppointments(PatientWindow.LoggedPatient.id);
            ObservableCollection<ShowAppointmentPatientDTO> removeAppointmens = new ObservableCollection<ShowAppointmentPatientDTO>();
            foreach (var appoinment in patientAppointmens)
            {
                if (appoinment.Date < DateTime.Today)
                {
                    removeAppointmens.Add(appoinment);
                }
            }
            foreach (var appoinment in removeAppointmens)
            {
                patientAppointmens.Remove(appoinment);
            }
            this.DataContext = patientAppointmens;
            InitializeComponent();
        }
        private void Show_Appointment(object sender, RoutedEventArgs e)
        {
            PatientWindow.NavigatePatient.Navigate(new ShowAppointment((ShowAppointmentPatientDTO)Appointments.SelectedItem, patientWindow));
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
