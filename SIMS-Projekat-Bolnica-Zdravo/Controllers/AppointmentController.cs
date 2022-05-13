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
using System.Windows;
using static SIMS_Projekat_Bolnica_Zdravo.Controllers.RoomController;
using SIMS_Projekat_Bolnica_Zdravo.CrudModel;
using static SIMS_Projekat_Bolnica_Zdravo.Controllers.EditAppointmentDTO;

namespace SIMS_Projekat_Bolnica_Zdravo.Controllers
{
    public class AppointmentController
    {
        private AppointmentService AS;
        private PatientController PC;
        private DoctorService DS;
        private PatientService PS;
        private RoomController RC;
        private RoomService RS;
        private MedicineController MC;


        public AppointmentController()
        {
            DS = new DoctorService();
            PC = new PatientController();
            RC = new RoomController();
            PS = new PatientService();
            AS = new AppointmentService();
            RS = new RoomService();
            MC = new MedicineController();

        }

        public void RemoveAppointment(int appid)
        {
            AS.removeAppointment(appid);
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

        public bool CheckCreateAppointment(DateTime dt, Time t, int dur, RoomCrAppDTO rcadto, DoctorCrAppDTO dcadto, PatientCrAppDTO pcdto,int appointmentID = -1)
        {
            return AS.CheckCreateAppointment(dt, t, dur, rcadto.id, dcadto.id, pcdto.id, appointmentID);
        }
        public BindingList<TimePatient> GetDoctorTimes(DoctorCrAppDTO doc, DateTime dt, int duration, int appoID)
        {
            if (doc == null) return AS.GetDoctorTimes(0, dt, duration, appoID);
            return AS.GetDoctorTimes(doc.id, dt, duration, appoID);
        }
        public BindingList<TimePatient> GetDoctorTermsByDoctor(DoctorCrAppDTO doc, DateTime dt, int duration, int appoID)
        {
            return AS.GetDoctorTermsByDoctor(doc.id, dt, duration, appoID);
        }
        public BindingList<TimePatient> GetDoctorTermsByDate(DateTime dt, int duration, int appoID)
        {
            return AS.GetDoctorTermsByDate(dt, duration, appoID);
        }

        public BindingList<Time> GetDoctorTimesforDoctor(int docID, DateTime dt, int duration, int appoID,RoomCrAppDTO r = null)
        {
            int xd;
            if (r == null) xd = -1;
            else xd = r.id;
            return AS.GetDoctorTimesforDoctor(docID , dt, duration, appoID, xd);
        }
        
        public bool ChangeAppointment(Time t, DateTime dt, int appointmentID, RoomCrAppDTO rcdto = null, int dur = -1) 
        {
            return AS.ChangeAppointment(t, dt, appointmentID,rcdto,dur);
        }
        public void DeleteAppointment(ShowAppointmentDTO app)
        {
            AS.DeleteAppointment(app);
        }
        public ObservableCollection<Doctor> getAllDocs()
        {
            return AS.getAllDoctors();
        }
        public ObservableCollection<RoomCrAppDTO> getAllRoomsDTO()
        {
            ObservableCollection<RoomCrAppDTO> ocp = new ObservableCollection<RoomCrAppDTO>();
            ObservableCollection<Room> rooms = RS.getAllRooms();
            foreach (Room r in rooms)
            {
                ocp.Add(new RoomCrAppDTO(r.name, r.roomID));
            }
            return ocp;
        }

        public ObservableCollection<PatientCrAppDTO> getAllPatientsChooseDTO()
        {
            ObservableCollection<PatientCrAppDTO> ocp = new ObservableCollection<PatientCrAppDTO>();
            ObservableCollection<Patient> patients = PS.getAllPatients();
            foreach (Patient p in patients)
            {
                ocp.Add(new PatientCrAppDTO(p.name, p.surname, p.userID.ToString(), p.userID));
            }
            return ocp;
        }
        public void DeleteOperationAppointment(ShowAppointmentDTO app)
        {
            AS.DeleteOperationAppointment(app);
        }
        public ObservableCollection<ShowAppointmentDTO> getAllAppointmentDTO()
        {
            ObservableCollection<ShowAppointmentDTO> tmp = new ObservableCollection<ShowAppointmentDTO>();
            ObservableCollection<Appointment> list = AS.getAllAppointmentDTO();
            foreach (Appointment a in list)
            {
                if (a.operation != true)
                    tmp.Add(new ShowAppointmentDTO(PC.GetPatientByID(a.patientID).name, PC.GetPatientByID(a.patientID).surname, a.patientID, RC.getRoomById(a.roomID).name, a.date, a.timeString, a.description, a.appointmentID));

            }
            return tmp;
        }
        public int CreateAppointment(DateTime dt, Time t, int dur, RoomCrAppDTO rcadto, DoctorCrAppDTO dcadto, string desc, PatientCrAppDTO pcdto)
        {
            return AS.CreateAppointment(dt, t, dur, rcadto.id, dcadto.id, desc, pcdto.id);
        }
        public int CreateOperationAppointment(DateTime dt, Time t, int dur, RoomCrAppDTO rcadto, DoctorCrAppDTO dcadto, string desc, PatientCrAppDTO pcdto)
        {
            return AS.CreateOperationAppointment(dt, t, dur, rcadto.id, dcadto.id, desc, pcdto.id);
        }
        public bool CreateTemporaryAppointment(DateTime dt, Time t, int dur, RoomCrAppDTO rcadto, DoctorCrAppDTO dcadto, string desc,int id)
        {
            return AS.CreateTemporaryAppointment(dt, t, dur, rcadto.id, dcadto.id, desc, id);
        }

        public void ExecutedAppointment(StartAppointmentDTO sadto)
        {
            AS.ExecutedAppointment(sadto.condition, sadto.therapy, sadto.id, convertTMDTOtoTM(sadto.medicineList), sadto.desc);
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
        public BindingList<Time> getDoctorRoomTimes(DoctorCrAppDTO doc, DateTime dt, int id)
        {
            if (doc == null) return AS.getDoctorRoomTimes(0, dt, 0);
            return AS.getDoctorRoomTimes(doc.id, dt, id);
        }
        public ObservableCollection<ShowAppointmentDTO> getAllOperationsAppointmentDTO()
        {
            ObservableCollection<ShowAppointmentDTO> tmp = new ObservableCollection<ShowAppointmentDTO>();
            ObservableCollection<Appointment> list = AS.getAllAppointmentDTO();
            foreach (Appointment a in list)
            {
                if (a.operation == true)
                    tmp.Add(new ShowAppointmentDTO(PC.GetPatientByID(a.patientID).name, PC.GetPatientByID(a.patientID).surname, a.patientID, RC.getRoomById(a.roomID).name, a.date, a.timeString, a.description, a.medicalRecordID));

            }
            return tmp;
        }
        public BindingList<Time> getDoctorRoomOperationTimes(DoctorCrAppDTO doc, DateTime dt, int id)
        {
            if (doc == null) return AS.getDoctorRoomOperationTimes(0, dt, 0);
            return AS.getDoctorRoomOperationTimes(doc.id, dt, id);
        }
        public ShowAppointmentPatientDTO getShowAppointmentPatientDTO(int appoID)
        {
            Appointment a = AS.getAppointmentById(appoID);
            Doctor d = DS.GetDoctorByID(a.doctorID);
            return new ShowAppointmentPatientDTO(d.name, d.surname, d.userID.ToString(), RC.getRoomById(a.roomID).name, a.timeString, a.description, appoID, a.timeBegin, a.duration, a.isNotGraded);
        }
        public ObservableCollection<ShowAppointmentPatientDTO> getAllPatientsAppointments(int patientID)
        {
            ObservableCollection<ShowAppointmentPatientDTO> patientAppointmentsListDTO = new ObservableCollection<ShowAppointmentPatientDTO>();
            ObservableCollection<Appointment> appointmentsPatent = AS.getAllPatientsAppointments(patientID);
            foreach (Appointment a in appointmentsPatent)
            {
                Doctor d = DS.GetDoctorByID(a.doctorID);
                patientAppointmentsListDTO.Add(new ShowAppointmentPatientDTO(d.name, d.surname, d.userID.ToString(), RC.getRoomById(a.roomID).name, a.timeString, a.description, a.appointmentID, a.timeBegin, a.duration,a.isNotGraded));
            }
            return patientAppointmentsListDTO;
        }
        public ObservableCollection<ShowAppointmentPatientDTO> GetExecutedPatientsAppointments(int patientID)
        {
            ObservableCollection<ShowAppointmentPatientDTO> patientAppointmentsListDTO = new ObservableCollection<ShowAppointmentPatientDTO>();
            ObservableCollection<Appointment> appointmentsPatent = AS.GetExecutedPatientsAppointments(patientID);
            foreach (Appointment a in appointmentsPatent)
            {
                Doctor d = DS.GetDoctorByID(a.doctorID);
                patientAppointmentsListDTO.Add(new ShowAppointmentPatientDTO(d.name, d.surname, d.userID.ToString(), RC.getRoomById(a.roomID).name, a.timeString, a.description, a.appointmentID, a.timeBegin, a.duration, a.isNotGraded));
            }
            return patientAppointmentsListDTO;
        }
        public EditAppointmentDTO getEditAppointmentDTOById(int appID)
        {
            Appointment a = AS.getAppointmentById(appID);
            return new EditAppointmentDTO(a.patientID, a.roomID, a.doctorID, a.duration, a.timeBegin, a.time);
        }
        public void UpdateAppointment(Appointment a, Appointment app)
        {
            AS.UpdateAppointment(a, app);
        }
        public StartAppointmentDTO getStartAppointmentDTOById(int appID)
        {
            Appointment a = AS.getAppointmentById(appID);
            return new StartAppointmentDTO(a.description, a.therapy, a.condition, convertTMtoTMDTO(a.medicineList), a.appointmentID);
        }

        public ShowAppointmentDTO GetShowAppointmentDTO(int appoID)
        {
            Appointment a = AS.getAppointmentById(appoID);
            return new ShowAppointmentDTO(PC.GetPatientByID(a.patientID).name, PC.GetPatientByID(a.patientID).surname, PC.GetPatientByID(a.patientID).userID, RC.getRoomById(a.roomID).name, a.date,a.timeString,a.description,appoID);
        }
        public Appointment findAppById(int id, string date)
        {
            return AS.findAppById(id, date);
        }
        public ShowAppointmentPatientDTO getShowAppointmentDTO(int appoID)
        {
            Appointment a = AS.getAppointmentById(appoID);
            Doctor d = DS.GetDoctorByID(a.doctorID);
            return new ShowAppointmentPatientDTO(d.name, d.surname, d.userID.ToString(), RC.getRoomById(a.roomID).name, a.timeString, a.description, appoID, a.timeBegin, a.duration, a.isNotGraded);
        }
        
        public ObservableCollection<TakingMedicine> convertTMDTOtoTM(ObservableCollection<TakingMedicineDTO> octmdto)
        {
            ObservableCollection<TakingMedicine> octm = new ObservableCollection<TakingMedicine>();
            foreach (TakingMedicineDTO tmdto in octmdto)
            {
                octm.Add(new TakingMedicine(tmdto.medid, tmdto.amount, tmdto.freq));
            }
            return octm;
        }

        public ObservableCollection<TakingMedicineDTO> convertTMtoTMDTO(ObservableCollection<TakingMedicine> octm)
        {
            ObservableCollection<TakingMedicineDTO> octmdto = new ObservableCollection<TakingMedicineDTO>();
            foreach (TakingMedicine tm in octm)
            {
                octmdto.Add(new TakingMedicineDTO(tm.medid, tm.frequency, tm.amount));
            }
            return octmdto;
        }
    }
    public class EditAppointmentDTO
    {
        private RoomController RC;
        private AppointmentService AS;
        private PatientController PC;
        public int patientID { set; get; }
        public int roomID { set; get; }
        public int docID { set; get; }
        public int dur { set; get; }
        public string roomName { set; get; }
        public Time time { set; get; }
        public DateTime dt { set; get; }
        public EditAppointmentDTO(int pID, int rID, int dID, int dur, DateTime dt, Time t)
        {
            RC = new RoomController();
            AS = new AppointmentService();
            PC = new PatientController();
            patientID = pID;
            roomID = rID;
            docID = dID;
            this.time = t;
            this.dur = dur;
            this.dt = dt;
            this.roomName = RC.getRoomCrAppDTOById(roomID).name;
        }
        public ObservableCollection<ShowAppointmentDTO> getAllAppointmentDTO()
        {
            ObservableCollection<ShowAppointmentDTO> tmp = new ObservableCollection<ShowAppointmentDTO>();
            ObservableCollection<Appointment> list = AS.getAllAppointmentDTO();
            foreach (Appointment a in list)
            {
                if (a.operation != true)
                    tmp.Add(new ShowAppointmentDTO(PC.GetPatientByID(a.patientID).name, PC.GetPatientByID(a.patientID).surname, a.patientID, RC.getRoomById(a.roomID).name, a.date, a.timeString, a.description, a.medicalRecordID));

            }
            return tmp;
        }
        public class StartAppointmentDTO
        {
            public string desc { set; get; }
            public string therapy { set; get; }
            public string condition { set; get; }
            public ObservableCollection<TakingMedicineDTO> medicineList { set; get; }
            public int id { set; get; }
            public StartAppointmentDTO(string desc,string therapy,string condition, ObservableCollection<TakingMedicineDTO> medList,int id)
            {
                this.desc = desc;
                this.therapy = therapy;
                this.condition = condition;
                this.medicineList = medList;
                this.id = id;
            }
        }
        public ObservableCollection<ShowAppointmentDTO> getAllOperationsAppointmentDTO()
        {
            ObservableCollection<ShowAppointmentDTO> tmp = new ObservableCollection<ShowAppointmentDTO>();
            ObservableCollection<Appointment> list = AS.getAllAppointmentDTO();
            foreach (Appointment a in list)
            {
                if (a.operation == true)
                    tmp.Add(new ShowAppointmentDTO(PC.GetPatientByID(a.patientID).name, PC.GetPatientByID(a.patientID).surname, a.patientID, RC.getRoomById(a.roomID).name, a.date, a.timeString, a.description, a.medicalRecordID));

            }
            return tmp;
        }
        public BindingList<Time> getDoctorRoomTimes(DoctorCrAppDTO doc, DateTime dt, int id)
        {
            if (doc == null) return AS.getDoctorRoomTimes(0, dt, 0);
            return AS.getDoctorRoomTimes(doc.id, dt, id);
        }
        public BindingList<Time> getDoctorRoomTryTimes(DoctorCrAppDTO doc, DateTime dt, int id, string duration)
        {
            if (doc == null) return AS.getDoctorRoomTryTimes(0, dt, 0, duration);
            return AS.getDoctorRoomTryTimes(doc.id, dt, id, duration);
        }
        public BindingList<Time> getDoctorRoomOperationTimes(DoctorCrAppDTO doc, DateTime dt, int id)
        {
            if (doc == null) return AS.getDoctorRoomOperationTimes(0, dt, 0);
            return AS.getDoctorRoomOperationTimes(doc.id, dt, id);
        }
    }

    public class TakingMedicineDTO
    {
        private MedicineController MC;
        public string medsName { set; get; }
        public int medid { set; get; }
        public string freq { set; get; }
        public string amount { set; get; }
        public TakingMedicineDTO(int medid,string amount, string frq)
        {
            MC = new MedicineController();
            this.medid = medid;
            this.medsName = MC.getMedicineById(medid).name;
            this.freq = frq;
            this.amount = amount;
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
        public ShowAppointmentDTO(string pName, string pSurname, int pID, string rName, string date, string time, string desc)
        {
            patientName = pName;
            patientSurname = pSurname;
            patientID = pID;
            roomName = rName;
            Date = date;
            Time = time;
            this.desc = desc;
        }

    }
    public class ShowAppointmentPatientDTO
    {
        public string doctorName { set; get; }
        public string doctorSurname { set; get; }
        public string doctorID { set; get; }
        public string roomName { set; get; }
        public DateTime Date { set; get; }
        public string Time { set; get; }
        public string desc { set; get; }
        public int id { set; get; }
        public int duration { set; get; }
        public Boolean isNotGraded { set; get; }

        public ShowAppointmentPatientDTO(string dName, string dSurname, string dID, string rName, string time, string desc, int id, DateTime Date,int duration,Boolean isNotGraded)
        {
            doctorName = dName;
            doctorSurname = dSurname;
            doctorID = dID;
            roomName = rName;
            this.Date = Date;
            this.isNotGraded = isNotGraded;
            Time = time;
            this.desc = desc;
            this.id = id;
            this.duration = duration;
        }
    }
}
