
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
            ObservableCollection<Patient> patients = new ObservableCollection<Patient>();
            Serializer<Patient> patientSerializer = new Serializer<Patient>();
            foreach (Patient p in patientSerializer.fromCSV("../../TxtFajlovi/patients.txt"))
            {
                patients.Add(p);
            }
            patients.Add(newPatient);
            patientSerializer.toCSV("../../TxtFajlovi/patients.txt", patients);
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
        public bool IsAccountBlocked(int patientID)
        {
            Serializer<Patient> patientSerializer = new Serializer<Patient>();
            foreach (Patient p in patientSerializer.fromCSV("../../TxtFajlovi/patients.txt"))
            {
                if (p.userID == patientID)
                {
                    return p.isAccoutBlocked;
                }
            }
            return false;
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

        public bool CheckForTrolling(int patientID)
        {
            Serializer<Patient> patientSerializer = new Serializer<Patient>();
            ObservableCollection<Patient> patients = patientSerializer.fromCSV("../../TxtFajlovi/patients.txt");
            foreach (Patient p in patients)
            {
                if (p.userID == patientID)
                {
                    p.numberOfChangesLast30Days++;
                    if (p.numberOfChangesLast30Days >= 5)
                    {
                        p.isAccoutBlocked = true;
                        patientSerializer.toCSV("../../TxtFajlovi/patients.txt", patients);
                        return false;
                    }
                    patientSerializer.toCSV("../../TxtFajlovi/patients.txt", patients);
                    return true;
                }
            }
            return true;
        }
        public Patient GetPatientByID(int id)
        {
            Serializer<Patient> patientSerializer = new Serializer<Patient>();
            foreach (Patient p in patientSerializer.fromCSV("../../TxtFajlovi/patients.txt")) 
            {
                if (p.userID == id)
                {
                    p.fullaAddress = p.address.country + " " + p.address.city + " " + p.address.street + " " + p.address.number;
                    return p;
                }
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