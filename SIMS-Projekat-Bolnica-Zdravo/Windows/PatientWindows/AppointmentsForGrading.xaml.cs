using SIMS_Projekat_Bolnica_Zdravo.Controllers;
using SIMS_Projekat_Bolnica_Zdravo.Windows;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace SIMS_Projekat_Bolnica_Zdravo.PatientWindows
{
    public partial class AppointmentsForGrading : Page
    {
        private AppointmentController AC;
        private static PatientWindow patientWindow;
        public AppointmentsForGrading(PatientWindow patientWindow1)
        {
            patientWindow = patientWindow1;
            AC = new AppointmentController();
            this.DataContext = AC.GetExecutedPatientsAppointments(PatientWindow.LoggedPatient.id);
            InitializeComponent();
        }
        public AppointmentsForGrading() 
        {
            AC = new AppointmentController();
            this.DataContext = AC.GetExecutedPatientsAppointments(PatientWindow.LoggedPatient.id);
            InitializeComponent();
        }

        private void Grade_Click(object sender, RoutedEventArgs e)
        {
            ShowAppointmentPatientDTO appointment = (ShowAppointmentPatientDTO)AppointmentsListGrid.SelectedItem;
            patientWindow.PatientFrame.NavigationService.Navigate(new GradingAppointment(patientWindow, appointment.id));
        }
    }
}
