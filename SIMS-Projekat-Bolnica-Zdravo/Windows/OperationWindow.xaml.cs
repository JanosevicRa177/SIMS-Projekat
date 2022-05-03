﻿using CrudModel;
using SIMS_Projekat_Bolnica_Zdravo.Controllers;
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
using static SIMS_Projekat_Bolnica_Zdravo.Controllers.AppointmentController;
using static SIMS_Projekat_Bolnica_Zdravo.Controllers.RoomController;

namespace SIMS_Projekat_Bolnica_Zdravo.Windows
{
    /// <summary>
    /// Interaction logic for OperationWindow.xaml
    /// </summary>
    public partial class OperationWindow : Window
    {
        ObservableCollection<Time> timess
        {
            get;
            set;
        }
        ObservableCollection<ShowAppointmentDTO> temp
        {
            get;
            set;
        }
        DoctorController DC;
        RoomController RC;
        AppointmentController AC;
        PatientController PC;
        MedicalRecordFileStorage MRFS;
        private ObservableCollection<ShowAppointmentDTO> sadtt
        {
            get;
            set;
        }
        private ObservableCollection<PatientCrAppDTO> pcadd
        {
            get;
            set;
        }

        public OperationWindow()
        {
            timess = new ObservableCollection<Time>();
            temp = new ObservableCollection<ShowAppointmentDTO>();
       

            AC = new AppointmentController();
            RC = new RoomController();
            DC = new DoctorController();
            PC = new PatientController();
            MRFS = new MedicalRecordFileStorage();
            InitializeComponent();
            sadtt = AC.getAllOperationsAppointmentDTO();
            MessageBox.Show("Velicina: " + sadtt.Count.ToString());

            pcadd = PC.getAllPatientsChooseDTO();

            this.DataContext = new
            {
                sad = sadtt,
                time = timess,
                pcad = pcadd,
                This = this
            };
        
        }

        private void appointmentDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

            if (timess != null) timess.Clear();
            foreach (Time t in AC.getDoctorRoomOperationTimes((DoctorCrAppDTO)DC.getDocByIdDTO(Convert.ToInt32(passwordTextBox.Text.Split(' ')[0])), (DateTime)appointmentDate.SelectedDate,Convert.ToInt32(emailTextBox.Text.Split(' ')[0])))
            {
                timess.Add(t);
            }
            TimeGrid.SelectedIndex = 0;
            TimeGrid.Items.Refresh();
        }

        private void isLoaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Doctor> docs = new ObservableCollection<Doctor>();
            ObservableCollection<RoomCrAppDTO> rooms = new ObservableCollection<RoomCrAppDTO>();
            docs = DC.getAllDocs();
            rooms = RC.getAllRoomsDTO();
            foreach (Doctor d in docs)
            {
                passwordTextBox.Items.Add(d.userID + " " + d.name + " " + d.surname);
            }
            foreach (RoomCrAppDTO d in rooms)
            {
                emailTextBox.Items.Add(d.id + " " + d.name);
            }
            emailTextBox.SelectedIndex = 0;
            passwordTextBox.SelectedIndex = 0;
            PatientGrid.SelectedIndex = 0;
            appointmentDate.SelectedDate = DateTime.Now;
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<DoctorCrAppDTO> docList = DC.getAllDoctorsDTO();
            DoctorCrAppDTO doctorTemp = null;
            foreach (DoctorCrAppDTO d in docList)
            {
                if (d.id == Convert.ToInt32(passwordTextBox.Text.Split(' ')[0]))
                {
                    doctorTemp = d;
                }

            }
            ObservableCollection<RoomCrAppDTO> help = RC.getAllRoomsDTO();
            RoomCrAppDTO roomTemp = null;
            foreach (RoomCrAppDTO r in help)
            {
                if (r.id == Convert.ToInt32(emailTextBox.Text.Split(' ')[0]))
                {
                    roomTemp = r;
                }
            }
            PatientCrAppDTO sad = (PatientCrAppDTO)PatientGrid.SelectedItem;
            AC.CreateOperationAppointment((DateTime)appointmentDate.SelectedDate, (Time)TimeGrid.SelectedItem, 30, roomTemp, doctorTemp, "blabla", sad);
            Time t = (Time)TimeGrid.SelectedItem;
            if (t.time.Split(':')[1].ToString().Equals("30"))
            {
                sadtt.Add(new ShowAppointmentDTO(sad.name, sad.surname, sad.id.ToString(), emailTextBox.Text.Split(' ')[1], appointmentDate.SelectedDate.ToString().Split(' ')[0], t.time, "blabla", MRFS.getMedialRecordByPatientID(sad.id).medicalRecordID));
            }
            else
            {
                sadtt.Add(new ShowAppointmentDTO(sad.name, sad.surname, sad.id.ToString(), emailTextBox.Text.Split(' ')[1], appointmentDate.SelectedDate.ToString().Split(' ')[0], t.time, "blabla", MRFS.getMedialRecordByPatientID(sad.id).medicalRecordID));

            }
            MessageBox.Show("Uspesno ste dodali pregled");

            temp = AC.getAllAppointmentDTO();
            foreach (ShowAppointmentDTO app in temp)
            {

                if (app.Time.Split(' ')[0].Equals(t.time))
                {

                    AC.DeleteAppointment(app);
                }
            }

        }

        private void OnClick(object sender, RoutedEventArgs e)
        {

            if ((ShowAppointmentDTO)AppointmentGrid.SelectedItem != null)
            {
                ShowAppointmentDTO tmp = (ShowAppointmentDTO)AppointmentGrid.SelectedItem;
                AC.DeleteOperationAppointment(tmp);

                ShowAppointmentDTO d = (ShowAppointmentDTO)AppointmentGrid.SelectedItem;
                foreach (ShowAppointmentDTO dr in sadtt)
                {
                    if ((d.desc.Equals(dr.desc)) && (d.Time.Equals(dr.Time)) && (d.patientID == dr.patientID))
                    {
                        sadtt.Remove(dr);
                        break;
                    }
                }

            }

        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            int OldId = 0;

            foreach (ShowAppointmentDTO s in sadtt)
            {
                ShowAppointmentDTO tn = (ShowAppointmentDTO)AppointmentGrid.SelectedItem;
                Time x = (Time)TimeGrid.SelectedItem;
                PatientCrAppDTO p = (PatientCrAppDTO)PatientGrid.SelectedItem;

                if (tn.id == s.id && tn.Time.Equals(s.Time) && tn.Date.Equals(s.Date))
                {
                    OldId = Convert.ToInt32(tn.patientID);
                    s.patientName = tn.patientName;
                    s.patientSurname = tn.patientSurname;
                    s.Date = appointmentDate.SelectedDate.ToString().Split(' ')[0];
                    if (x.time.Split(':')[1].ToString().Equals("30"))
                    {
                        if (Convert.ToInt32(x.time.Split(':')[0]) < 10)
                        s.Time = "0" + (Convert.ToInt32(x.time.Split(':')[0]) + 1).ToString() + ":00" + " - " + x.time.Split(':')[0] + ":" + "00";
                        else
                            s.Time = (Convert.ToInt32(x.time.Split(':')[0]) + 1).ToString() + ":00" + " - " + x.time.Split(':')[0] + ":" + "00";

                    }
                    else
                    {
                       
                            s.Time = x.time + " - " + x.time.Split(':')[0] + ":" + "30";
                    }
                    s.roomName = emailTextBox.Text;
                    s.id = MRFS.getMedialRecordByPatientID(Convert.ToInt32(tn.patientID)).medicalRecordID;
                    AppointmentGrid.Items.Refresh();
                    MessageBox.Show(x.hour + ":" + x.minute);
                    Appointment a = AC.findAppById(OldId, s.Date);
                    AC.UpdateAppointment(a, new Appointment((DateTime)appointmentDate.SelectedDate, x.hour, x.minute, 30, RC.getRoomById(Convert.ToInt32(emailTextBox.Text.Split(' ')[0])), DC.getDocById(Convert.ToInt32(passwordTextBox.Text.Split(' ')[0])), "blabla", PC.GetPatientByID(Convert.ToInt32(tn.patientID)),a.appointmentID));

                }
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            var secPatApp = new SecretaryPacientAppointment();
            secPatApp.Show();
            this.Close();
        }
    }
}
