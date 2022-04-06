using System;

namespace CrudModel
{
   public class Warehouse
   {
      public bool AddEquipment(int equipmentID)
      {
         throw new NotImplementedException();
      }
      
      public bool RemoveEquipment(int equipmentID)
      {
         throw new NotImplementedException();
      }
      
      public Equipment GetEquipmentByID(int equipmentID)
      {
         throw new NotImplementedException();
      }
      
      public int warehouseID;
      
      public System.Collections.Generic.List<Equipment> equipment;
      
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
      
      
      public void AddEquipment(Equipment newEquipment)
      {
         if (newEquipment == null)
            return;
         if (this.equipment == null)
            this.equipment = new System.Collections.Generic.List<Equipment>();
         if (!this.equipment.Contains(newEquipment))
            this.equipment.Add(newEquipment);
      }
      
      
      public void RemoveEquipment(Equipment oldEquipment)
      {
         if (oldEquipment == null)
            return;
         if (this.equipment != null)
            if (this.equipment.Contains(oldEquipment))
               this.equipment.Remove(oldEquipment);
      }
      
      
      public void RemoveAllEquipment()
      {
         if (equipment != null)
            equipment.Clear();
      }
   
   }
}