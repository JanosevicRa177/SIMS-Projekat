// File:    Appointment.cs
// Author:  Dusan
// Created: Wednesday, March 30, 2022 4:13:42 PM
// Purpose: Definition of Class Appointment

using ConsoleApp.serialization;
using System;

namespace CrudModel
{
    public class Appointment : Serializable
    {
        private static int ids = -1;

        public Appointment()
        {

        }

        public static int getids()
        {
            return ids;
        }

        public static void setids(int set)
        {
            ids = set;
        }

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

        public int Duration
        {
            set
            {
                duration = value;
                setTime();
            }
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
            this.medicalRecord.patient = pat;
            this.doctor = doc;
            this.timeBegin = date;
            this.setDate();
            this.duration = duration;
            this.hour = hour;
            this.minute = minute;
            setTime();
            this.room = room;
            this.appointmentID = ++ids;
            this.description = description;
        }

        public void setDate()
        {
            this.date = timeBegin.Day.ToString() + "-" + timeBegin.Month.ToString() + "-" + timeBegin.Year.ToString();
        }

        public string description
        {
            set;
            get;
        }

        public void setTime()
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

        public string[] toCSV()
        {
            string[] csvValues =
            {
                medicalRecord.medicalRecordID.ToString(),
                doctor.userID.ToString(),
                timeBegin.Day.ToString(),
                timeBegin.Month.ToString(),
                timeBegin.Year.ToString(),
                duration.ToString(),
                hour.ToString(),
                minute.ToString(),
                room.roomID.ToString(),
                description,
                appointmentID.ToString()
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            this.medicalRecord = MedicalRecordFileStorage.GetMedicalRecordByID(int.Parse(values[0]));
            this.doctor = DoctorFileStorage.GetDoctorByID(int.Parse(values[1]));
            this.timeBegin = new DateTime(int.Parse(values[4]),int.Parse(values[3]),int.Parse(values[2]));
            this.duration = int.Parse(values[5]);
            this.hour = int.Parse(values[6]);
            this.minute = int.Parse(values[7]);
            this.room = RoomFileStorage.GetRoomByID(int.Parse(values[8]));
            this.description = values[9];
            this.appointmentID = int.Parse(values[10]);
            setTime();
            setDate();
            doctor.AddAppointment(this);
            medicalRecord.AddAppointment(this);
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