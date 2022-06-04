
using CrudModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SIMS_Projekat_Bolnica_Zdravo.Model;

namespace SIMS_Projekat_Bolnica_Zdravo
{
   public class NotificationService
   {
        public NotificationFileStorage ANSF;

        public NotificationService() 
        {
            ANSF = new NotificationFileStorage();
        }
        public bool CreateAppointmentNotification(Model.Notification newNotification)
      {
            return ANSF.CreateAppointmentNotification(newNotification);
      }
      
      public bool DeleteAppointmentNotification(int appointmentNotificationID)
      {
            return ANSF.DeleteAppointmentNotification(appointmentNotificationID);
      }
      
      public bool UpdateAppointmentNotification(Model.Notification notification)
      {
            return ANSF.UpdateAppointmentNotification(notification);
      }

        public ObservableCollection<Model.Notification> GetAppointmentNotificationrByPatientID(int patientID)
      {
            return ANSF.GetAppointmentNotificationrByPatientID(patientID);
      }
      
      public ObservableCollection<Model.Notification> GetAppointmentNotificationrByDoctorID(int doctorID)
      {
            return ANSF.GetAppointmentNotificationrByDoctorID(doctorID);
      }
   }
}