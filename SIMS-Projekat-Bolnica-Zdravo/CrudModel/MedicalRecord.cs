// File:    MedicalRecord.cs
// Author:  Dusan
// Created: Wednesday, March 30, 2022 4:38:07 PM
// Purpose: Definition of Class MedicalRecord

using ConsoleApp.serialization;
using System;

namespace CrudModel
{
    public class MedicalRecord: Serializable
    {
        private static int ids = -1;

        public static int getids()
        {
            return ids;
        }

        public static void setids(int set)
        {
            ids = set;
        }
        public int medicalRecordID
        {
            set;
            get;
        }
        public BloodType bloodType
        {
            set;
            get;
        }
        public MedicalRecord(BloodType bloodType)
        {
            medicalRecordID = ++ids;
            this.bloodType = bloodType;
        }
        public MedicalRecord()
        { 
        }
        public System.Collections.Generic.List<Appointment> appointment
        {
            set;
            get;
        }

        public System.Collections.Generic.List<Appointment> Appointment
        {
            get
            {
                if (appointment == null)
                    appointment = new System.Collections.Generic.List<Appointment>();
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

        public void AddAppointment(Appointment newAppointment)
        {
            if (newAppointment == null)
                return;
            if (this.appointment == null)
                this.appointment = new System.Collections.Generic.List<Appointment>();
            if (!this.appointment.Contains(newAppointment))
            {
                this.appointment.Add(newAppointment);
                newAppointment.medicalRecord = this;
            }
        }

        public void RemoveAppointment(Appointment oldAppointment)
        {
            if (oldAppointment == null)
                return;
            if (this.appointment != null)
                if (this.appointment.Contains(oldAppointment))
                {
                    this.appointment.Remove(oldAppointment);
                    oldAppointment.medicalRecord = null;
                }
        }

        public void RemoveAllAppointment()
        {
            if (appointment != null)
            {
                System.Collections.ArrayList tmpAppointment = new System.Collections.ArrayList();
                foreach (Appointment oldAppointment in appointment)
                    tmpAppointment.Add(oldAppointment);
                appointment.Clear();
                foreach (Appointment oldAppointment in tmpAppointment)
                    oldAppointment.medicalRecord = null;
                tmpAppointment.Clear();
            }
        }

        public string[] toCSV()
        {
            if (bloodType.Equals(BloodType.a))
            {
                string[] csvValues =
                {
                    medicalRecordID.ToString(),
                    patient.userID.ToString(),
                    "a-"
                };
                return csvValues;
            }
            else if(bloodType.Equals(BloodType.a1))
            {
                string[] csvValues =
                {
                    medicalRecordID.ToString(),
                    patient.userID.ToString(),
                    "a+"
                };
                return csvValues;
            }
            else if(bloodType.Equals(BloodType.b))
            {
                string[] csvValues =
                {
                    medicalRecordID.ToString(),
                    patient.userID.ToString(),
                    "b-"
                };
                return csvValues;
            }
            else if(bloodType.Equals(BloodType.b1))
            {
                string[] csvValues =
                {
                    medicalRecordID.ToString(),
                    patient.userID.ToString(),
                    "b+"
                };
                return csvValues;
            }
            else if(bloodType.Equals(BloodType.ab))
            {
                string[] csvValues =
                {
                    medicalRecordID.ToString(),
                    patient.userID.ToString(),
                    "ab-"
                };
                return csvValues;
            }
            else if(bloodType.Equals(BloodType.ab1))
            {
                string[] csvValues =
                {
                    medicalRecordID.ToString(),
                    patient.userID.ToString(),
                    "ab+"
                };
                return csvValues;
            }
            else if(bloodType.Equals(BloodType.o))
            {
                string[] csvValues =
                {
                    medicalRecordID.ToString(),
                    patient.userID.ToString(),
                    "o-"
                };
                return csvValues;
            }
            else if(bloodType.Equals(BloodType.o1))
            {
                string[] csvValues =
                {
                    medicalRecordID.ToString(),
                    patient.userID.ToString(),
                    "o+"
                };
                return csvValues;
            }
            else
            return null;
        }

        public void fromCSV(string[] values)
        {

            if (values[2].Equals("a-"))
            {
                medicalRecordID = int.Parse(values[0]);
                Patient p = PatientFileStorage.GetPatientByID(int.Parse(values[1]));
                patient = p;
                p.medicalRecord = this;
                MedicalRecordFileStorage.medicalRecordList.Add(this);
                bloodType = BloodType.a;
            }
            else if (values[2].Equals("a+"))
            {
                medicalRecordID = int.Parse(values[0]);
                Patient p = PatientFileStorage.GetPatientByID(int.Parse(values[1]));
                patient = p;
                p.medicalRecord = this;
                MedicalRecordFileStorage.medicalRecordList.Add(this);
                bloodType = BloodType.a1;
            }
            else if (values[2].Equals("b-"))
            {
                medicalRecordID = int.Parse(values[0]);
                Patient p = PatientFileStorage.GetPatientByID(int.Parse(values[1]));
                patient = p;
                p.medicalRecord = this;
                MedicalRecordFileStorage.medicalRecordList.Add(this);
                bloodType = BloodType.b;
            }
            else if (values[2].Equals("b+"))
            {
                medicalRecordID = int.Parse(values[0]);
                Patient p = PatientFileStorage.GetPatientByID(int.Parse(values[1]));
                patient = p;
                p.medicalRecord = this;
                MedicalRecordFileStorage.medicalRecordList.Add(this);
                bloodType = BloodType.b1;
            }
            else if (values[2].Equals("ab-"))
            {
                medicalRecordID = int.Parse(values[0]);
                Patient p = PatientFileStorage.GetPatientByID(int.Parse(values[1]));
                patient = p;
                p.medicalRecord = this;
                MedicalRecordFileStorage.medicalRecordList.Add(this);
                bloodType = BloodType.ab;
            }
            else if (values[2].Equals("ab+"))
            {
                medicalRecordID = int.Parse(values[0]);
                Patient p = PatientFileStorage.GetPatientByID(int.Parse(values[1]));
                patient = p;
                p.medicalRecord = this;
                MedicalRecordFileStorage.medicalRecordList.Add(this);
                bloodType = BloodType.ab1;
            }
            else if (values[2].Equals("o-"))
            {
                medicalRecordID = int.Parse(values[0]);
                Patient p = PatientFileStorage.GetPatientByID(int.Parse(values[1]));
                patient = p;
                p.medicalRecord = this;
                MedicalRecordFileStorage.medicalRecordList.Add(this);
                bloodType = BloodType.o;
            }
            else if (values[2].Equals("o+"))
            {
                medicalRecordID = int.Parse(values[0]);
                Patient p = PatientFileStorage.GetPatientByID(int.Parse(values[1]));
                patient = p;
                p.medicalRecord = this;
                MedicalRecordFileStorage.medicalRecordList.Add(this);
                bloodType = BloodType.o1;
            }
        }

        public Patient patient
        {
            set;
            get;
        }

    }
}