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
    public partial class AddAppointment : Page
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
            set; get;
        }

        public static int selectedDoctor = -1;

        public static Boolean initialize = true;
        public AddAppointment()
        {
            AC = new AppointmentController();
            DC = new DoctorController();
            RC = new RoomController();
            if (initialize)
            {
                initialize = false;
                date = DateTime.Today.AddDays(1);
            }
            doctorTerms = new BindingList<Time>();
            this.DataContext = new
            {

                docs = AC.GetDoctorsPatient(),
                This = this,
                DoctorTerms = doctorTerms
            };
            InitializeComponent();
            doctorsCB.SelectedIndex = selectedDoctor;
        }

        private void doctor_Date_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (doctorTerms != null) doctorTerms.Clear();
            foreach (Time t in AC.GetDoctorTimes((DoctorCrAppDTO)doctorsCB.SelectedItem, date))
            {
                doctorTerms.Add(t);
            }
            TimeselectDG.SelectedIndex = 0;
            TimeselectDG.Items.Refresh();
        }
        private void Pick_Date(object sender, RoutedEventArgs e)
        {
            selectedDoctor = doctorsCB.SelectedIndex;
            PatientWindow.NavigatePatient.Navigate(new DatePicker());
        }

        private void Cancel_Add_Appointment(object sender, RoutedEventArgs e)
        {
            selectedDoctor = -1;
            initialize = true;
            PatientWindow.NavigatePatient.Navigate(new PatientAppointments());
        }

        private void Confirm_Add_appointment(object sender, RoutedEventArgs e)
        {
            if ((DoctorCrAppDTO)doctorsCB.SelectedItem == null)
            {
                MessageBox.Show("Niste izabrali Doktora");
                return;
            }
            initialize = true;
            foreach (RoomCrAppDTO r in RC.getAllRoomsDTO())
            {
                if (r.name.Equals("No Room"))
                {
                    AC.CreateAppointment(date, (Time)TimeselectDG.SelectedItem, 30, r, (DoctorCrAppDTO)doctorsCB.SelectedItem, desc.Text, PatientWindow.loggedPatient);
                    selectedDoctor = -1;
                    PatientWindow.NavigatePatient.Navigate(new PatientAppointments());
                }
            }
        }
    }
}
