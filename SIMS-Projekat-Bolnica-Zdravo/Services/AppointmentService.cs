using CrudModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
