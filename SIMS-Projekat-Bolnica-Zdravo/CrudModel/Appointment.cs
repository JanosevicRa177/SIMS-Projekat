// File:    Appointment.cs
// Author:  Dusan
// Created: Wednesday, March 30, 2022 4:13:42 PM
// Purpose: Definition of Class Appointment

using ConsoleApp.serialization;
using System;
using static SIMS_Projekat_Bolnica_Zdravo.Controllers.RoomController;

namespace CrudModel
{
    public class Appointment : Serializable
    {
        private static int ids = -1;

        public Appointment()
        {

        }

        public int patientID
        {
            set;get;
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

        public int roomID
        {
            set;
            get;
        }
        public bool operation
        {
            get;
            set;
        }

        public Appointment(DateTime date, Time time, int duration, int roomID, int docID, string description, int patID, int MRid,bool operation)
        {
            this.medicalRecordID = MRid;
            this.patientID = patID;
            //this.medicalRecord.patientID = pat.userID;
            this.doctorID = docID;
            this.timeBegin = new DateTime(date.Year, date.Month, date.Day, time.hour, time.minute, 0);
            this.setDate();
            this.operation = operation;
            this.duration = duration;
            this.hour = time.hour;
            this.minute = time.minute;
            setTime();
            this.roomID = roomID;
            this.appointmentID = ++ids;
            this.description = description;
        }
        public Appointment(DateTime date, Time time, int duration, int roomID, int docID, string description, int patID, int MRid)
        {
            this.medicalRecordID = MRid;
            this.patientID = patID;
            //this.medicalRecord.patientID = pat.userID;
            this.doctorID = docID;
            this.timeBegin = new DateTime(date.Year, date.Month, date.Day, time.hour, time.minute, 0);
            this.setDate();
            this.duration = duration;
            this.hour = time.hour;
            this.minute = time.minute;
            setTime();
            this.roomID = roomID;
            this.appointmentID = ++ids;
            
            this.description = description;
            this.operation = false;
        }
        public Appointment(DateTime date, Time time, int duration, int roomID, int docID, string description, int patID)
        {
            //this.medicalRecord.patientID = pat.userID;
            this.doctorID = docID;
            this.timeBegin = new DateTime(date.Year, date.Month, date.Day, time.hour, time.minute, 0);
            this.setDate();
            this.duration = duration;
            this.hour = time.hour;
            this.minute = time.minute;
            this.patientID = patID;
            setTime();
            this.roomID = roomID;
            this.appointmentID = ++ids;
            this.description = description;
            this.operation = false;
        }


        public Appointment(DateTime date, int hour, int minute, int duration, Room room, Doctor doc, string description, Patient pat)
        {
            //this.medicalRecord = pat.medicalRecord;
            //this.medicalRecord.patientID = pat.userID;
            this.doctorID = doc.userID;
            this.patientID = pat.userID;
            this.timeBegin = date;
            this.setDate();
            this.duration = duration;
            this.hour = hour;
            this.minute = minute;
            setTime();
            this.roomID = room.roomID;
            this.appointmentID = ++ids;
            this.description = description;
            this.operation = false;
        }


        public void setDate()
        {
            this.date = timeBegin.Month.ToString() + "/" + timeBegin.Day.ToString() + "/" + timeBegin.Year.ToString();
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
            this.time = var5 + this.hour.ToString() + ":" + var6 + this.minute.ToString();
            this.time += " - " + var1 + var3;
            this.time += ":" + vars + var;
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                medicalRecordID.ToString(),
                doctorID.ToString(),
                timeBegin.Day.ToString(),
                timeBegin.Month.ToString(),
                timeBegin.Year.ToString(),
                duration.ToString(),
                hour.ToString(),
                minute.ToString(),
                roomID.ToString(),
                patientID.ToString(),
                description,
                appointmentID.ToString(),
                operation.ToString()
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            this.medicalRecordID = int.Parse(values[0]);
            this.doctorID = int.Parse(values[1]);
            this.timeBegin = new DateTime(int.Parse(values[4]), int.Parse(values[3]), int.Parse(values[2]));
            this.duration = int.Parse(values[5]);
            this.hour = int.Parse(values[6]);
            this.minute = int.Parse(values[7]);
            this.roomID = int.Parse(values[8]);
            this.patientID = int.Parse(values[9]);
            this.description = values[10];
            this.appointmentID = int.Parse(values[11]);
            this.operation = Convert.ToBoolean(values[12]);
            setTime();
            setDate(); 
        }


        /// <summary>
        /// Property for MedicalRecord
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public int medicalRecordID
        {
            set;
            get;
        }

        /// <summary>
        /// Property for Doctor
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        /// 
        public int doctorID
        {
            set;
            get;
        }
    }
}
//        public Doctor Doctor { 
//         get
//         {
//            return doctor;
//         }
//         set
//         {
//            if (this.doctor == null || !this.doctor.Equals(value))
//            {
//               if (this.doctor != null)
//               {
//                  Doctor oldDoctor = this.doctor;
//                  this.doctor = null;
//                  oldDoctor.RemoveAppointment(this);
//               }
//               if (value != null)
//               {
//                  this.doctor = value;
//                  this.doctor.AddAppointment(this);
//               }
//            }
//         }
//      }
   
//   }
//}