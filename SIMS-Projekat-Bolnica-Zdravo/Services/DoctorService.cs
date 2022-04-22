using CrudModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat_Bolnica_Zdravo.Services
{
    class DoctorService
    {
        private DoctorFileStorage DFS;
        private AppointmentFileStorage APFS;

        public DoctorService()
        {
            DFS = new DoctorFileStorage();
            APFS = new AppointmentFileStorage();
        }

        public ObservableCollection<Doctor> getAllDoctors()
        {
            return DFS.GetAllDoctors();
        }

        public ObservableCollection<Time> getDoctorTimes(int doctorID,DateTime forDate)
        {
            ObservableCollection<Time> times = new ObservableCollection<Time>();

            for (int i = 0, h = 7; h < 16 || i < 16;)
            {
                times.Add(new Time(h, 0, i++));
                times.Add(new Time(h++, 30, i++));
            }
            
            
            List<int> array = new List<int>();
            
            foreach (Appointment a in APFS.getAllDoctorsAppointments(doctorID))
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
    }

        //public void addAppointmentToDoctor(int appID,int docID)
        //{

        //}
}
