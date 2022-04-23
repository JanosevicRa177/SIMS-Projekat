// File:    Note.cs
// Author:  Dusan
// Created: Wednesday, April 6, 2022 12:08:33 PM
// Purpose: Definition of Class Note

using ConsoleApp.serialization;
using System;

namespace CrudModel
{
   public class Note : Serializable
    {
        private static int ids = -1;

        public static int getids ()
        {
            return ids;
        }
        public Note() 
        {
        }
        public static void setids(int set)
        {
            ids = set;
        }

        public string[] toCSV()
        {
            string[] csvValues =
{               noteName,
                noteContent,
                noteID.ToString(),
                patientID.ToString()
                };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            noteName = values[0];
            noteContent = values[1];
            noteID = int.Parse(values[2]);
            patientID = int.Parse(values[3]);
            NoteFileStorage.noteList.Add(this);
        }

        public Note(String noteName,String noteContent) 
        {
            this.noteContent = noteContent;
            this.noteName = noteName;
            this.noteID = ++ids;
        }
      public String noteContent
        {
            set;
            get;
        }
        public String noteName
        {
            set;
            get;
        }
        public int patientID
        {
            get;
            set;
        }
        public int noteID
        {
            set;
            get;
        }

    }
}