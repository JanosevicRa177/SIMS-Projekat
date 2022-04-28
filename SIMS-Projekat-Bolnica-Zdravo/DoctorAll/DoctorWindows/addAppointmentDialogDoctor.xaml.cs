using CrudModel;
using SIMS_Projekat_Bolnica_Zdravo.Controllers;
using SIMS_Projekat_Bolnica_Zdravo.DoctorWindows;
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
        private PatientController PC;

        public int editAppId
        {
            set;
            get;
        }
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

        public DateTime dt
        {
            set;
            get;
        }

        public string desc
        {
            set;
            get;
        }

        public _1addAppointmentDialogDoctor prevW
        {
            set;
            get;
        }

        public doctorShowAppointment x
        {
            set;
            get;
        }

        private BindingList<Time> tims
        {
            set; get;
        }
        //doctorShowAppointment x
        private ObservableCollection<RoomCrAppDTO> roomsDTO
        {
            set;
            get;
        }
        private ObservableCollection<DoctorCrAppDTO> doctorsDTO
        {
            set;
            get;
        }

        private ObservableCollection<Specialization> specsDTO
        {
            set;
            get;
        }


        public addAppointmentDialogDoctor(int appoID)
        {
            RC = new RoomController();
            DC = new DoctorController();
            SC = new SpecializationController();
            AC = new AppointmentController();
            PC = new PatientController();
            tims = new BindingList<Time>();
            roomsDTO = RC.getAllRoomsDTO();
            doctorsDTO = DC.getAllDoctorsDTO();
            specsDTO = SC.getAllSpecializations();
            editAppId = appoID;
            InitializeComponent();
            this.x = x;
            //this.doc.changedDay(DateTime.Today);
            dt = AC.getEditAppointmentDTOById(appoID).dt;
            this.DataContext = new
            {
                Rooms = roomsDTO,
                This = this,
                Docs = doctorsDTO,
                Specs = specsDTO
            };
            //this.desc = appo.description;
            foreach (RoomCrAppDTO r in roomsDTO)
            {
                if (r.id == AC.getEditAppointmentDTOById(appoID).roomID)
                {
                    Console.WriteLine(r.id + "xdxd");
                    roomID.SelectedItem = r;
                }
            }
            foreach (DoctorCrAppDTO d in doctorsDTO)
            {
                if (d.id == AC.getEditAppointmentDTOById(appoID).docID)
                {
                    doctorsCB.SelectedItem = d;
                }
            }
            foreach (Specialization s in specsDTO)
            {
                MessageBox.Show(s.specialization);
                MessageBox.Show(DC.getDoctorById(AC.getEditAppointmentDTOById(appoID).docID).specialization.specialization);
                if (s.specialization.Equals(DC.getDoctorById(AC.getEditAppointmentDTOById(appoID).docID).specialization))
                {
                    doctorsCB.SelectedItem = s;
                }
            }
            name.Text = PC.getPatientsChooseDTOById(AC.getEditAppointmentDTOById(appoID).patientID).name;
            surname.Text = PC.getPatientsChooseDTOById(AC.getEditAppointmentDTOById(appoID).patientID).surname;
            id.Text = PC.getPatientsChooseDTOById(AC.getEditAppointmentDTOById(appoID).patientID).id.ToString();
            //Spec.SelectedItem = appo.doctor;
            cancel.IsEnabled = false;
            Spec.IsEnabled = false;
            doctorsCB.IsEnabled = false;
            this.dur = AC.getEditAppointmentDTOById(appoID).docID;
            createAppointmentDoctor.Content = "Confirm";
        } 


        

        public addAppointmentDialogDoctor(PatientCrAppDTO pat,string desc,_1addAppointmentDialogDoctor prevW,int dur=30)
        {
            RC = new RoomController();
            DC = new DoctorController();
            SC = new SpecializationController();
            AC = new AppointmentController();
            tims = new BindingList<Time>();
            this.dur = dur;
            this.prevW = prevW;
            this.prevW.nextW = this;
            this.pat = pat;
            this.desc = desc;
            editAppId = -1;
            InitializeComponent();
            doctorsCB.SelectedIndex = 0;
            dt = DateTime.Today.AddDays(1);
            this.DataContext = new
            {
                This = this,
                Rooms = RC.getAllRoomsDTO(),
                Docs = DC.getAllDoctorsDTO(),
                Specs = SC.getAllSpecializations(),
                Tims1 = tims
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
            if (appointmentDate.SelectedDate.Value < DateTime.Today)
            {
                var dial = new DialogWindow("Cannot appoint for before or today!", "Cancel", "Ok", null);
                dial.Show();
                return;
            }
            else if(TimeselectDG.SelectedItem == null)
            {
                var dial = new DialogWindow("No selected time!", "Cancel", "Ok", null);
                dial.Show();
                return;
            }
            AC.CreateAppointment(appointmentDate.SelectedDate.Value, (Time)TimeselectDG.SelectedItem, this.dur, (RoomCrAppDTO)roomID.SelectedItem, (DoctorCrAppDTO)doctorsCB.SelectedItem, desc, pat);
            this.Close();
            prevW.Close();
        } 

        private void Spec_Loaded(object sender, RoutedEventArgs e)
        {
            if(editAppId == -1)
                Spec.SelectedIndex = 0 ;
        }

        private void roomID_Loaded(object sender, RoutedEventArgs e)
        {
            if (editAppId == -1)
                roomID.SelectedIndex = 0;
        }

        private void appointmentDate_Loaded(object sender, RoutedEventArgs e)
        {
            if (editAppId == -1)
                appointmentDate.SelectedDate = dt;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            prevW.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (prevW != null)
            prevW.Close();
        }

        private void appointmentDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tims != null) tims.Clear();
            foreach ( Time t in DC.getDoctorTimes((DoctorCrAppDTO)doctorsCB.SelectedItem, (DateTime)appointmentDate.SelectedDate))
            {
                tims.Add(t);
            }
        }

        private void TimeselectDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //slider1.Maximum = DC.calculateMaxDur(dur, (Time)TimeselectDG.SelectedItem, tims);
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
