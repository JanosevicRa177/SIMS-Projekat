// File:    Room.cs
// Author:  Dusan
// Created: Wednesday, March 30, 2022 4:13:43 PM
// Purpose: Definition of Class Room

using System;

namespace CrudModel
{
   public class Room
   {
        private static int ids = -1;
        public Room(string name)
        {
            this.name = name;
            roomID = ++ids;
        }
        
        public string name
        {
            set;
            get;
        }
      public bool AddEquipment()
      {
         throw new NotImplementedException();
      }
      
      public bool RemoveEquipment()
      {
         throw new NotImplementedException();
      }
      
      public Equipment GetEquipmentByID()
      {
         throw new NotImplementedException();
      }
      
      public int roomID
        {
            set;
            get;
        }

        public System.Collections.Generic.List<Equipment> equipment
        {
            set;
            get;
        }

        /// <summary>
        /// Property for collection of Equipment
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<Equipment> Equipment
      {
         get
         {
            if (equipment == null)
               equipment = new System.Collections.Generic.List<Equipment>();
            return equipment;
         }
         set
         {
            RemoveAllEquipment();
            if (value != null)
            {
               foreach (Equipment oEquipment in value)
                  AddEquipment(oEquipment);
            }
         }
      }
      
      /// <summary>
      /// Add a new Equipment in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddEquipment(Equipment newEquipment)
      {
         if (newEquipment == null)
            return;
         if (this.equipment == null)
            this.equipment = new System.Collections.Generic.List<Equipment>();
         if (!this.equipment.Contains(newEquipment))
            this.equipment.Add(newEquipment);
      }
      
      /// <summary>
      /// Remove an existing Equipment from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveEquipment(Equipment oldEquipment)
      {
         if (oldEquipment == null)
            return;
         if (this.equipment != null)
            if (this.equipment.Contains(oldEquipment))
               this.equipment.Remove(oldEquipment);
      }
      
      /// <summary>
      /// Remove all instances of Equipment from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllEquipment()
      {
         if (equipment != null)
            equipment.Clear();
      }
   
   }
}