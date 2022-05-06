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
    public partial class addAppointmentDialogDoctor : Window
    {
        private RoomController RC;
        private DoctorController DC;
        private SpecializationController SC;
        private AppointmentController AC;
        private PatientController PC;
        private AppointmentNotificationController ANC;

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

        public Window edAP
        {
            set;get;
        }

        public addAppointmentDialogDoctor(int appoID,Window edAP)
        {
            RC = new RoomController();
            DC = new DoctorController();
            SC = new SpecializationController();
            AC = new AppointmentController();
            PC = new PatientController();
            ANC = new AppointmentNotificationController();
            tims = new BindingList<Time>();
            this.edAP = edAP;
            roomsDTO = RC.getAllRoomsDTO();
            doctorsDTO = DC.getAllDoctorsDTO();
            specsDTO = SC.getAllSpecializations();
            editAppId = appoID;
            InitializeComponent();
            this.x = x;
            dt = AC.getEditAppointmentDTOById(appoID).dt;
            this.dur = AC.getEditAppointmentDTOById(appoID).dur;
            this.DataContext = new
            {
                Rooms = roomsDTO,
                This = this,
                Docs = doctorsDTO,
                Specs = specsDTO,
                Tims1 = tims
            };
            
            foreach (RoomCrAppDTO r in roomsDTO)
            {
                if (r.id == AC.getEditAppointmentDTOById(appoID).roomID)
                {
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
                if (s.specialization.Equals(DC.getDoctorById(AC.getEditAppointmentDTOById(appoID).docID).specialization.specialization))
                {
                    Spec.SelectedItem = s;
                }
            }
            appointmentDate.SelectedDate = AC.getEditAppointmentDTOById(appoID).dt;

            name.Text = PC.getPatientsChooseDTOById(AC.getEditAppointmentDTOById(appoID).patientID).name;
            surname.Text = PC.getPatientsChooseDTOById(AC.getEditAppointmentDTOById(appoID).patientID).surname;
            id.Text = PC.getPatientsChooseDTOById(AC.getEditAppointmentDTOById(appoID).patientID).id.ToString();

            cancel.IsEnabled = false;
            Spec.IsEnabled = false;
            doctorsCB.IsEnabled = false;
            createAppointmentDoctor.Content = "Confirm";
        } 


        

        public addAppointmentDialogDoctor(PatientCrAppDTO pat,string desc,_1addAppointmentDialogDoctor prevW,int dur=30)
        {
            RC = new RoomController();
            DC = new DoctorController();
            SC = new SpecializationController();
            AC = new AppointmentController();
            ANC = new AppointmentNotificationController();
            tims = new BindingList<Time>();
            this.prevW = prevW;
            this.prevW.nextW = this;
            this.pat = pat;
            this.desc = desc;
            editAppId = -1;
            InitializeComponent();
            doctorsCB.SelectedIndex = 0;
            dt = DateTime.Today.AddDays(1);
            this.dur = dur;
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
            if (appointmentDate.SelectedDate.Value <= DateTime.Today)
            {
                var dial = new DialogWindow("Cannot appoint for before or today!", "Cancel", "Ok", null);
                dial.Show();
                return;
            }
            if (TimeselectDG.SelectedItem == null)
            {
                var dial = new DialogWindow("No selected time!", "Cancel", "Ok", null);
                dial.Show();
                return;
            }
            if (!AC.CheckCreateAppointment(appointmentDate.SelectedDate.Value, (Time)TimeselectDG.SelectedItem, this.dur, (RoomCrAppDTO)roomID.SelectedItem, (DoctorCrAppDTO)doctorsCB.SelectedItem, pat))
            {
                var dial = new DialogWindow("Someone created appointment before you, restart window!", "Cancel", "Ok", null);
                dial.Show();
                return;
            }
            if (createAppointmentDoctor.Content.Equals("Confirm"))
            {
                Time time = (Time)TimeselectDG.SelectedItem ;
                AC.ChangeAppointment(time, (DateTime)appointmentDate.SelectedDate, editAppId, (RoomCrAppDTO)roomID.SelectedItem,dur);
                edAP.Close();
                var dia = new doctorShowAppointment(editAppId);
                dia.Show();
                this.Close();
                return;
            }
            String title = "Zakazan pregled";
            DoctorCrAppDTO doctor = (DoctorCrAppDTO)doctorsCB.SelectedItem;
            Time t = (Time)TimeselectDG.SelectedItem;
            DateTime d = appointmentDate.SelectedDate.Value;
            String notContent = " Doktor: " + doctor.name + " " + doctor.surname + " Datum " + d.Day + "/" + d.Month + "/" + d.Year + " Vreme: " + t.time;
            ANC.CreateAppointmentNotification(new AppointmentNotification(title, notContent, DateTime.Today.AddDays(14), false, pat.id));
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
            if (tims != null)
            {
                tims.Clear();
            }
            DoctorCrAppDTO doc = (DoctorCrAppDTO)doctorsCB.SelectedItem;
            if (doc == null) return;
            foreach ( Time t in AC.GetDoctorTimesforDoctor(doc.id, (DateTime)appointmentDate.SelectedDate, dur, editAppId))
            {
                tims.Add(t);
            }
            if (editAppId != -1 && (DateTime)appointmentDate.SelectedDate == AC.getEditAppointmentDTOById(editAppId).dt )
            {
                foreach(Time t in tims)
                {
                    if (AC.getEditAppointmentDTOById(editAppId).time.hour == t.hour && AC.getEditAppointmentDTOById(editAppId).time.minute == t.minute)
                    {
                        TimeselectDG.SelectedItem = t;
                    }
                }
            }
        }

        private void TimeselectDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void slider1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (appointmentDate.SelectedDate != null)
            {
                if (tims != null)
                {
                    tims.Clear();
                }
                DoctorCrAppDTO doc = (DoctorCrAppDTO)doctorsCB.SelectedItem;

                foreach (Time t in AC.GetDoctorTimesforDoctor(doc == null ? 0 : doc.id, (DateTime)appointmentDate.SelectedDate, dur, editAppId))
                {
                    tims.Add(t);
                }
            }
        }

        private void doctorsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (appointmentDate.SelectedDate != null)
            {
                if (tims != null)
                {
                    tims.Clear();
                }
                DoctorCrAppDTO doc = (DoctorCrAppDTO)doctorsCB.SelectedItem;

                foreach (Time t in AC.GetDoctorTimesforDoctor(doc == null ? 0 : doc.id, (DateTime)appointmentDate.SelectedDate, dur, editAppId))
                {
                    tims.Add(t);
                }
            }
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
