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
        public bool addAppointment(Appointment newAppointment)
        {
            Serializer<Appointment> appoitmentSerializer = new Serializer<Appointment>();
            ObservableCollection<Appointment> appointmentList = appoitmentSerializer.fromCSV("appoitments.txt");
            appointmentList.Add(newAppointment);

            appoitmentSerializer.toCSV("appoitments.txt", appointmentList);
            return true;
        }

        public ObservableCollection<Appointment> getAllDoctorsAppointments(int doctorID)
        {
            ObservableCollection<Appointment> doctorApps = new ObservableCollection<Appointment>();
            Serializer<Appointment> doctorserialzer = new Serializer<Appointment>();
            foreach (Appointment a in doctorserialzer.fromCSV("appoitments.txt"))
            {
                if(a.doctorID == doctorID)
                {
                    doctorApps.Add(a);
                }
            }
            return doctorApps;
        }

      public bool DeleteAppointment(int appointmentID)
      {
            ObservableCollection<Appointment> appointmentList = new ObservableCollection<Appointment>();
            Serializer<Appointment> doctorserialzer = new Serializer<Appointment>();
            appointmentList = doctorserialzer.fromCSV("appoitments.txt");
            foreach(Appointment a in appointmentList)
            {
                if (a.appointmentID == appointmentID) appointmentList.Remove(a);
            }

            Serializer<Appointment> appoitmentSerializer = new Serializer<Appointment>();
            appoitmentSerializer.toCSV("appoitments.txt", appointmentList);
            return true;
        }
      
      public bool UpdateAppointment(Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      public Appointment GetAppointmentByID(int appointmentID)
      {
            Serializer<Appointment> doctorserialzer = new Serializer<Appointment>();
            foreach (Appointment a in doctorserialzer.fromCSV("appoitments.txt"))
            {
                if (a.appointmentID == appointmentID) return a;
            }
            return null;
      }
      
      public List<Appointment> GetAllAppointments()
      {
         throw new NotImplementedException();
      }
   
   }
}