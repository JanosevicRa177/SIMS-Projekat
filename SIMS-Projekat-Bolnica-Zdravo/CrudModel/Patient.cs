// File:    Patient.cs
// Author:  Dusan
// Created: Wednesday, March 30, 2022 4:13:07 PM
// Purpose: Definition of Class Patient

using System;

namespace CrudModel
{
    public class Patient : User
    {

        
        public Patient(Gender gender, string name, string surname, Address address, string password, string mobilePhone, string mail) : base(name,surname,address,password,mobilePhone,mail)
        {
            this.userID = User.generateID();
            this.gender = gender;
        }

        public Gender gender
        {
            set;
            get;
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