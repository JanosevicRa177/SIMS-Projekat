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
    /// Interaction logic for addAppointmentDialogDoctor.xaml
    /// </summary>
    public partial class addAppointmentDialogDoctor : Window
    {
        public Patient pat
        {
            set;
            get;
        }

        public DateTime dt
        {
            set;
            get;
        }
        public int dur
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
        public addAppointmentDialogDoctor(Appointment appo, doctorShowAppointment x) {
            InitializeComponent();
            this.x = x;
            dt = appo.timeBegin;
            this.appo = appo;
            this.DataContext = new
            {
                Rooms = new RoomFileStorage(),
                This1 = this,
                Docs = new DoctorFileStorage(),
                Specs = new SpecializationFileStorage()
            };
            this.pat = appo.medicalRecord.patient;
            this.desc = appo.description;
            roomID.SelectedItem = appo.room;
            name.Text = appo.medicalRecord.patient.name;
            surname.Text = appo.medicalRecord.patient.surname;
            id.Text = appo.medicalRecord.patient.userID.ToString();
            Spec.SelectedItem = appo.doctor;
            Spec.IsEnabled = false;
            doctorsCB.SelectedItem = appo.doctor;
            doctorsCB.IsEnabled = false;
            this.dur = appo.duration;
            houraddAppointmentDialogDoctor.Text = appo.time[0].ToString() + appo.time[1].ToString();
            minuteaddAppointmentDialogDoctor.Text = appo.time[3].ToString() + "0";
            createAppointmentDoctor.Content = "Confirm";
        }

        public addAppointmentDialogDoctor(Patient pat,string desc)
        {
            dt = DateTime.Today;
            this.pat = pat;
            this.desc = desc;
            InitializeComponent();
            this.DataContext = new
            {
                This = this,
                Rooms = new RoomFileStorage(),
                Docs = new DoctorFileStorage(),
                Specs = new SpecializationFileStorage()
            };

        }

        private void createAppointmentDoctor_Click(object sender, RoutedEventArgs e)
        {
            if (createAppointmentDoctor.Content.Equals("Confirm"))
            {
                doctorShowAppointment.appointment.setTime();
                doctorShowAppointment.appointment.timeBegin = (DateTime)appointmentDate.SelectedDate;
                doctorShowAppointment.appointment.setDate();
                x.Close();
                x = new doctorShowAppointment(doctorShowAppointment.appointment);
                x.Show();
                this.Close();
                return;
            }
            if(appointmentDate.SelectedDate.Value < DateTime.Today)
            {
                MessageBox.Show("Cannot appoint for before");
                return;
            }
            Appointment a = new Appointment(appointmentDate.SelectedDate.Value, int.Parse(houraddAppointmentDialogDoctor.Text), int.Parse(minuteaddAppointmentDialogDoctor.Text), int.Parse(duration.Text), (Room)roomID.SelectedItem, (Doctor)doctorsCB.SelectedItem,desc,pat);
            AppointmentFileStorage.appointmentList.Add(a);
            Doctor d = (Doctor)doctorsCB.SelectedItem;
            d.AddAppointment(a);
            pat.medicalRecord.AddAppointment(a);
            this.Close();
        }

        private void doctorsCB_Loaded(object sender, RoutedEventArgs e)
        {
            doctorsCB.SelectedItem = DoctorWindow.loggedDoc;
        }

        private void Spec_Loaded(object sender, RoutedEventArgs e)
        {
            Spec.SelectedItem = SpecializationFileStorage.specializationList[0] ;
        }

        private void roomID_Loaded(object sender, RoutedEventArgs e)
        {
            roomID.SelectedItem = RoomFileStorage.roomList[0];
        }

        private void appointmentDate_Loaded(object sender, RoutedEventArgs e)
        {
            appointmentDate.SelectedDate = dt;
        }
    }
}
