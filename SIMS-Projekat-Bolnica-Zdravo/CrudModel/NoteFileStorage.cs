// File:    NoteFileStorage.cs
// Author:  Dusan
// Created: Wednesday, April 6, 2022 12:11:56 PM
// Purpose: Definition of Class NoteFileStorage

using System;
using System.Collections.Generic;

namespace CrudModel
{
   public class NoteFileStorage
   {

        static public List<Note> noteList = new List<Note>();
      public bool CreateNote(Note newNote)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteNote(int noteID)
      {
         throw new NotImplementedException();
      }
      
      public bool UpdateNote(Note note)
      {
         throw new NotImplementedException();
      }
      
      public Note GetNoteByID(int noteID)
      {
         throw new NotImplementedException();
      }
      
      public List<Note> GetAllNotes()
      {
         throw new NotImplementedException();
      }
      
      public List<Note> GetAllNotesByPatient(int patientID)
      {
         throw new NotImplementedException();
      }
   
   }
}