// File:    DoctorFileStorage.cs
// Author:  Dusan
// Created: Sunday, April 3, 2022 4:47:50 PM
// Purpose: Definition of Class DoctorFileStorage

using ConsoleApp.serialization;
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
                Serializer<Doctor> doctorserialzer = new Serializer<Doctor>();
                doctorList = doctorserialzer.fromCSV("doctors.txt");
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
            Serializer<Doctor> doctorserialzer = new Serializer<Doctor>();
            foreach (Doctor doc in doctorserialzer.fromCSV("doctors.txt"))
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