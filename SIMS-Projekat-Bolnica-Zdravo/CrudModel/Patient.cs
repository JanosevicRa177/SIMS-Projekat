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

        public MedicalRecord medicalRecord
        {
            set;
            get;
        }
        public System.Collections.Generic.List<Note> note
        {
            set;
            get;
        }

        /// <summary>
        /// Property for collection of Note
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<Note> Note
      {
         get
         {
            if (note == null)
               note = new System.Collections.Generic.List<Note>();
            return note;
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
      
      /// <summary>
      /// Add a new Note in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddNote(Note newNote)
      {
         if (newNote == null)
            return;
         if (this.note == null)
            this.note = new System.Collections.Generic.List<Note>();
         if (!this.note.Contains(newNote))
            this.note.Add(newNote);
      }
      
      /// <summary>
      /// Remove an existing Note from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveNote(Note oldNote)
      {
         if (oldNote == null)
            return;
         if (this.note != null)
            if (this.note.Contains(oldNote))
               this.note.Remove(oldNote);
      }
      
      /// <summary>
      /// Remove all instances of Note from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllNote()
      {
         if (note != null)
            note.Clear();
      }
   
   }
}