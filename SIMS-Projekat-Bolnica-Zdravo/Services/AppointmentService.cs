using CrudModel;
using SIMS_Projekat_Bolnica_Zdravo.Controllers;
using SIMS_Projekat_Bolnica_Zdravo.CrudModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static SIMS_Projekat_Bolnica_Zdravo.Controllers.AppointmentController;
using static SIMS_Projekat_Bolnica_Zdravo.Controllers.RoomController;

namespace SIMS_Projekat_Bolnica_Zdravo.Services
{
    public class AppointmentService
    {
        private AppointmentFileStorage AFS;
        private RoomFileStorage RFS;
        private DoctorFileStorage DFS;
        private PatientFileStorage PFS;
        private MedicalRecordFileStorage MRFS;


        public AppointmentService()
        {
            AFS = new AppointmentFileStorage();
            RFS = new RoomFileStorage();
            DFS = new DoctorFileStorage();
            PFS = new PatientFileStorage();
            MRFS = new MedicalRecordFileStorage();
            
        }
        public void DeleteAppointment(ShowAppointmentDTO app)
        {
            AFS.RemoveAppointment(app.patientID.ToString(),app.Time,app.Date); 
        }
        public void DeleteOperationAppointment(ShowAppointmentDTO app)
        {
            AFS.RemoveOperationAppointment(app.patientID.ToString(), app.Time, app.Date);
        }
        public void UpdateAppointment(Appointment a,Appointment app)
        {
            AFS.UpdateAppointment(a, app);
        }
        public Appointment findAppById(int id,string date)
        {
            return AFS.findAppById(id, date);
        }
        public void removeAppointment(int appid)
        {
            AFS.DeleteAppointment(appid);
        }
        public bool ChangeAppointment(Time t, DateTime dt, int appointmentID,RoomCrAppDTO rcdto,int dur)
        {
            return AFS.ChangeAppointment(t, dt, appointmentID,rcdto,dur);
        }
        public Appointment getAppointmentById(int AppID)
        {
            return AFS.GetAppointmentByID(AppID);
        }
        public ObservableCollection<Appointment> getAllAppointmentDTO()
        {

            return AFS.getAllAppointmentDTO();
        }
        public void ExecutedAppointment(string cond, string ther, int id, ObservableCollection<Medicine> ocMed, string desc)
        {
            AFS.ExecutedAppointment(cond, ther, id, ocMed, desc);
        }

        public ObservableCollection<Appointment> getAllDoctorsAppointments(int docID)
        {
            return AFS.getAllDoctorsAppointments(docID);
        }
        public ObservableCollection<Appointment> getAllPatientsAppointments(int patientID)
        {
            MedicalRecord m = MRFS.getMedialRecordByPatientID(patientID);
            return AFS.getAllPatientsAppointments(m.medicalRecordID);
        }
        public BindingList<TimePatient> GetDoctorTimes(int doctorID, DateTime forDate,int duration, int appoID)
        {
            Doctor d = DFS.GetDoctorByID(doctorID);
            BindingList<TimePatient> times = new BindingList<TimePatient>();
            DoctorCrAppDTO dDTO = new DoctorCrAppDTO(d.name, d.surname, d.userID);
            for (int i = 0, h = 7; h < 16 || i < 16;)
            {
                times.Add(new TimePatient(h, 0, i++, dDTO, forDate));
                times.Add(new TimePatient(h++, 30, i++, dDTO, forDate));
            }
            return filterDoctorsDayByHisAppointments(times, doctorID, forDate, duration, appoID);
        }
        public BindingList<TimePatient> GetDoctorTermsByDoctor(int doctorID, DateTime forDate,int duration, int appoID)
        {
            Doctor d = DFS.GetDoctorByID(doctorID);
            DoctorCrAppDTO dDTO = new DoctorCrAppDTO(d.name, d.surname, d.userID);
            return getDoctorsFreeTerms(dDTO,  forDate, duration, appoID);
        }
        public BindingList<TimePatient> GetDoctorTermsByDate(DateTime forDate,int duration, int appoID)
        {
            ObservableCollection<Doctor> doctors = DFS.GetAllDoctors();
            ObservableCollection<Doctor> filteredDoctors = filterDoctorsForPatient(doctors);
            BindingList<TimePatient> times = new BindingList<TimePatient>();
            foreach (Doctor d in filteredDoctors)
            {
                BindingList<TimePatient> doctorsTimes = new BindingList<TimePatient>();
                DoctorCrAppDTO dDTO = new DoctorCrAppDTO(d.name, d.surname, d.userID);
                for (int i = 0, h = 7; h < 16 || i < 16;)
                {
                    doctorsTimes.Add(new TimePatient(h, 0, i++, dDTO, forDate));
                    doctorsTimes.Add(new TimePatient(h++, 30, i++, dDTO, forDate));
                }
                BindingList<TimePatient> filterredTimes = filterDoctorsDayByHisAppointments(doctorsTimes, d.userID, forDate, duration, appoID);
                foreach (TimePatient tp in filterredTimes)
                {
                    times.Add(tp);
                }
            }
            return times;
        }
        public BindingList<TimePatient> getDoctorsFreeTerms(DoctorCrAppDTO doctor, DateTime forDate, int duration1, int appoID)
        {
            BindingList<TimePatient> times = new BindingList<TimePatient>();
            int duration = duration1 / 30;
            ObservableCollection<Appointment> appointments = AFS.getAllDoctorsAppointments(doctor.id);
            for (int i = -2; i <= 2; i++)
            {
                BindingList<TimePatient> doctorsTimes = new BindingList<TimePatient>();
                DateTime date = forDate.AddDays(i);
                for (int j = 0, h = 7; h < 16 || j < 16;)
                {
                    doctorsTimes.Add(new TimePatient(h, 0, j++, doctor, date));
                    doctorsTimes.Add(new TimePatient(h++, 30, j++, doctor, date));
                }
                if (i == 0)
                {
                    continue;
                }
                else 
                {
                    if (date <= DateTime.Today)
                    {
                        continue;
                    }
                    else 
                    {
                        List<int> array = new List<int>();

                         foreach (Appointment a in appointments)
                         {
                            if (a.appointmentID == appoID)
                            {
                                continue;
                            }
                            if (a.timeBegin.Year == date.Year && a.timeBegin.Month == date.Month && a.timeBegin.Day == date.Day)
                             {
                                foreach (TimePatient tp in doctorsTimes)
                                 {
                                     if (tp.hour == a.time.hour && tp.minute == a.time.minute)
                                     {
                                         int remid = tp.ID;
                                         for (int j = 0; j < (a.duration / 30); j++)
                                         {
                                            if (!array.Contains(remid + j))
                                            {
                                                array.Add(remid + j);
                                            }
                                            for (int a1 = 1; a1 < duration; a1++)
                                            {
                                                if (!array.Contains(remid + j - a1))
                                                {
                                                    array.Add(remid + j - a1);
                                                }
                                            }
                                        }
                                     }
                                 }
                             }
                         }
                        for (int a1 = 1; a1 < duration; a1++)
                        {
                            array.Add(18 - a1);
                        }
                        foreach (int id in array)
                         {
                             foreach (var t in doctorsTimes)
                             {

                                 if (t.ID == id)
                                 {
                                    doctorsTimes.Remove(t);
                                    break;
                                 }

                             }
                         }
                        foreach (TimePatient tp in doctorsTimes)
                        {
                            times.Add(tp);
                        }
                    }
                }
            }
            return times;
        }
        public BindingList<TimePatient> filterDoctorsDayByHisAppointments(BindingList<TimePatient> times, int doctorID, DateTime forDate,int duration1, int appoID)
        {
            List<int> array = new List<int>();
            int duration = duration1 / 30;
            foreach (Appointment a in AFS.getAllDoctorsAppointments(doctorID))
            {
                if (a.appointmentID == appoID)
                {
                    continue;
                }
                if (a.timeBegin.Year == forDate.Year && a.timeBegin.Month == forDate.Month && a.timeBegin.Day == forDate.Day)
                {
                    foreach (TimePatient t in times)
                    {
                        if (t.hour == a.time.hour && t.minute == a.time.minute)
                        {
                            int remid = t.ID;
                            for (int j = 0; j < (a.duration / 30); j++)
                            {
                                if (!array.Contains(remid + j))
                                {
                                    array.Add(remid + j);
                                }
                                for (int i = 1; i < duration; i++)
                                {
                                    if (!array.Contains(remid + j - i))
                                    {
                                        array.Add(remid + j - i);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 1; i < duration; i++)
            {
                array.Add(18 - i);
            }
            foreach (int id in array)
            {
                foreach (var t in times)
                {
                    if (t.ID == id)
                    {
                        times.Remove(t);
                        break;
                    }

                }
            }
            return times;
        }

        public int CreateAppointment(DateTime dt, Time t, int dur, int roomID, int DoctorID, string desc, int patientID)
        {
            Appointment newApp = new Appointment(dt, t, dur, roomID, DoctorID, desc, patientID, MRFS.getMedialRecordByPatientID(patientID).medicalRecordID);
            AFS.addAppointment(newApp);
            return newApp.appointmentID;
        }
        public ObservableCollection<Doctor> getDoctorsPatient()
        {
            ObservableCollection<Doctor> doctors = DFS.GetAllDoctors();
            return filterDoctorsForPatient(doctors);
        }
        public ObservableCollection<Doctor> filterDoctorsForPatient(ObservableCollection<Doctor> doctors)
        {
            ObservableCollection<Doctor> filteredDoctors = new ObservableCollection<Doctor>();
            foreach (Doctor d in doctors)
            {
                if (d.specialization.specialization.Equals("No specialization"))
                {
                    filteredDoctors.Add(d);
                }
            }
            return filteredDoctors;
        }
        public int CreateOperationAppointment(DateTime dt, Time t, int dur, int roomID, int DoctorID, string desc, int patientID)
        {
            Appointment newApp = new Appointment(dt, t, dur, roomID, DoctorID, desc, patientID, MRFS.getMedialRecordByPatientID(patientID).medicalRecordID,true);
            AFS.addAppointment(newApp);
            return newApp.appointmentID;
        }
        public bool CreateTemporaryAppointment(DateTime dt, Time t, int dur, int roomID, int DoctorID, string desc,int id)
        {
            Appointment newApp = new Appointment(dt, t, dur, roomID, DoctorID, desc,id);
            AFS.addAppointment(newApp);
            return true;
        }
        public BindingList<Time> getDoctorRoomTimes(int doctorID, DateTime forDate, int roomID)
        {
            BindingList<Time> times = new BindingList<Time>();

            for (int i = 0, h = 7; h < 16 || i < 16;)
            {
                times.Add(new Time(h, 0, i++));
                times.Add(new Time(h++, 30, i++));
            }


            List<int> array = new List<int>();

            foreach (Appointment a in AFS.getAllDoctorsAppointments(doctorID))
            {
                if (a.timeBegin.Year == forDate.Year && a.timeBegin.Month == forDate.Month && a.timeBegin.Day == forDate.Day)
                {
                    foreach (Time t in times)
                    {
                        if (t.hour == a.time.hour && t.minute == a.time.minute)
                        {
                            int remid = t.ID;
                            for (int j = 0; j < (a.duration / 30); j++)
                            {
                                array.Add(remid + j);
                            }
                        }
                    }
                }
            }
            foreach (Appointment a in AFS.getAllRoomAppointments(roomID))
            {
                if (a.timeBegin.Year == forDate.Year && a.timeBegin.Month == forDate.Month && a.timeBegin.Day == forDate.Day)
                {
                    foreach (Time t in times)
                    {
                        if (t.hour == a.time.hour && t.minute == a.time.minute)
                        {
                            int remid = t.ID;
                            for (int j = 0; j < (a.duration / 30); j++)
                            {
                                array.Add(remid + j);
                            }
                        }
                    }
                }
            }
            foreach (int id in array)
            {
                foreach (var t in times)
                {

                    if (t.ID == id)
                    {
                        times.Remove(t);
                        break;
                    }

                }
            }
            return times;
        }
        public BindingList<Time> getDoctorRoomTryTimes(int doctorID, DateTime forDate, int roomID, string duration)
        {
            BindingList<Time> times = new BindingList<Time>();
            BindingList<Time> timess = new BindingList<Time>();

            for (int i = 0, h = 7; h < 16 || i < 16;)
            {
                times.Add(new Time(h, 0, i++));
                times.Add(new Time(h++, 30, i++));
                timess.Add(new Time(h, 0, i++));
                timess.Add(new Time(h++, 30, i++));
            }


            List<int> array = new List<int>();

            foreach (Appointment a in AFS.getAllDoctorsAppointments(doctorID))
            {
                if (a.timeBegin.Year == forDate.Year && a.timeBegin.Month == forDate.Month && a.timeBegin.Day == forDate.Day)
                {
                    foreach (Time t in times)
                    {
                        if (t.hour == a.time.hour && t.minute == a.time.minute)
                        {
                            int remid = t.ID;
                            for (int j = 0; j < (a.duration / 30); j++)
                            {
                                array.Add(remid + j);
                            }
                        }
                    }
                }
            }
            foreach (Appointment a in AFS.getAllRoomAppointments(roomID))
            {
                if (a.timeBegin.Year == forDate.Year && a.timeBegin.Month == forDate.Month && a.timeBegin.Day == forDate.Day)
                {
                    foreach (Time t in times)
                    {
                        if (t.hour == a.time.hour && t.minute == a.time.minute)
                        {
                            int remid = t.ID;
                            for (int j = 0; j < (a.duration / 30); j++)
                            {
                                array.Add(remid + j);
                            }
                        }
                    }
                }
            }
            
            
            foreach (int id in array)
            {
                foreach (var t in times)
                {

                    if (t.ID == id)
                    {
                        times.Remove(t);
                        timess.Remove(t);
                        break;
                    }

                }
            }
            int p = 0;
            int br = 0;
            int help = 0;
            help = Convert.ToInt32(duration) / 30;
            MessageBox.Show(help + "");
            foreach(Time t in timess)
            {
                if (br < times.Count)
                {
                    if ((timess.ElementAt(br + 1).hour * 60 + timess.ElementAt(br + 1).minute) - (timess.ElementAt(br).hour * 60 + timess.ElementAt(br).minute) <= 30)
                    {
                            for (int i = 0; i < help; i++)
                            {
                       
                                if (br - i > 0)
                                {
                                MessageBox.Show(timess.ElementAt(br - i) + "");
                                    times.RemoveAt(br - i);
                                }

                         
                            }  
                     }
                    
                }
                br++;


            }











            //int c = 0;
            //BindingList<Time> pomList = new BindingList<Time>();
            //pomList = times;
            // int n = pomList.Count;
            // while (c < pomList.Count - 1)
            // {
            //     MessageBox.Show(pomList.ElementAt(c + 1).hour * 60 + pomList.ElementAt(c + 1).minute - pomList.ElementAt(c).hour * 60 + pomList.ElementAt(c).minute + " Vece manje " + duration);
            //     if ((pomList.ElementAt(c+1).hour*60 + pomList.ElementAt(c + 1).minute) - (pomList.ElementAt(c).hour*60 + pomList.ElementAt(c).minute) > Convert.ToInt32(duration))
            //         {


            //            times.RemoveAt(c);
            //      }
            // c++;



            //          } 


            return times;
        }
        public BindingList<Time> getDoctorRoomOperationTimes(int doctorID, DateTime forDate, int roomID)
        {
            BindingList<Time> times = new BindingList<Time>();

            for (int i = 0, h = 7; h < 16 || i < 16;)
            {
                times.Add(new Time(h, 0, i++));
                times.Add(new Time(h++, 30, i++));
            }


            List<int> array = new List<int>();

            foreach (Appointment a in AFS.getAllDoctorsAppointments(doctorID))
            {
                if (a.timeBegin.Year == forDate.Year && a.timeBegin.Month == forDate.Month && a.timeBegin.Day == forDate.Day && a.operation == true)
                {
                    foreach (Time t in times)
                    {
                        if (t.hour == a.time.hour && t.minute == a.time.minute)
                        {
                            int remid = t.ID;
                            for (int j = 0; j < (a.duration / 30); j++)
                            {
                                array.Add(remid + j);
                            }
                        }
                    }
                }
            }
            foreach (Appointment a in AFS.getAllRoomAppointments(roomID))
            {
                if (a.timeBegin.Year == forDate.Year && a.timeBegin.Month == forDate.Month && a.timeBegin.Day == forDate.Day && a.operation == true)
                {
                    foreach (Time t in times)
                    {
                        if (t.hour == a.time.hour && t.minute == a.time.minute)
                        {
                            int remid = t.ID;
                            for (int j = 0; j < (a.duration / 30); j++)
                            {
                                array.Add(remid + j);
                            }
                        }
                    }
                }
            }
            foreach (int id in array)
            {
                foreach (var t in times)
                {

                    if (t.ID == id)
                    {
                        times.Remove(t);
                        break;
                    }

                }
            }
            return times;
        }
    }
}
