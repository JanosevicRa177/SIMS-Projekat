// File:    Appointment.cs
// Author:  Dusan
// Created: Wednesday, March 30, 2022 4:13:42 PM
// Purpose: Definition of Class Appointment

using System;

namespace CrudModel
{
   public class Appointment
   {
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
        public MedicalRecord medicalRecord
        {
            set;
            get;
        }

        /// <summary>
        /// Property for MedicalRecord
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public MedicalRecord MedicalRecord
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
      public Doctor doctor
        {
            set;
            get;
        }

        /// <summary>
        /// Property for Doctor
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public Doctor Doctor
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