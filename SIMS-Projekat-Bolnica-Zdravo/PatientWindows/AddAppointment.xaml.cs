using CrudModel;
using Notification.Wpf;
using SIMS_Projekat_Bolnica_Zdravo.Controllers;
using SIMS_Projekat_Bolnica_Zdravo.CrudModel;
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
        private AppointmentNotificationController ANC;
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
        private static BindingList<TimePatient> doctorTerms
        {
            set; get;
        }

        public static int selectedDoctor = -1;

        public static Boolean initialize = true;
        public static Boolean empty;
        public AddAppointment()
        {
            AC = new AppointmentController();
            DC = new DoctorController();
            RC = new RoomController();
            ANC = new AppointmentNotificationController();
            if (initialize)
            {
                initialize = false;
                date = DateTime.Today.AddDays(1);
            }
            doctorTerms = new BindingList<TimePatient>();
            InitializeComponent();
            this.DataContext = new
            {

                docs = AC.GetDoctorsPatient(),
                This = this,
                DoctorTerms = doctorTerms
            };
            doctorsCB.SelectedIndex = selectedDoctor;
        }

        private void doctor_Date_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (doctorTerms != null) doctorTerms.Clear();
            foreach (TimePatient t in AC.GetDoctorTimes((DoctorCrAppDTO)doctorsCB.SelectedItem, date))
            {
                doctorTerms.Add(t);
            }
            if (doctorTerms.Count == 0)
            {
                empty = true;
                if ((bool)DoctorPriority.IsChecked)
                {
                    foreach (TimePatient tp in AC.GetDoctorTermsByDoctor((DoctorCrAppDTO)doctorsCB.SelectedItem, date))
                    {
                        doctorTerms.Add(tp);
                    }
                }
                else
                {
                    foreach (TimePatient tp in AC.GetDoctorTermsByDate(date))
                    {
                        doctorTerms.Add(tp);
                    }
                }
            }
            else
            {
                empty = false;
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
            empty = false;
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
                    TimePatient TimePat = (TimePatient)TimeselectDG.SelectedItem;
                    Time t = new Time(TimePat.hour,TimePat.minute, TimePat.ID);
                    AC.CreateAppointment(TimePat.date, t, 30, r, TimePat.doctor, desc.Text, PatientWindow.loggedPatient);
                    selectedDoctor = -1;
                    initialize = true;
                    empty = false;
                    var notificationManager = new NotificationManager();
                    String title = "Zakazan pregled";
                    String notContent = " Dotkor: " + TimePat.doctor.name + " " + TimePat.doctor.surname + " Datum " + TimePat.dateString + " Vreme: " + TimePat.time;
                    notificationManager.Show(title,notContent);
                    ANC.CreateAppointmentNotification(new AppointmentNotification(title, notContent, DateTime.Today.AddDays(14),false, TimePat.doctor.id));
                    PatientWindow.NavigatePatient.Navigate(new PatientAppointments());
                }
            }
        }

        private void RadioButton_Checked_Doctor(object sender, RoutedEventArgs e)
        {
            if (empty)
            {
                doctorTerms.Clear();
                foreach (TimePatient tp in AC.GetDoctorTermsByDoctor((DoctorCrAppDTO)doctorsCB.SelectedItem, date))
                {
                    doctorTerms.Add(tp);
                }
            }
        }

        private void RadioButton_Checked_Date(object sender, RoutedEventArgs e)
        {
            if (empty)
            {
                doctorTerms.Clear();
                foreach(TimePatient tp in AC.GetDoctorTermsByDate(date))
                {
                    doctorTerms.Add(tp);
                }
            }
        }
    }
}
