using CrudModel;
using SIMS_Projekat_Bolnica_Zdravo.Services;
using SIMS_Projekat_Bolnica_Zdravo.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SIMS_Projekat_Bolnica_Zdravo.Controllers.RoomController;
using SIMS_Projekat_Bolnica_Zdravo.CrudModel;

namespace SIMS_Projekat_Bolnica_Zdravo.Controllers
{
    class AppointmentController
    {
        private AppointmentService AS;
        private PatientController PC;
        private DoctorService DS;
        private RoomController RC;


        public AppointmentController()
        {
            DS = new DoctorService();
            PC = new PatientController();
            RC = new RoomController();
            AS = new AppointmentService();
        }

        public void RemoveAppointment(int appid)
        {
            AS.removeAppointment(appid);
        }
        public bool ChangeAppointment(Time t, DateTime dt, int appointmentID, RoomCrAppDTO rcdto = null, int dur = -1) 
        {
            return AS.ChangeAppointment(t, dt, appointmentID,rcdto,dur);
        }
        public int CreateAppointment(DateTime dt, Time t, int dur, RoomCrAppDTO rcadto, DoctorCrAppDTO dcadto, string desc, PatientCrAppDTO pcdto)
        {
            return AS.CreateAppointment(dt, t, dur, rcadto.id, dcadto.id, desc, pcdto.id);
        }

        public void ExecutedAppointment(StartAppointmentDTO sadto)
        {
            AS.ExecutedAppointment(sadto.condition, sadto.therapy, sadto.id, sadto.medicineList, sadto.desc);
        }

        public ObservableCollection<ShowAppointmentDTO> GetAllDoctorsAppointments(int docID)
        {
            ObservableCollection<ShowAppointmentDTO> adtolist = new ObservableCollection<ShowAppointmentDTO>();
            ObservableCollection<Appointment> apl = AS.getAllDoctorsAppointments(docID);
            foreach (Appointment a in apl)
            {
                adtolist.Add(new ShowAppointmentDTO(PC.GetPatientByID(a.patientID).name, PC.GetPatientByID(a.patientID).surname, PC.GetPatientByID(a.patientID).userID, RC.getRoomById(a.roomID).name, a.date, a.timeString, a.description, a.appointmentID));
            }
            return adtolist;
        }
        public ObservableCollection<DoctorCrAppDTO> GetDoctorsPatient()
        {
            ObservableCollection<Doctor> doctors = AS.getDoctorsPatient();
            ObservableCollection<DoctorCrAppDTO> docdto = new ObservableCollection<DoctorCrAppDTO>();
            foreach (Doctor d in doctors)
            {
                docdto.Add(new DoctorCrAppDTO(d.name, d.surname, d.userID));
            }
            return docdto;
        }
        public BindingList<Time> GetDoctorTimes(DoctorCrAppDTO doc, DateTime dt)
        {
            if (doc == null) return AS.getDoctorTimes(0, dt);
            return AS.getDoctorTimes(doc.id, dt);
        }
        public ObservableCollection<ShowAppointmentPatientDTO> getAllPatientsAppointments(int patientID)
        {
            ObservableCollection<ShowAppointmentPatientDTO> patientAppointmentsListDTO = new ObservableCollection<ShowAppointmentPatientDTO>();
            ObservableCollection<Appointment> appointmentsPatent = AS.getAllPatientsAppointments(patientID);
            foreach (Appointment a in appointmentsPatent)
            {
                Doctor d = DS.GetDoctorByID(a.doctorID);
                patientAppointmentsListDTO.Add(new ShowAppointmentPatientDTO(d.name, d.surname, d.userID.ToString(), RC.getRoomById(a.roomID).name, a.date, a.timeString, a.description, a.appointmentID, a.timeBegin));
            }
            return patientAppointmentsListDTO;
        }

        public EditAppointmentDTO getEditAppointmentDTOById(int appID)
        {
            Appointment a = AS.getAppointmentById(appID);
            return new EditAppointmentDTO(a.patientID, a.roomID, a.doctorID, a.duration,a.timeBegin,a.time);
        }

        public StartAppointmentDTO getStartAppointmentDTOById(int appID)
        {
            Appointment a = AS.getAppointmentById(appID);
            return new StartAppointmentDTO(a.description, a.therapy, a.condition, a.medicineList, a.appointmentID);
        }

        public ShowAppointmentDTO GetShowAppointmentDTO(int appoID)
        {
            Appointment a = AS.getAppointmentById(appoID);
            return new ShowAppointmentDTO(PC.GetPatientByID(a.patientID).name, PC.GetPatientByID(a.patientID).surname, PC.GetPatientByID(a.patientID).userID, RC.getRoomById(a.roomID).name, a.date,a.timeString,a.description,appoID);
        }
        public ShowAppointmentPatientDTO getShowAppointmentPatientDTO(int appoID)
        {
            Appointment a = AS.getAppointmentById(appoID);
            Doctor d = DS.GetDoctorByID(a.doctorID);
            return new ShowAppointmentPatientDTO(d.name, d.surname, d.userID.ToString(), RC.getRoomById(a.roomID).name, a.date, a.timeString, a.description, appoID, a.timeBegin);
        }

        public class StartAppointmentDTO
        {
            public string desc { set; get; }
            public string therapy { set; get; }
            public string condition { set; get; }
            public ObservableCollection<Medicine> medicineList { set; get; }
            public int id { set; get; }
            public StartAppointmentDTO(string desc,string therapy,string condition, ObservableCollection<Medicine> medList,int id)
            {
                this.desc = desc;
                this.therapy = therapy;
                this.condition = condition;
                this.medicineList = medList;
                this.id = id;
            }
        }
        public class EditAppointmentDTO
        {
            private RoomController RC;
            public int patientID { set; get; }
            public int roomID { set; get; }
            public int docID { set; get; }
            public int dur { set; get; }
            public string roomName { set; get; }

            public Time time { set; get; }
            public DateTime dt { set; get; }
            public EditAppointmentDTO(int pID, int rID, int dID, int dur,DateTime dt,Time t)
            {
                RC = new RoomController();
                patientID = pID;
                roomID = rID;
                docID = dID;
                this.dur = dur;
                this.dt = dt;
                this.time = t;
                this.roomName = RC.getRoomCrAppDTOById(roomID).name;
            }

        }
        
    }

    public class ShowAppointmentDTO
    {

        public string patientName { set; get; }
        public string patientSurname { set; get; }
        public int patientID { set; get; }
        public string roomName { set; get; }
        public string Date { set; get; }
        public string Time { set; get; }
        public string desc { set; get; }
        public int id { set; get; }

        public ShowAppointmentDTO(string pName, string pSurname, int pID, string rName, string date, string time, string desc, int id)
        {
            patientName = pName;
            patientSurname = pSurname;
            patientID = pID;
            roomName = rName;
            Date = date;
            Time = time;
            this.desc = desc;
            this.id = id;
        }

    }
    public class ShowAppointmentPatientDTO
    {
        public string doctorName { set; get; }
        public string doctorSurname { set; get; }
        public string doctorID { set; get; }
        public string roomName { set; get; }
        public string Date { set; get; }
        public DateTime Date_T { set; get; }
        public string Time { set; get; }
        public string desc { set; get; }
        public int id { set; get; }

        public ShowAppointmentPatientDTO(string dName, string dSurname, string dID, string rName, string date, string time, string desc, int id, DateTime Date_T)
        {
            doctorName = dName;
            doctorSurname = dSurname;
            doctorID = dID;
            roomName = rName;
            Date = date;
            this.Date_T = Date_T;
            Time = time;
            this.desc = desc;
            this.id = id;
        }
    }
}
