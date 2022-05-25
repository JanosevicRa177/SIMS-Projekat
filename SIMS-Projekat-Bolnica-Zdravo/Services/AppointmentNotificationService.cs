// File:    AppointmentNotificationService.cs
// Author:  Dusan
// Created: Saturday, April 30, 2022 12:34:56 PM
// Purpose: Definition of Class AppointmentNotificationService

using CrudModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SIMS_Projekat_Bolnica_Zdravo.Model;

namespace SIMS_Projekat_Bolnica_Zdravo
{
   public class AppointmentNotificationService
   {
        public AppointmentNotificationFileStorage ANSF;

        public AppointmentNotificationService() 
        {
            ANSF = new AppointmentNotificationFileStorage();
        }
        public bool CreateAppointmentNotification(AppointmentNotification newAppointmentNotification)
      {
            return ANSF.CreateAppointmentNotification(newAppointmentNotification);
      }
      
      public bool DeleteAppointmentNotification(int appointmentNotificationID)
      {
            return ANSF.DeleteAppointmentNotification(appointmentNotificationID);
      }
      
      public bool UpdateAppointmentNotification(AppointmentNotification appointmentNotification)
      {
            return ANSF.UpdateAppointmentNotification(appointmentNotification);
      }

        public ObservableCollection<AppointmentNotification> GetAppointmentNotificationrByPatientID(int patientID)
      {
            return ANSF.GetAppointmentNotificationrByPatientID(patientID);
      }
      
      public ObservableCollection<AppointmentNotification> GetAppointmentNotificationrByDoctorID(int doctorID)
      {
            return ANSF.GetAppointmentNotificationrByDoctorID(doctorID);
      }
   }
}