
using ConsoleApp.serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CrudModel
{
   public class PatientFileStorage
   {

        static public ObservableCollection<Patient> patientList
        {
            set;
            get;
        }

        public PatientFileStorage()
        {
            if (patientList == null)
            {
                patientList = new ObservableCollection<Patient>();
                Patient p = new Patient(Gender.male,"Jovan","Jovanovic",new Address("Serbia", "Novi Sad", "Milsa Obilica", "21a"),"lozinka123","0624563211","jovanjovanoviczmaj@gmail.com");
                MedicalRecord mr = new MedicalRecord(BloodType.a1);
                mr.patient = p;
                p.medicalRecord = mr;
                MedicalRecordFileStorage.medicalRecordList.Add(mr);
                patientList.Add(p);
                p = new Patient(Gender.male, "Pera", "Peric", new Address("Serbia", "Novi Sad", "Kisacka", "19a"), "lozinka124", "069595959", "peradetlic123@gmail.com");
                mr = new MedicalRecord(BloodType.a1);
                mr.patient = p;
                p.medicalRecord = mr;
                MedicalRecordFileStorage.medicalRecordList.Add(mr);
                patientList.Add(p);
                p = new Patient(Gender.male, "Zoran", "Zoranovic", new Address("Serbia", "Novi Sad", "Vojvode misica", "5b"), "lozinka125", "0601011011", "zokizmija420@gmail.com");
                mr = new MedicalRecord(BloodType.a);
                mr.patient = p;
                p.medicalRecord = mr;
                MedicalRecordFileStorage.medicalRecordList.Add(mr);
                patientList.Add(p);
                p = new Patient(Gender.female, "Mira", "Miric", new Address("Serbia", "Novi Sad", "Nikole Tesle", "3"), "lozinka126", "064586748", "Miricleptiric@gmail.com");
                mr = new MedicalRecord(BloodType.b);
                mr.patient = p;
                p.medicalRecord = mr;
                MedicalRecordFileStorage.medicalRecordList.Add(mr);
                patientList.Add(p);
                p = new Patient(Gender.female, "Lepa", "Lepic", new Address("Serbia", "Novi Sad", "Novosadskog sajma", "23b"), "lozinka127", "06123456789", "Lepaprelepa50@gmail.com");
                mr = new MedicalRecord(BloodType.a1);
                mr.patient = p;
                p.medicalRecord = mr;
                patientList.Add(p);
                Serializer<Patient> patientSerializer = new Serializer<Patient>();
                patientSerializer.toCSV("patients.txt", patientList);
            }
        }
     
      public bool CreatePatient(Patient newPatient)
      {
            patientList.Add(newPatient);
            return true;
      }
      
      public bool DeletePatient(int userID)
      {
         throw new NotImplementedException();
      }
      
      public bool UpdatePatient(Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public static Patient GetPatientByID(int id)
      {
         foreach (Patient p in patientList) {
                if (p.userID == id) return p;
         }
            return null;
      }
      
      public ObservableCollection<Patient> GetAllPatients()
      {
            return patientList;
      }
   
   }
}