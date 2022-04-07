// File:    Appointment.cs
// Author:  Dusan
// Created: Wednesday, March 30, 2022 4:13:42 PM
// Purpose: Definition of Class Appointment

using System;

namespace CrudModel
{
   public class Appointment
   {
        static int ids = -1;

        public DateTime timeBegin
        {
            set;
            get;
        }
      public int duration
        {
            set;
            get;
        }
        public int appointmentID
        {
            set;
            get;
        }

        public Room room
        {
            set;
            get;
        }

        public Appointment(DateTime date, int duration,int roomID,int doctorID, int patientID)
        {
            this.timeBegin = date;
            this.appointmentID = ++ids;
        }

        public Appointment(DateTime dateTime)
        {
            this.timeBegin = dateTime;
        }



        /// <summary>
        /// Property for MedicalRecord
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public MedicalRecord medicalRecord
      {
         get
         {
            return medicalRecord;
         }
         set
         {
            if (this.medicalRecord == null || !this.medicalRecord.Equals(value))
            {
               if (this.medicalRecord != null)
               {
                  MedicalRecord oldMedicalRecord = this.medicalRecord;
                  this.medicalRecord = null;
                  oldMedicalRecord.RemoveAppointment(this);
               }
               if (value != null)
               {
                  this.medicalRecord = value;
                  this.medicalRecord.AddAppointment(this);
               }
            }
         }
      }

        /// <summary>
        /// Property for Doctor
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public Doctor doctor
      {
         get
         {
            return doctor;
         }
         set
         {
            if (this.doctor == null || !this.doctor.Equals(value))
            {
               if (this.doctor != null)
               {
                  Doctor oldDoctor = this.doctor;
                  this.doctor = null;
                  oldDoctor.RemoveAppointment(this);
               }
               if (value != null)
               {
                  this.doctor = value;
                  this.doctor.AddAppointment(this);
               }
            }
         }
      }
   
   }
}