// File:    AppointmentFileStorage.cs
// Author:  Dusan
// Created: Sunday, April 3, 2022 8:00:41 PM
// Purpose: Definition of Class AppointmentFileStorage

using ConsoleApp.serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using static SIMS_Projekat_Bolnica_Zdravo.Controllers.AppointmentController;

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
        public ObservableCollection<Appointment> getAllRoomAppointments(int roomID)
        {
            ObservableCollection<Appointment> doctorApps = new ObservableCollection<Appointment>();
            Serializer<Appointment> doctorserialzer = new Serializer<Appointment>();
            foreach (Appointment a in doctorserialzer.fromCSV("appoitments.txt"))
            {
                if (a.roomID == roomID)
                {
                    doctorApps.Add(a);
                }
            }
            return doctorApps;
        }
        public ObservableCollection<Appointment> getAllAppointmentDTO()
        {
            ObservableCollection<Appointment> doctorApps = new ObservableCollection<Appointment>();
            Serializer<Appointment> doctorserialzer = new Serializer<Appointment>();
            foreach (Appointment a in doctorserialzer.fromCSV("appoitments.txt"))
            {
                
                    doctorApps.Add(a);
                    
            }
            return doctorApps;
        }
        public bool RemoveAppointment(string id,string time,string date)
        {
            ObservableCollection<Appointment> appointmentList;
            Serializer<Appointment> doctorserialzer = new Serializer<Appointment>();
            appointmentList = doctorserialzer.fromCSV("appoitments.txt");
            foreach (Appointment a in appointmentList)
            {
                if ((a.patientID == Convert.ToInt32(id)) && (a.date.Equals(date)) && (a.operation != true) && ((a.time.Equals(time) || (a.time.Split(' ')[0].Equals(time.Split(' ')[0])))))
                {
               
                    appointmentList.Remove(a);
                    break;
                }

            }

            doctorserialzer.toCSV("appoitments.txt", appointmentList);
            return true;
        }
        public bool RemoveOperationAppointment(string id, string time, string date)
        {
            ObservableCollection<Appointment> appointmentList;
            Serializer<Appointment> doctorserialzer = new Serializer<Appointment>();
            appointmentList = doctorserialzer.fromCSV("appoitments.txt");
            foreach (Appointment a in appointmentList)
            {
                if ((a.patientID == Convert.ToInt32(id)) && (a.date.Equals(date)) && (a.operation == true) && ((a.time.Equals(time) || (a.time.Split(' ')[0].Equals(time.Split(' ')[0])))))
                {

                    appointmentList.Remove(a);
                    break;
                }

            }

            doctorserialzer.toCSV("appoitments.txt", appointmentList);
            return true;
        }
        public bool DeleteAppointment(int appointmentID)
      {
            ObservableCollection<Appointment> appointmentList;
            Serializer<Appointment> doctorserialzer = new Serializer<Appointment>();
            appointmentList = doctorserialzer.fromCSV("appoitments.txt");
            foreach(Appointment a in appointmentList)
            {
                if (a.appointmentID == appointmentID)
                {
                    appointmentList.Remove(a);
                    break;
                }
                
            }

            doctorserialzer.toCSV("appoitments.txt", appointmentList);
            return true;
        }
      
      public bool UpdateAppointment(Appointment appointment, Appointment app)
      {
            ObservableCollection<Appointment> appointmentList;
            Serializer<Appointment> doctorserialzer = new Serializer<Appointment>();
            appointmentList = doctorserialzer.fromCSV("appoitments.txt");
            foreach(Appointment a in appointmentList)
            {
                if(a.appointmentID == appointment.appointmentID && a.time.Equals(appointment.time) && a.date.Equals(appointment.date))
                {
                 
                    a.timeBegin = app.timeBegin;
                    a.time = app.time;
                    a.hour = app.hour;
                    a.minute = app.minute;
                    a.date = app.date;
                    a.description = app.description;
                    a.roomID = app.roomID;
                    a.doctorID = app.doctorID;
                    a.duration = app.duration;
                    
                    
                }
            }
            doctorserialzer.toCSV("appoitments.txt", appointmentList);
            return true;
        }
        public Appointment findAppById(int patid,string date)
        {
            ObservableCollection<Appointment> appointmentList;
            Serializer<Appointment> doctorserialzer = new Serializer<Appointment>();
            appointmentList = doctorserialzer.fromCSV("appoitments.txt");
            Appointment app = null; 
            foreach (Appointment a in appointmentList)
            {

                if ((a.patientID == patid) && (a.date.Split(' ')[0].Equals(date)))
                {

               
                    app = a;
                    return app;
                }
            }
            doctorserialzer.toCSV("appoitments.txt", appointmentList);
            return app;
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