using System;

namespace CrudModel
{
   public class MedicalRecord
   {
      public int medicalRecordID
        {
            set;
            get;
        }
        public int bloodType
        {
            set;
            get;
        }

        public System.Collections.Generic.List<Appointment> appointment;
      
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
            newAppointment.MedicalRecord = this;
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
               oldAppointment.MedicalRecord = null;
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
               oldAppointment.MedicalRecord = null;
            tmpAppointment.Clear();
         }
      }
   
   }
}