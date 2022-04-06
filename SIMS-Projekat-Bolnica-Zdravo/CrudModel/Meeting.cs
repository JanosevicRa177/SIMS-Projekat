using System;

namespace CrudModel
{
   public class Meeting
   {
      public DateTime timeBegin;
      public int duration;
      public int meetingID;
      
      public System.Collections.Generic.List<Room> room;
      
      public System.Collections.Generic.List<Room> Room
      {
         get
         {
            if (room == null)
               room = new System.Collections.Generic.List<Room>();
            return room;
         }
         set
         {
            RemoveAllRoom();
            if (value != null)
            {
               foreach (Room oRoom in value)
                  AddRoom(oRoom);
            }
         }
      }
      
      
      public void AddRoom(Room newRoom)
      {
         if (newRoom == null)
            return;
         if (this.room == null)
            this.room = new System.Collections.Generic.List<Room>();
         if (!this.room.Contains(newRoom))
         {
            this.room.Add(newRoom);
            newRoom.Meeting = this;
         }
      }
      
      
      public void RemoveRoom(Room oldRoom)
      {
         if (oldRoom == null)
            return;
         if (this.room != null)
            if (this.room.Contains(oldRoom))
            {
               this.room.Remove(oldRoom);
               oldRoom.Meeting = null;
            }
      }
      
      
      public void RemoveAllRoom()
      {
         if (room != null)
         {
            System.Collections.ArrayList tmpRoom = new System.Collections.ArrayList();
            foreach (Room oldRoom in room)
               tmpRoom.Add(oldRoom);
            room.Clear();
            foreach (Room oldRoom in tmpRoom)
               oldRoom.Meeting = null;
            tmpRoom.Clear();
         }
      }
      public Doctor required to come;
      
      
      public Doctor Required to come
      {
         get
         {
            return required to come;
         }
         set
         {
            this.required to come = value;
         }
      }
      public Doctor invited doctor;
      
      
      public Doctor Invited doctor
      {
         get
         {
            return invited doctor;
         }
         set
         {
            this.invited doctor = value;
         }
      }
      public Secretary secretary;
      
      
      public Secretary Secretary
      {
         get
         {
            return secretary;
         }
         set
         {
            if (this.secretary == null || !this.secretary.Equals(value))
            {
               if (this.secretary != null)
               {
                  Secretary oldSecretary = this.secretary;
                  this.secretary = null;
                  oldSecretary.RemoveMeeting(this);
               }
               if (value != null)
               {
                  this.secretary = value;
                  this.secretary.AddMeeting(this);
               }
            }
         }
      }
   
   }
}