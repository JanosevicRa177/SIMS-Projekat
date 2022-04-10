// File:    DoctorFileStorage.cs
// Author:  Dusan
// Created: Sunday, April 3, 2022 4:47:50 PM
// Purpose: Definition of Class DoctorFileStorage

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CrudModel
{
   public class DoctorFileStorage
   {
        static public ObservableCollection<CrudModel.Doctor> doctorList
        {
            get;
            set;
        }
        public DoctorFileStorage()
        {
            if (doctorList == null)
            {
                doctorList = new ObservableCollection<Doctor>();
            }
        }
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
      
      public ObservableCollection<CrudModel.Doctor> GetAllDoctors()
      {
            return doctorList;
         throw new NotImplementedException();
      }
   
   }
}