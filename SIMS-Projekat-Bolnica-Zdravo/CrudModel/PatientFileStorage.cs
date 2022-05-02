
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
        public int LoginPatient(String mail, String password)
        {
            Serializer<Patient> patientSerializer = new Serializer<Patient>();
            foreach (Patient p in patientSerializer.fromCSV("../../TxtFajlovi/patients.txt"))
            {
                if (mail.Equals(p.mail))
                {
                    if (password.Equals(p.password))
                    {
                        return p.userID;
                    }
                    return -1;
                }
            }
            return -1;
        }
        public Patient GetPatientByID(int id)
        {
            Serializer<Patient> patientSerializer = new Serializer<Patient>();
            foreach (Patient p in patientSerializer.fromCSV("../../TxtFajlovi/patients.txt")) 
            {
                if (p.userID == id) return p;
            }
            return null;
        }
      
      public ObservableCollection<Patient> getAllPatientsFS()
      {
            Serializer<Patient> patientSerializer = new Serializer<Patient>();
            return patientSerializer.fromCSV("../../TxtFajlovi/patients.txt");
      }
   
   }
}