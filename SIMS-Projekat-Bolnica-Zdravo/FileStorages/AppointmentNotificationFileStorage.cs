
using ConsoleApp.serialization;
using System;
using System.Collections.ObjectModel;
using SIMS_Projekat_Bolnica_Zdravo.Model;

namespace CrudModel
{
   public class AppointmentNotificationFileStorage
   {
      public bool CreateAppointmentNotification(AppointmentNotification newAppointmentNotification)
      {
            ObservableCollection<AppointmentNotification> appointmentNotificationList = new ObservableCollection<AppointmentNotification>();
            Serializer<AppointmentNotification> appointmentNotificationSerializer = new Serializer<AppointmentNotification>();
            appointmentNotificationList = appointmentNotificationSerializer.fromCSV("../../TxtFajlovi/appointmentNotifications.txt");

            appointmentNotificationList.Add(newAppointmentNotification);

            appointmentNotificationSerializer.toCSV("../../TxtFajlovi/appointmentNotifications.txt", appointmentNotificationList);
            return true;
        }
      
      public bool DeleteAppointmentNotification(int appointmentNotificationID)
      {
            ObservableCollection<AppointmentNotification> appointmentNotificationList = new ObservableCollection<AppointmentNotification>();
            Serializer<AppointmentNotification> appointmentNotificationSerializer = new Serializer<AppointmentNotification>();
            appointmentNotificationList = appointmentNotificationSerializer.fromCSV("../../TxtFajlovi/appointmentNotifications.txt");
            foreach (AppointmentNotification an in appointmentNotificationList)
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
      
      public bool UpdateAppointmentNotification(AppointmentNotification appointmentNotification)
      {
            ObservableCollection<AppointmentNotification> appointmentNotificationList = new ObservableCollection<AppointmentNotification>();
            Serializer<AppointmentNotification> appointmentNotificationSerializer = new Serializer<AppointmentNotification>();
            appointmentNotificationList = appointmentNotificationSerializer.fromCSV("../../TxtFajlovi/appointmentNotifications.txt");
            foreach (AppointmentNotification an in appointmentNotificationList)
            {
                if (an.NotificationID == appointmentNotification.NotificationID)
                {
                    appointmentNotificationList.Remove(an);
                    appointmentNotificationList.Add(appointmentNotification);
                    break;
                }
            }
            appointmentNotificationSerializer.toCSV("../../TxtFajlovi/appointmentNotifications.txt", appointmentNotificationList);
            return true;
        }
      
      public ObservableCollection<AppointmentNotification> GetAppointmentNotificationrByPatientID(int patientID)
      {
            ObservableCollection<AppointmentNotification> appointmentNotificationList = new ObservableCollection<AppointmentNotification>();
            Serializer<AppointmentNotification> appointmentNotificationSerializer = new Serializer<AppointmentNotification>();
            foreach (AppointmentNotification an in appointmentNotificationSerializer.fromCSV("../../TxtFajlovi/appointmentNotifications.txt"))
            {
                if (an.UserID == patientID)
                {
                    appointmentNotificationList.Add(an);
                }
            }
            return appointmentNotificationList;
        }
      
      public ObservableCollection<AppointmentNotification> GetAppointmentNotificationrByDoctorID(int doctorID)
      {
            ObservableCollection<AppointmentNotification> appointmentNotificationList = new ObservableCollection<AppointmentNotification>();
            Serializer<AppointmentNotification> appointmentNotificationSerializer = new Serializer<AppointmentNotification>();
            foreach (AppointmentNotification an in appointmentNotificationSerializer.fromCSV("../../TxtFajlovi/appointmentNotifications.txt"))
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