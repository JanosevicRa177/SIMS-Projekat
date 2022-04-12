// File:    RoomFileStorage.cs
// Author:  Dusan
// Created: Sunday, April 3, 2022 7:50:52 PM
// Purpose: Definition of Class RoomFileStorage

using ConsoleApp.serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CrudModel
{
   public class RoomFileStorage
   {
        public static ObservableCollection<Room> roomList
        {
            set;
            get;
        }

        public RoomFileStorage()
        {
            if (roomList == null)
            {
                roomList = new ObservableCollection<Room>();
                Serializer<Room> patientSerializer = new Serializer<Room>();
                roomList = patientSerializer.fromCSV("room.txt");
            }
        }
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
      
      public static Room GetRoomByID(int ID)
      {
         foreach(Room r in roomList)
            {
                if (r.roomID == ID)
                    return r;
            }
            return null;
      }
      
      public List<Room> GetAllRooms()
      {
         throw new NotImplementedException();
      }
   
   }
}