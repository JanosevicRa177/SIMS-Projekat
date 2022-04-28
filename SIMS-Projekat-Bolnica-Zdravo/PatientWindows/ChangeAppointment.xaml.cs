using CrudModel;
using SIMS_Projekat_Bolnica_Zdravo.Controllers;
using SIMS_Projekat_Bolnica_Zdravo.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static SIMS_Projekat_Bolnica_Zdravo.Controllers.AppointmentController;
using static SIMS_Projekat_Bolnica_Zdravo.Controllers.RoomController;

namespace SIMS_Projekat_Bolnica_Zdravo.PatientWindows
{
    public partial class ChangeAppointment : Page
    {
        private AppointmentController AC;
        private DoctorController DC;
        private RoomController RC;
        public int hours
        {
            set;
            get;
        }
        public int minutes
        {
            set;
            get;
        }
        public static DateTime date
        {
            get;
            set;
        }
        private static BindingList<Time> doctorTerms
        {
            set;
            get;
        }

        public static DoctorCrAppDTO doctor;

        public static Boolean initialize = true;
        public static int appointmentID;
        public ChangeAppointment(int doctorID, DateTime date_t,int appointmentID1)
        {
            AC = new AppointmentController();
            DC = new DoctorController();
            RC = new RoomController();
            InitializeComponent();
            appointmentID = appointmentID1;
            doctor = DC.getDoctorDTO(doctorID);
            if (initialize)
            {
                initialize = false;
                doctorTerms = new BindingList<Time>();
                date = date_t;
                Date_TextChanged();
            }
            this.DataContext = new
            {
                This = this,
                DoctorTerms = doctorTerms
            };
        }
        public ChangeAppointment()
        {
            AC = new AppointmentController();
            DC = new DoctorController();
            RC = new RoomController();
            InitializeComponent();
            this.DataContext = new
            {
                This = this,
                DoctorTerms = doctorTerms
            };
        }

        private void Pick_Date(object sender, RoutedEventArgs e)
        {
            PatientWindow.NavigatePatient.Navigate(new DateChanger());
        }

        private void Cancel_Change_Appointment(object sender, RoutedEventArgs e)
        {
            date = DateTime.MinValue;
            initialize = true;
            PatientWindow.NavigatePatient.Navigate(new ShowAppointment());
        }

        private void Confirm_Change_appointment(object sender, RoutedEventArgs e)
        {
            Time t = (Time)TimeselectDG.SelectedItem;
            ShowAppointment.appointment.Date_T = date;
            ShowAppointment.appointment.Time = t.time;
            AC.ChangeAppointment(t, date, appointmentID);
            date = DateTime.MinValue;
            initialize = true;
            ShowAppointmentPatientDTO selectedAppointment = AC.getShowAppointmentPatientDTO(appointmentID);
            PatientWindow.NavigatePatient.Navigate(new ShowAppointment(selectedAppointment));
        }

        private void Date_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (doctorTerms != null) doctorTerms.Clear();
            foreach (Time t in DC.getDoctorTimes(doctor, date))
            {
                doctorTerms.Add(t);
            }
            TimeselectDG.SelectedIndex = 0;
            TimeselectDG.Items.Refresh();
        }
        private void Date_TextChanged()
        {
            if (doctorTerms != null) doctorTerms.Clear();
            foreach (Time t in DC.getDoctorTimes(doctor, date))
            {
                doctorTerms.Add(t);
            }
            TimeselectDG.SelectedIndex = 0;
            TimeselectDG.Items.Refresh();
        }
    }
}
