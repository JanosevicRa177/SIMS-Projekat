using CrudModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public BindingList<Time> getDoctorTimes(int doctorID, DateTime forDate)
        {
            BindingList<Time> times = new BindingList<Time>();

            for (int i = 0, h = 7; h < 16 || i < 16;)
            {
                times.Add(new Time(h, 0, i++));
                times.Add(new Time(h++, 30, i++));
            }
            return filterDoctorsDayByHisAppointments(times, doctorID, forDate);
        }

        public BindingList<Time> filterDoctorsDayByHisAppointments(BindingList<Time> times, int doctorID, DateTime forDate)
        {
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
