// File:    Patient.cs
// Author:  Dusan
// Created: Wednesday, March 30, 2022 4:13:07 PM
// Purpose: Definition of Class Patient

using System;

namespace CrudModel
{
   public class Patient : User
   {
        

      public int personalInsuranceNumber
        {
            set;
            get;
        }
        public Gender gender
        {
            set;
            get;
        }
        static int ids = -1;
        public Patient(String name, String surname, Address address, String password,
            String mobilePhone, String mail,Gender gender, int personalInsuranceNumber)
        {
            userID = ++ids;
            this.name = name;
            this.surname = surname;
            this.address = address;
            this.password = password;
            this.mobilePhone = mobilePhone;
            this.mail = mail;
            this.gender = gender;
            this.personalInsuranceNumber = personalInsuranceNumber;
        }
        public MedicalRecord medicalRecord
        {
            set;
            get;
        }
        public System.Collections.Generic.List<Note> notes
        {
            set;
            get;
        }

        public System.Collections.Generic.List<Note> Notes
      {
         get
         {
            if (notes == null)
               notes = new System.Collections.Generic.List<Note>();
            return notes;
         }
         set
         {
            RemoveAllNote();
            if (value != null)
            {
               foreach (Note oNote in value)
                  AddNote(oNote);
            }
         }
      }
      
      public void AddNote(Note newNote)
      {
         if (newNote == null)
            return;
         if (this.notes == null)
            this.notes = new System.Collections.Generic.List<Note>();
         if (!this.notes.Contains(newNote))
            this.notes.Add(newNote);
      }
      
      public void RemoveNote(Note oldNote)
      {
         if (oldNote == null)
            return;
         if (this.notes != null)
            if (this.notes.Contains(oldNote))
               this.notes.Remove(oldNote);
      }
      public void RemoveAllNote()
      {
         if (notes != null)
            notes.Clear();
      }
   
   }
}