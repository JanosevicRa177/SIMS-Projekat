// File:    AppointmentNotificationFileStorage.cs
// Author:  Dusan
// Created: Saturday, April 30, 2022 12:28:47 PM
// Purpose: Definition of Class AppointmentNotificationFileStorage

using ConsoleApp.serialization;
using System;
using System.Collections.ObjectModel;

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
                if (an.notificationID == appointmentNotificationID)
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
                if (an.notificationID == appointmentNotification.notificationID)
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
                if (an.userID == patientID)
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
                if (an.userID == doctorID)
                {
                    appointmentNotificationList.Add(an);
                }
            }
            return appointmentNotificationList;
        }
   
   }
}