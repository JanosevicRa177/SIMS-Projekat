
using ConsoleApp.serialization;
using System;
using System.Collections.ObjectModel;
using SIMS_Projekat_Bolnica_Zdravo.Model;

namespace CrudModel
{
   public class NotificationFileStorage
   {
      public bool CreateAppointmentNotification(SIMS_Projekat_Bolnica_Zdravo.Model.Notification newNotification)
      {
            ObservableCollection<SIMS_Projekat_Bolnica_Zdravo.Model.Notification> appointmentNotificationList = new ObservableCollection<SIMS_Projekat_Bolnica_Zdravo.Model.Notification>();
            Serializer<SIMS_Projekat_Bolnica_Zdravo.Model.Notification> appointmentNotificationSerializer = new Serializer<SIMS_Projekat_Bolnica_Zdravo.Model.Notification>();
            appointmentNotificationList = appointmentNotificationSerializer.fromCSV("../../TxtFajlovi/appointmentNotifications.txt");

            appointmentNotificationList.Add(newNotification);

            appointmentNotificationSerializer.toCSV("../../TxtFajlovi/appointmentNotifications.txt", appointmentNotificationList);
            return true;
        }
      
      public bool DeleteAppointmentNotification(int appointmentNotificationID)
      {
            ObservableCollection<SIMS_Projekat_Bolnica_Zdravo.Model.Notification> appointmentNotificationList = new ObservableCollection<SIMS_Projekat_Bolnica_Zdravo.Model.Notification>();
            Serializer<SIMS_Projekat_Bolnica_Zdravo.Model.Notification> appointmentNotificationSerializer = new Serializer<SIMS_Projekat_Bolnica_Zdravo.Model.Notification>();
            appointmentNotificationList = appointmentNotificationSerializer.fromCSV("../../TxtFajlovi/appointmentNotifications.txt");
            foreach (SIMS_Projekat_Bolnica_Zdravo.Model.Notification an in appointmentNotificationList)
            {
                if (an.NotificationID == appointmentNotificationID)
                {
                    appointmentNotificationList.Remove(an);
                    break;
                }
            }
            appointmentNotificationSerializer.toCSV("../../TxtFajlovi/appointmentNotifications.txt", appointmentNotificationList);
            return true;
        }
      
      public bool UpdateAppointmentNotification(SIMS_Projekat_Bolnica_Zdravo.Model.Notification notification)
      {
            ObservableCollection<SIMS_Projekat_Bolnica_Zdravo.Model.Notification> appointmentNotificationList = new ObservableCollection<SIMS_Projekat_Bolnica_Zdravo.Model.Notification>();
            Serializer<SIMS_Projekat_Bolnica_Zdravo.Model.Notification> appointmentNotificationSerializer = new Serializer<SIMS_Projekat_Bolnica_Zdravo.Model.Notification>();
            appointmentNotificationList = appointmentNotificationSerializer.fromCSV("../../TxtFajlovi/appointmentNotifications.txt");
            foreach (SIMS_Projekat_Bolnica_Zdravo.Model.Notification an in appointmentNotificationList)
            {
                if (an.NotificationID == notification.NotificationID)
                {
                    appointmentNotificationList.Remove(an);
                    appointmentNotificationList.Add(notification);
                    break;
                }
            }
            appointmentNotificationSerializer.toCSV("../../TxtFajlovi/appointmentNotifications.txt", appointmentNotificationList);
            return true;
        }
      
      public ObservableCollection<SIMS_Projekat_Bolnica_Zdravo.Model.Notification> GetAppointmentNotificationrByPatientID(int patientID)
      {
            ObservableCollection<SIMS_Projekat_Bolnica_Zdravo.Model.Notification> appointmentNotificationList = new ObservableCollection<SIMS_Projekat_Bolnica_Zdravo.Model.Notification>();
            Serializer<SIMS_Projekat_Bolnica_Zdravo.Model.Notification> appointmentNotificationSerializer = new Serializer<SIMS_Projekat_Bolnica_Zdravo.Model.Notification>();
            foreach (SIMS_Projekat_Bolnica_Zdravo.Model.Notification an in appointmentNotificationSerializer.fromCSV("../../TxtFajlovi/appointmentNotifications.txt"))
            {
                if (an.UserID == patientID)
                {
                    appointmentNotificationList.Add(an);
                }
            }
            return appointmentNotificationList;
        }
      
      public ObservableCollection<SIMS_Projekat_Bolnica_Zdravo.Model.Notification> GetAppointmentNotificationrByDoctorID(int doctorID)
      {
            ObservableCollection<SIMS_Projekat_Bolnica_Zdravo.Model.Notification> appointmentNotificationList = new ObservableCollection<SIMS_Projekat_Bolnica_Zdravo.Model.Notification>();
            Serializer<SIMS_Projekat_Bolnica_Zdravo.Model.Notification> appointmentNotificationSerializer = new Serializer<SIMS_Projekat_Bolnica_Zdravo.Model.Notification>();
            foreach (SIMS_Projekat_Bolnica_Zdravo.Model.Notification an in appointmentNotificationSerializer.fromCSV("../../TxtFajlovi/appointmentNotifications.txt"))
            {
                if (an.UserID == doctorID)
                {
                    appointmentNotificationList.Add(an);
                }
            }
            return appointmentNotificationList;
        }
   
   }
}