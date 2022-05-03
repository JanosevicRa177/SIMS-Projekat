using CrudModel;
using SIMS_Projekat_Bolnica_Zdravo.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static SIMS_Projekat_Bolnica_Zdravo.Controllers.AppointmentController;

namespace SIMS_Projekat_Bolnica_Zdravo.Services
{
    class AppointmentService
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
            AFS.RemoveAppointment(app.patientID,app.Time,app.Date); 
        }
        public void DeleteOperationAppointment(ShowAppointmentDTO app)
        {
            AFS.RemoveOperationAppointment(app.patientID, app.Time, app.Date);
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
        public Appointment getAppointmentById(int AppID)
        {
            return AFS.GetAppointmentByID(AppID);
        }

        public ObservableCollection<Appointment> getAllAppointmentDTO()
        {
            
            return AFS.getAllAppointmentDTO();
        }

        public ObservableCollection<Appointment> getAllDoctorsAppointments(int docID)
        {
            return AFS.getAllDoctorsAppointments(docID);
        }
        public int CreateAppointment(DateTime dt, Time t, int dur, int roomID, int DoctorID, string desc, int patientID)
        {
            Appointment newApp = new Appointment(dt, t, dur, roomID, DoctorID, desc, patientID, MRFS.getMedialRecordByPatientID(patientID).medicalRecordID);
            AFS.addAppointment(newApp);
            return newApp.appointmentID;
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
                        if (t.hour == a.hour && t.minute == a.minute)
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
                        if (t.hour == a.hour && t.minute == a.minute)
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
                        if (t.hour == a.hour && t.minute == a.minute)
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
                        if (t.hour == a.hour && t.minute == a.minute)
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
                        if (t.hour == a.hour && t.minute == a.minute)
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
                        if (t.hour == a.hour && t.minute == a.minute)
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
