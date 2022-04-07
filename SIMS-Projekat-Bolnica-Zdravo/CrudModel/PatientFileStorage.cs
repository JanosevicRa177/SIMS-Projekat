
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
                Patient p = new Patient(Gender.male,"Jovan","Jovanovic",new Address("Serbia", "Novi sad", "Milsa Obilica", "21a"),"lozinka123","0624563211","jovanjovanoviczmaj@gmail.com");
                patientList.Add(p);
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
      
      public Patient GetPatientByID(int userID)
      {
         throw new NotImplementedException();
      }
      
      public List<Patient> GetAllPatients()
      {
         throw new NotImplementedException();
      }
   
   }
}