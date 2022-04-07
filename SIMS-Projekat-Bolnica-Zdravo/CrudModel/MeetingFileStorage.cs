// File:    MeetingFileStorage.cs
// Author:  Dusan
// Created: Sunday, April 3, 2022 7:55:27 PM
// Purpose: Definition of Class MeetingFileStorage

using System;
using System.Collections.Generic;

namespace CrudModel
{
   public class MeetingFileStorage
   {
        static public List<Meeting> meetingList = new List<Meeting>();
      public bool CreateMeeting(Meeting newMeeting)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteMeeting(int meetingID)
      {
         throw new NotImplementedException();
      }
      
      public bool UpdateMeeting(Meeting meeting)
      {
         throw new NotImplementedException();
      }
      
      public Meeting GetMeetingByID(int meetingID)
      {
         throw new NotImplementedException();
      }
      
      public List<Meeting> GetAllMeeting()
      {
         throw new NotImplementedException();
      }
   
   }
}