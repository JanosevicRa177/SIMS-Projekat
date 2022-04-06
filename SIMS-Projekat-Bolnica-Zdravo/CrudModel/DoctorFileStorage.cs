// File:    DoctorFileStorage.cs
// Author:  Dusan
// Created: Sunday, April 3, 2022 4:47:50 PM
// Purpose: Definition of Class DoctorFileStorage

using System;
using System.Collections.Generic;

namespace CrudModel
{
   public class DoctorFileStorage
   {
      List<Doctor> doctorList;
      public bool CreateDoctor(Doctor newDoctor)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteDoctor(int userID)
      {
         throw new NotImplementedException();
      }
      
      public bool UpdateDoctor(Doctor doctor)
      {
         throw new NotImplementedException();
      }
      
      public Doctor GetDoctorByID(int doctorID)
      {
         throw new NotImplementedException();
      }
      
      public List<Doctor> GetAllDoctors()
      {
            return doctorList;
         throw new NotImplementedException();
      }
   
   }
}