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

        public void removeAppointment(int appid)
        {
            AFS.DeleteAppointment(appid);
        }
        public bool ChangeAppointment(Time t, DateTime dt, int appointmentID)
        {
            return AFS.ChangeAppointment(t, dt, appointmentID);
        }
        public Appointment getAppointmentById(int AppID)
        {
            return AFS.GetAppointmentByID(AppID);
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
        public BindingList<TimePatient> getDoctorTimes(int doctorID, DateTime forDate)
        {
            Doctor d = DFS.GetDoctorByID(doctorID);
            BindingList<TimePatient> times = new BindingList<TimePatient>();
            DoctorCrAppDTO dDTO = new DoctorCrAppDTO(d.name, d.surname, d.userID);
            for (int i = 0, h = 7; h < 16 || i < 16;)
            {
                times.Add(new TimePatient(h, 0, i++, dDTO, forDate));
                times.Add(new TimePatient(h++, 30, i++, dDTO, forDate));
            }
            return filterDoctorsDayByHisAppointments(times, doctorID, forDate);
        }
        public BindingList<TimePatient> GetDoctorTermsByDoctor(int doctorID, DateTime forDate)
        {
            Doctor d = DFS.GetDoctorByID(doctorID);
            DoctorCrAppDTO dDTO = new DoctorCrAppDTO(d.name, d.surname, d.userID);
            return getDoctorsFreeTerms(dDTO,  forDate);
        }
        public BindingList<TimePatient> GetDoctorTermsByDate(DateTime forDate)
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
                BindingList<TimePatient> filterredTimes = filterDoctorsDayByHisAppointments(doctorsTimes, d.userID, forDate);
                foreach (TimePatient tp in filterredTimes)
                {
                    times.Add(tp);
                }
            }
            return times;
        }
        public BindingList<TimePatient> getDoctorsFreeTerms(DoctorCrAppDTO doctor, DateTime forDate)
        {
            BindingList<TimePatient> times = new BindingList<TimePatient>();
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
                            if (a.timeBegin.Year == date.Year && a.timeBegin.Month == date.Month && a.timeBegin.Day == date.Day)
                             {
                                foreach (TimePatient tp in doctorsTimes)
                                 {
                                     if (tp.hour == a.time.hour && tp.minute == a.time.minute)
                                     {
                                         int remid = tp.ID;
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
        public BindingList<TimePatient> filterDoctorsDayByHisAppointments(BindingList<TimePatient> times, int doctorID, DateTime forDate)
        {
            List<int> array = new List<int>();

            foreach (Appointment a in AFS.getAllDoctorsAppointments(doctorID))
            {
                if (a.timeBegin.Year == forDate.Year && a.timeBegin.Month == forDate.Month && a.timeBegin.Day == forDate.Day)
                {
                    foreach (TimePatient t in times)
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
    }
}
