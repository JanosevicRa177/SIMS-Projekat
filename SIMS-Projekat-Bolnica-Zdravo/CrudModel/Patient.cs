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
        public int sexType
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
      
      
      public void AddNote(Note newNote)
      {
         if (newNote == null)
            return;
         if (this.note == null)
            this.note = new System.Collections.Generic.List<Note>();
         if (!this.note.Contains(newNote))
            this.note.Add(newNote);
      }
      
      
      public void RemoveNote(Note oldNote)
      {
         if (oldNote == null)
            return;
         if (this.note != null)
            if (this.note.Contains(oldNote))
               this.note.Remove(oldNote);
      }
      
      
      public void RemoveAllNote()
      {
         if (note != null)
            note.Clear();
      }
   
   }
}