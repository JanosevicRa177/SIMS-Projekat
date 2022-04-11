// File:    Note.cs
// Author:  Dusan
// Created: Wednesday, April 6, 2022 12:08:33 PM
// Purpose: Definition of Class Note

using System;

namespace CrudModel
{
   public class Note
   {
        private static int ids = -1;

        public static int getids ()
        {
            return ids;
        }

        public static void setids(int set)
        {
            ids = set;
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
        public int noteID
        {
            set;
            get;
        }

    }
}