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
        static public ObservableCollection<Doctor> doctorList
        {
            set;
            get;
        }

        public DoctorFileStorage()
        {
            if(doctorList == null)
            {
                doctorList = new ObservableCollection<Doctor>();
                Doctor doca = new Doctor(SpecializationFileStorage.specializationList[0],"Milica","Milutinovic",new Address("Sirija","Beograd","Bulevar","21"),"123","0124454","milica@gmail.com");
                doctorList.Add(doca);
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
      
      public static Doctor GetDoctorByID(int doctorID)
      {
         foreach(Doctor doc in doctorList)
            {
                if (doc.userID == doctorID)
                {
                    return doc;
                }
            }
            return null;
      }
      
      public ObservableCollection<Doctor> GetAllDoctors()
      {
            return doctorList;
         throw new NotImplementedException();
      }
   
   }
}