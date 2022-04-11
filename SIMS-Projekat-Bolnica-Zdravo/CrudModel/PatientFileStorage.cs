
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
                Serializer<Patient> patientSerializer = new Serializer<Patient>();
                patientList = patientSerializer.fromCSV("patients.txt");
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