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

        public string date
        {
            set;
            get;
        }

        public string time
        {
            set;
            get;
        }

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

        public int hour
        {
            set;
            get;
        }

        public int minute
        {
            set;
            get;
        }

        public Room room
        {
            set;
            get;
        }

        public Appointment(DateTime date,int hour,int minute,int duration,Room room,Doctor doc,string description,Patient pat)
        {
            this.medicalRecord = pat.medicalRecord;
            this.doctor = doc;
            this.timeBegin = date;
            this.date = timeBegin.Day.ToString() + "-" + timeBegin.Month.ToString() + "-" + timeBegin.Year.ToString();
            this.duration = duration;
            this.hour = hour;
            this.minute = minute;
            setTime();
            this.room = room;
            this.appointmentID = ++ids;
            this.description = description;
        }

        public string description
        {
            set;
            get;
        }

        private void setTime()
        {
            string var1 = "";
            string vars = "";
            string var5 = "";
            string var6 = "";
            int var = (this.minute + this.duration) % 60;
            int var2 = (this.minute + this.duration) / 60;
            int var3 = this.hour + var2;
            if (var3 >= 24) var3 -= 24;
            if (var3 <= 9) var1 = "0";
            if (var <= 9) vars = "0";
            if (this.hour <= 9) var5 = "0";
            if (this.minute <= 9) var6 = "0";
            this.time = var5 + this.hour.ToString() + ":" + var6 +this.minute.ToString();
            this.time += " - " + var1 + var3;
            this.time += ":" + vars + var;
        }


        /// <summary>
        /// Property for MedicalRecord
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public MedicalRecord medicalRecord
        {
            set;
            get;
        }
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

        /// <summary>
        /// Property for Doctor
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        /// 
        public Doctor doctor
        {
            set;
            get;
        }
        public Doctor Doctor { 
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