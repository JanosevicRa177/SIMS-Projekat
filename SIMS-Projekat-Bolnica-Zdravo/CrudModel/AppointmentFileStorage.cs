// File:    AppointmentFileStorage.cs
// Author:  Dusan
// Created: Sunday, April 3, 2022 8:00:41 PM
// Purpose: Definition of Class AppointmentFileStorage

using ConsoleApp.serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CrudModel
{

    
   public class AppointmentFileStorage
   {

        public static ObservableCollection<Appointment> appointmentList { 
            get; 
            set; 
        }

        public AppointmentFileStorage()
        {
            if(appointmentList == null)
            {
                Serializer<Appointment> doctorserialzer = new Serializer<Appointment>();
                appointmentList = doctorserialzer.fromCSV("appoitments.txt");
            }
        }
        public bool CreateAppointment(Appointment newAppointment)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteAppointment(int appointmentID)
      {
         throw new NotImplementedException();
      }
      
      public bool UpdateAppointment(Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      public Appointment GetAppointmentByID(int appointmentID)
      {
         throw new NotImplementedException();
      }
      
      public List<Appointment> GetAllAppointments()
      {
         throw new NotImplementedException();
      }
   
   }
}