using CrudModel;
using SIMS_Projekat_Bolnica_Zdravo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SIMS_Projekat_Bolnica_Zdravo.Controllers.RoomController;

namespace SIMS_Projekat_Bolnica_Zdravo.Controllers
{
    class AppointmentController
    {
        private AppointmentService AS;
        private PatientController PC;
        private RoomController RC;


        public AppointmentController()
        {
            PC = new PatientController();
            RC = new RoomController();
            AS = new AppointmentService();
        }

        public void removeAppointment(int appid)
        {
            AS.removeAppointment(appid);
        }

        public int CreateAppointment(DateTime dt, Time t, int dur, RoomCrAppDTO rcadto, DoctorCrAppDTO dcadto, string desc, PatientCrAppDTO pcdto)
        {
            return AS.CreateAppointment(dt, t, dur, rcadto.id, dcadto.id, desc, pcdto.id);
        }

        public ObservableCollection<ShowAppointmentDTO> getAllDoctorsAppointments(int docID)
        {
            ObservableCollection<ShowAppointmentDTO> adtolist = new ObservableCollection<ShowAppointmentDTO>();
            ObservableCollection<Appointment> apl =  AS.getAllDoctorsAppointments(docID);
            foreach(Appointment a in apl)
            {
                adtolist.Add(new ShowAppointmentDTO(PC.GetPatientByID(a.patientID).name, PC.GetPatientByID(a.patientID).surname, PC.GetPatientByID(a.patientID).userID.ToString(), RC.getRoomById(a.roomID).name, a.date, a.time, a.description,a.appointmentID));
            }
            return adtolist;
        }

        public ShowAppointmentDTO getShowAppointmentDTO(int appoID)
        {
            Appointment a = AS.getAppointmentById(appoID);
            return new ShowAppointmentDTO(PC.GetPatientByID(a.patientID).name, PC.GetPatientByID(a.patientID).surname, PC.GetPatientByID(a.patientID).userID.ToString(),RC.getRoomById(a.roomID).name,a.date,a.time,a.description,appoID);
        }
    

        public class ShowAppointmentDTO
        {
            public string patientName { set; get; }
            public string patientSurname { set; get; }
            public string patientID { set; get; }

            public string roomName { set; get; }
            public string Date { set; get; }
            public string Time { set; get; }
            public string desc { set; get; }

            public int id { set; get; }

            public ShowAppointmentDTO(string pName,string pSurname,string pID, string rName, string date,string time,string desc,int id)
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


    }
}
