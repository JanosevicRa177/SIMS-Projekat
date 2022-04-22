using CrudModel;
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
using System.Windows.Shapes;
using static SIMS_Projekat_Bolnica_Zdravo.Controllers.RoomController;

namespace SIMS_Projekat_Bolnica_Zdravo.Windows
{
    /// <summary>
    /// Interaction logic for addAppointmentDialogDoctor.xaml
    /// </summary>
    public partial class addAppointmentDialogDoctor : Window
    {
        private RoomController RC;
        private DoctorController DC;
        private SpecializationController SC;
        private AppointmentController AC;
        public PatientCrAppDTO pat
        {
            set;
            get;
        }

        public int dur
        {
            set;
            get;
        }


        /// <summary>
        /// TREBA OBRISATI!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// </summary>
        public Patient pati
        {
            set;
            get;
        }

        public DateTime dt
        {
            set;
            get;
        }

        public doctorShowAppointment x
        {
            set;
            get;
        }

        public string desc
        {
            set;
            get;
        }
        public Appointment appo
        {
            set;
            get;
        }

        public _1addAppointmentDialogDoctor prevW
        {
            set;
            get;
        }

        //sajdksadkasd
        //public addAppointmentDialogDoctor(Appointment appo, doctorShowAppointment x) {
        //    InitializeComponent();
        //    this.x = x;
        //    this.doc = DoctorWindow.loggedDoc;
        //    this.doc.changedDay(DateTime.Today);
        //    dt = appo.timeBegin;
        //    this.appo = appo;
        //    this.DataContext = new
        //    {
        //        Rooms = new RoomFileStorage(),
        //        This = this,
        //        Docs = new DoctorFileStorage(),
        //        Specs = new SpecializationFileStorage()
        //    };
        //    this.pati = appo.medicalRecord.patient;
        //    this.desc = appo.description;
        //    roomID.SelectedItem = appo.room;
        //    name.Text = appo.medicalRecord.patient.name;
        //    surname.Text = appo.medicalRecord.patient.surname;
        //    id.Text = appo.medicalRecord.patient.userID.ToString();
        //    Spec.SelectedItem = appo.doctor;
        //    Spec.IsEnabled = false;
        //    doctorsCB.SelectedItem = appo.doctor;
        //    doctorsCB.IsEnabled = false;
        //    this.dur = appo.duration;
        //    createAppointmentDoctor.Content = "Confirm";
        //}
        //oajsdolakjsdlaskd

        public ObservableCollection<Time> tims
        {
            set;
            get;
        }

        public addAppointmentDialogDoctor(PatientCrAppDTO pat,string desc,_1addAppointmentDialogDoctor prevW,int dur =30)
        {
            RC = new RoomController();
            DC = new DoctorController();
            SC = new SpecializationController();
            AC = new AppointmentController();
            this.dur = dur;
            this.prevW = prevW;
            this.prevW.nextW = this;
            this.pat = pat;
            this.desc = desc;
            InitializeComponent();
            doctorsCB.SelectedIndex = 0;
            dt = DateTime.Today.AddDays(1);
            tims = DC.getDoctorTimes((DoctorCrAppDTO)doctorsCB.SelectedItem, dt);
            this.DataContext = new
            {
                This = this,
                Rooms = RC.getAllRoomsDTO(),
                Docs = DC.getAllDoctorsDTO(),
                Specs = SC.getAllSpecializations()
            };

        }

        private void createAppointmentDoctor_Click(object sender, RoutedEventArgs e)
        {
            //if (createAppointmentDoctor.Content.Equals("Confirm"))
            //{
            //    doctorShowAppointment.appointment.setTime();
            //    doctorShowAppointment.appointment.timeBegin = (DateTime)appointmentDate.SelectedDate;
            //    doctorShowAppointment.appointment.setDate();
            //    doctorShowAppointment.appointment.room = (Room)roomID.SelectedItem;
            //    x.Close();
            //    x = new doctorShowAppointment(doctorShowAppointment.appointment);
            //    x.Show();
            //    this.Close();
            //    return;
            //}
            if(appointmentDate.SelectedDate.Value < DateTime.Today)
            {
                var dial = new DialogWindow("Cannot appoint for before", "Cancel", "Ok", null);
                dial.Show();
                return;
            }
            AC.CreateAppointment(appointmentDate.SelectedDate.Value, (Time)TimeselectDG.SelectedItem, this.dur, (RoomCrAppDTO)roomID.SelectedItem, (DoctorCrAppDTO)doctorsCB.SelectedItem, desc, pat);
            this.Close();
            prevW.Close();
        } 
        
        private void doctorsCB_Loaded(object sender, RoutedEventArgs e)
        {
            doctorsCB.SelectedIndex = 0 ;
        }

        private void Spec_Loaded(object sender, RoutedEventArgs e)
        {
            Spec.SelectedIndex = 0 ;
        }

        private void roomID_Loaded(object sender, RoutedEventArgs e)
        {
            roomID.SelectedIndex = 0;
        }

        private void appointmentDate_Loaded(object sender, RoutedEventArgs e)
        {
            appointmentDate.SelectedDate = dt;
        }

        private void cancel_Click (object sender, RoutedEventArgs e)
        {
            this.Hide();
            prevW.Show();
        }

        private void appointmentDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
                tims = DC.getDoctorTimes((DoctorCrAppDTO)doctorsCB.SelectedItem, (DateTime)appointmentDate.SelectedDate);
                TimeselectDG.Items.Refresh();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            prevW.Close();
        }
    }
}

public class StringValue
{
    public StringValue(string s)
    {
        _value = s;
    }
    public string Value { get { return _value; } set { _value = value; } }
    string _value;
}
