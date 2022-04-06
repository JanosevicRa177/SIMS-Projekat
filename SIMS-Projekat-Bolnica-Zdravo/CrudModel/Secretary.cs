using System;

namespace CrudModel
{
   public class Secretary : User
   {
      public System.Collections.Generic.List<Meeting> meeting;
      
      public System.Collections.Generic.List<Meeting> Meeting
      {
         get
         {
            if (meeting == null)
               meeting = new System.Collections.Generic.List<Meeting>();
            return meeting;
         }
         set
         {
            RemoveAllMeeting();
            if (value != null)
            {
               foreach (Meeting oMeeting in value)
                  AddMeeting(oMeeting);
            }
         }
      }
      
      
      public void AddMeeting(Meeting newMeeting)
      {
         if (newMeeting == null)
            return;
         if (this.meeting == null)
            this.meeting = new System.Collections.Generic.List<Meeting>();
         if (!this.meeting.Contains(newMeeting))
         {
            this.meeting.Add(newMeeting);
            newMeeting.Secretary = this;
         }
      }
      
      
      public void RemoveMeeting(Meeting oldMeeting)
      {
         if (oldMeeting == null)
            return;
         if (this.meeting != null)
            if (this.meeting.Contains(oldMeeting))
            {
               this.meeting.Remove(oldMeeting);
               oldMeeting.Secretary = null;
            }
      }
      
      
      public void RemoveAllMeeting()
      {
         if (meeting != null)
         {
            System.Collections.ArrayList tmpMeeting = new System.Collections.ArrayList();
            foreach (Meeting oldMeeting in meeting)
               tmpMeeting.Add(oldMeeting);
            meeting.Clear();
            foreach (Meeting oldMeeting in tmpMeeting)
               oldMeeting.Secretary = null;
            tmpMeeting.Clear();
         }
      }
   
   }
}