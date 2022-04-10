// File:    Doctor.cs
// Author:  Dusan
// Created: Wednesday, March 30, 2022 4:13:06 PM
// Purpose: Definition of Class Doctor

using System;
using System.Collections.ObjectModel;

namespace CrudModel
{
   public class Doctor : User
   {
        public Doctor(Specialization spec, string name, string surname, Address address, string password, string mobilePhone, string mail) : base(name, surname, address, password, mobilePhone, mail)
        {
            this.userID = User.generateID();
            this.name = name;
            this.surname = surname;
            this.address = address;
            this.password = password;
            this.mobilePhone = mobilePhone;
            this.mail = mail;
            this.specialization = spec;
        }

        public Specialization specialization
        {
            set;
            get;
        }

        public ObservableCollection<Appointment> appointment
        {
            set;
            get;
        }

        /// <summary>
        /// Property for collection of Appointment
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public ObservableCollection<Appointment> Appointment
      {
         get
         {
            if (appointment == null)
               appointment = new ObservableCollection<Appointment>();
            return appointment;
         }
         set
         {
            RemoveAllAppointment();
            if (value != null)
            {
               foreach (Appointment oAppointment in value)
                  AddAppointment(oAppointment);
            }
         }
      }
        public String getDoctorNameAndSurname()
        {
            return name + surname;
        }
      /// <summary>
      /// Add a new Appointment in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddAppointment(Appointment newAppointment)
      {
         if (newAppointment == null)
            return;
         if (this.appointment == null)
            this.appointment = new ObservableCollection<Appointment>();
         if (!this.appointment.Contains(newAppointment))
         {
            this.appointment.Add(newAppointment);
            newAppointment.doctor = this;
         }
      }
      
      /// <summary>
      /// Remove an existing Appointment from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveAppointment(Appointment oldAppointment)
      {
         if (oldAppointment == null)
            return;
         if (this.appointment != null)
            if (this.appointment.Contains(oldAppointment))
            {
               this.appointment.Remove(oldAppointment);
               oldAppointment.doctor = null;
            }
      }
      
      /// <summary>
      /// Remove all instances of Appointment from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllAppointment()
      {
         if (appointment != null)
         {
            System.Collections.ArrayList tmpAppointment = new System.Collections.ArrayList();
            foreach (Appointment oldAppointment in appointment)
               tmpAppointment.Add(oldAppointment);
            appointment.Clear();
            foreach (Appointment oldAppointment in tmpAppointment)
               oldAppointment.doctor = null;
            tmpAppointment.Clear();
         }
      }
   
   }
}