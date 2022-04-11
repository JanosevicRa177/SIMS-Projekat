
using ConsoleApp.serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CrudModel
{
   public class ManagerFileStorage
   {

        static public ObservableCollection<Manager> managerList
        {
            get;
            set;
        }
        public ManagerFileStorage()
        {
            if (managerList == null)
            {
                Serializer<Manager> managerSerializer = new Serializer<Manager>();
                managerList = managerSerializer.fromCSV("managers.txt");
            }
        }
        public bool CreateManager(Manager newManager)
      {
            managerList.Add(newManager);
            return true;
        }
      
      public bool DeleteManager(int userID)
      {
         throw new NotImplementedException();
      }
      
      public bool UpdateManager(Manager manager)
      {
         throw new NotImplementedException();
      }
      
      public static Manager GetManagerByID(int userID)
      {
            foreach (Manager m in managerList)
            {
                if (m.userID == userID) return m;
            }
            return null;
        }
      
      public ObservableCollection<Manager> GetAllManagers()
      {
            return managerList;
      }
   
   }
}