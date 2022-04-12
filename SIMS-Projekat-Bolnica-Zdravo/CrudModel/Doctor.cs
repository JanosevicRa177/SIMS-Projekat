// File:    Doctor.cs
// Author:  Dusan
// Created: Wednesday, March 30, 2022 4:13:06 PM
// Purpose: Definition of Class Doctor

using ConsoleApp.serialization;
using System;
using System.Collections.ObjectModel;

namespace CrudModel
{
   public class Doctor : User , Serializable
    {

        public Doctor()
        {
            address = new Address();
        }
        
        public Doctor(int id,String name,String surname,String email,String password,Address address, String phone, Specialization spec,String pos)
        {
            this.userID = id;
            this.name = name;
            this.surname = surname;
            this.mail = email;
            this.password = password;
            this.address = address;
            this.mobilePhone = phone;
            this.specialization = spec;
            this.position = pos;
        }
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
            this.position = "Doctor";
        }

        public Specialization specialization
        {
            set;
            get;
        }
        public String position
        {
            set;
            get;
        }
        public String gender
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

        public string[] toCSV()
        {
            string[] csvValues =
            {
                name,
                surname,
                address.country,
                address.city,
                address.street,
                address.number,
                password,
                mobilePhone,
                mail,
                userID.ToString(),
                specialization.specialization
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            name = values[0];
            surname = values[1];
            address.country = values[2];
            address.city = values[3];
            address.street = values[4];
            address.number = values[5];
            password = values[6];
            mobilePhone = values[7];
            mail = values[8];
            userID = int.Parse(values[9]);
            specialization = SpecializationFileStorage.GetSpecialization(values[10]);
        }
    }
}