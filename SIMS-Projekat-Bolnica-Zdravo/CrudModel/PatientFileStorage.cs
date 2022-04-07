// File:    PatientFileStorage.cs
// Author:  Dusan
// Created: Wednesday, March 30, 2022 4:08:11 PM
// Purpose: Definition of Class PatientFileStorage

using System;
using System.Collections.Generic;

namespace CrudModel
{
   public class PatientFileStorage
   {
        static public List<Patient> patientList = new List<Patient>();
      public bool CreatePatient(Patient newPatient)
      {
         throw new NotImplementedException();
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