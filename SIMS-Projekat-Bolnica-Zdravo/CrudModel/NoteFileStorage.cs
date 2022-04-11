// File:    NoteFileStorage.cs
// Author:  Dusan
// Created: Wednesday, April 6, 2022 12:11:56 PM
// Purpose: Definition of Class NoteFileStorage

using ConsoleApp.serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CrudModel
{
   public class NoteFileStorage
   {

        static public ObservableCollection<Note> noteList
        {
            set;
            get;
        }
        public NoteFileStorage() 
        {
            if (noteList == null) 
            {
                noteList = new ObservableCollection<Note>();
                Serializer<Note> noteSerializer = new Serializer<Note>();
                noteList = noteSerializer.fromCSV("notes.txt");
            }
        }
        public bool CreateNote(Note newNote)
      {
         throw new NotImplementedException();
      }
      
      public static bool DeleteNote(Note oldNote)
      {
            if (oldNote == null)
                return false;
            if (noteList != null)
                if (noteList.Contains(oldNote))
                    noteList.Remove(oldNote);
            return true;
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