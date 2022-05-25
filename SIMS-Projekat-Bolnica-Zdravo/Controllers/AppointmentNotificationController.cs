// File:    AppointmentNotificationController.cs
// Author:  Dusan
// Created: Saturday, April 30, 2022 12:35:15 PM
// Purpose: Definition of Class AppointmentNotificationController

using SIMS_Projekat_Bolnica_Zdravo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SIMS_Projekat_Bolnica_Zdravo.Model;

namespace CrudModel
{
   public class AppointmentNotificationController
   {
        private AppointmentNotificationService ANS;
        public AppointmentNotificationController() 
        {
            ANS = new AppointmentNotificationService();
        }
        public bool CreateAppointmentNotification(AppointmentNotification newAppointmentNotification)
      {
            return ANS.CreateAppointmentNotification(newAppointmentNotification);
      }
      
      public bool DeleteAppointmentNotification(int appointmentNotificationID)
      {
            return ANS.DeleteAppointmentNotification(appointmentNotificationID);
      }  
      public bool UpdateAppointmentNotification(AppointmentNotification appointmentNotification)
      {
            return ANS.UpdateAppointmentNotification(appointmentNotification);
      }
      
      public ObservableCollection<AppointmentNotification> GetAppointmentNotificationrByPatientID(int patientID)
      {
            return ANS.GetAppointmentNotificationrByPatientID(patientID);
      }
      
      public ObservableCollection<AppointmentNotification> GetAppointmentNotificationrByDoctorID(int doctorID)
      {
            return ANS.GetAppointmentNotificationrByDoctorID(doctorID);
      }
   }
}