// File:    RoomFileStorage.cs
// Author:  Dusan
// Created: Sunday, April 3, 2022 7:50:52 PM
// Purpose: Definition of Class RoomFileStorage

using System;
using System.Collections.Generic;

namespace CrudModel
{
   public class RoomFileStorage
   {
        static public List<Room> roomList = new List<Room>();
      public bool CreateRoom(Room newRoom)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteRoom(int roomID)
      {
         throw new NotImplementedException();
      }
      
      public bool UpdateRoom(Room room)
      {
         throw new NotImplementedException();
      }
      
      public Room GetRoomByID(int roomID)
      {
         throw new NotImplementedException();
      }
      
      public List<Room> GetAllRooms()
      {
         throw new NotImplementedException();
      }
   
   }
}