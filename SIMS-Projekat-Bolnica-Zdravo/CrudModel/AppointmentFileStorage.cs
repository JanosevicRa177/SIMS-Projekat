// File:    AppointmentFileStorage.cs
// Author:  Dusan
// Created: Sunday, April 3, 2022 8:00:41 PM
// Purpose: Definition of Class AppointmentFileStorage

using ConsoleApp.serialization;
using SIMS_Projekat_Bolnica_Zdravo.Controllers;
using SIMS_Projekat_Bolnica_Zdravo.CrudModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static SIMS_Projekat_Bolnica_Zdravo.Controllers.RoomController;

namespace CrudModel
{

    
   public class AppointmentFileStorage
   {

        public static ObservableCollection<Appointment> appointmentList
        { 
            get; 
            set; 
        }

        public AppointmentFileStorage()
        {
            if(appointmentList == null)
            {
                Serializer<Appointment> appoitmentSerializer = new Serializer<Appointment>();
                appointmentList = appoitmentSerializer.fromCSV("../../TxtFajlovi/appointments.txt");
            }
        }

        public void ExecutedAppointment(string cond,string ther,int id,ObservableCollection<Medicine> ocMed,string desc)
        {
            ObservableCollection<Appointment> appointmentList = new ObservableCollection<Appointment>();
            Serializer<Appointment> appoitmentSerializer = new Serializer<Appointment>();
            appointmentList = appoitmentSerializer.fromCSV("../../TxtFajlovi/appointments.txt");
            foreach (Appointment a in appointmentList)
            {
                if (a.appointmentID == id)
                {
                    a.condition = cond;
                    a.therapy = ther;
                    a.description = desc;
                    a.medicineList = ocMed;
                    a.setTime();
                    break;
                }
            }
            appoitmentSerializer.toCSV("../../TxtFajlovi/appointments.txt", appointmentList);
        }
        public bool addAppointment(Appointment newAppointment)
        {
            Serializer<Appointment> appoitmentSerializer = new Serializer<Appointment>();
            ObservableCollection<Appointment> appointmentList = appoitmentSerializer.fromCSV("../../TxtFajlovi/appointments.txt");
            appointmentList.Add(newAppointment);
            appoitmentSerializer.toCSV("../../TxtFajlovi/appointments.txt", appointmentList);
            return true;
        }

        public ObservableCollection<Appointment> getAllDoctorsAppointments(int doctorID)
        {
            ObservableCollection<Appointment> doctorApps = new ObservableCollection<Appointment>();
            Serializer<Appointment> appoitmentSerializer = new Serializer<Appointment>();
            foreach (Appointment a in appoitmentSerializer.fromCSV("../../TxtFajlovi/appointments.txt"))
            {
                if(a.doctorID == doctorID)
                {
                    doctorApps.Add(a);
                }
            }
            return doctorApps;
        }
        public ObservableCollection<Appointment> getAllPatientsAppointments(int medicalRecordID)
        {
            ObservableCollection<Appointment> patientsApps = new ObservableCollection<Appointment>();
            Serializer<Appointment> appoitmentSerializer = new Serializer<Appointment>();
            foreach (Appointment a in appoitmentSerializer.fromCSV("../../TxtFajlovi/appointments.txt"))
            {
                if (a.medicalRecordID == medicalRecordID)
                {
                    patientsApps.Add(a);
                }
            }
            return patientsApps;
        }
        public bool DeleteAppointment(int appointmentID)
      {
            ObservableCollection<Appointment> appointmentList = new ObservableCollection<Appointment>();
            Serializer<Appointment> appoitmentSerializer = new Serializer<Appointment>();
            appointmentList = appoitmentSerializer.fromCSV("../../TxtFajlovi/appointments.txt");
            foreach(Appointment a in appointmentList)
            {
                if (a.appointmentID == appointmentID)
                {
                    appointmentList.Remove(a);
                    break;
                }
            }
            appoitmentSerializer.toCSV("../../TxtFajlovi/appointments.txt", appointmentList);
            return true;
        }
      
      public bool UpdateAppointment(Appointment appointment)
      {
            ObservableCollection<Appointment> appointmentList = new ObservableCollection<Appointment>();
            Serializer<Appointment> appoitmentSerializer = new Serializer<Appointment>();
            appointmentList = appoitmentSerializer.fromCSV("../../TxtFajlovi/appointments.txt");
            foreach (Appointment a in appointmentList)
            {
                if (a.appointmentID == appointment.appointmentID)
                {
                    appointmentList.Remove(a);
                    appointmentList.Add(appointment);
                    break;
                }
            }
            appoitmentSerializer.toCSV("../../TxtFajlovi/appointments.txt", appointmentList);
            return true;
        }
        public bool ChangeAppointment(Time t, DateTime dt, int appointmentID,RoomCrAppDTO rcdto,int dur)
        {
            ObservableCollection<Appointment> appointmentList = new ObservableCollection<Appointment>();
            Serializer<Appointment> appoitmentSerializer = new Serializer<Appointment>();
            appointmentList = appoitmentSerializer.fromCSV("../../TxtFajlovi/appointments.txt");
            foreach (Appointment a in appointmentList)
            {
                if (a.appointmentID == appointmentID)
                {
                    a.timeBegin = dt;
                    a.time.hour = t.hour;
                    a.time.minute = t.minute;
                    if (rcdto != null) a.roomID = rcdto.id;
                    if (dur != -1) a.duration = dur;
                    a.setTime();
                    a.setDate();
                    break;
                }
            }
            appoitmentSerializer.toCSV("../../TxtFajlovi/appointments.txt", appointmentList);
            return true;
        }
        public Appointment GetAppointmentByID(int appointmentID)
      {
            Serializer<Appointment> appointmentList = new Serializer<Appointment>();
            foreach (Appointment a in appointmentList.fromCSV("../../TxtFajlovi/appointments.txt"))
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