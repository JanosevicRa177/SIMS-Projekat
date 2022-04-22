
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
      
      public Patient GetPatientByID(int id)
      {
            Serializer<Patient> patientSerializer = new Serializer<Patient>();
            foreach (Patient p in patientSerializer.fromCSV("patients.txt")) {
                if (p.userID == id) return p;
            }
            return null;
      }
      
      public ObservableCollection<Patient> getAllPatientsFS()
      {
            Serializer<Patient> patientSerializer = new Serializer<Patient>();
            return patientSerializer.fromCSV("patients.txt");
      }
   
   }
}