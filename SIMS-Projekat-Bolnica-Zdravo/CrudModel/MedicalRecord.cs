// File:    MedicalRecord.cs
// Author:  Dusan
// Created: Wednesday, March 30, 2022 4:38:07 PM
// Purpose: Definition of Class MedicalRecord

using System;

namespace CrudModel
{
    public class MedicalRecord
    {
        public static int ids = -1;
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
        public Patient patient
        {
            set;
            get;
        }

    }
}