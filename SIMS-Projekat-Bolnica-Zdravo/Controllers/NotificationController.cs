// File:    NotificationController.cs
// Author:  Dusan
// Created: Saturday, April 30, 2022 12:35:15 PM
// Purpose: Definition of Class NotificationController

using SIMS_Projekat_Bolnica_Zdravo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SIMS_Projekat_Bolnica_Zdravo.Model;

namespace CrudModel
{
   public class NotificationController
   {
        private NotificationService ANS;
        public NotificationController() 
        {
            ANS = new NotificationService();
        }
        public bool CreateAppointmentNotification(SIMS_Projekat_Bolnica_Zdravo.Model.Notification newNotification)
      {
            return ANS.CreateAppointmentNotification(newNotification);
      }
      
      public bool DeleteAppointmentNotification(int appointmentNotificationID)
      {
            return ANS.DeleteAppointmentNotification(appointmentNotificationID);
      }  
      public bool UpdateAppointmentNotification(SIMS_Projekat_Bolnica_Zdravo.Model.Notification notification)
      {
            return ANS.UpdateAppointmentNotification(notification);
      }
      
      public ObservableCollection<SIMS_Projekat_Bolnica_Zdravo.Model.Notification> GetAppointmentNotificationrByPatientID(int patientID)
      {
            return ANS.GetAppointmentNotificationrByPatientID(patientID);
      }
      
      public ObservableCollection<SIMS_Projekat_Bolnica_Zdravo.Model.Notification> GetAppointmentNotificationrByDoctorID(int doctorID)
      {
            return ANS.GetAppointmentNotificationrByDoctorID(doctorID);
      }
   }
}