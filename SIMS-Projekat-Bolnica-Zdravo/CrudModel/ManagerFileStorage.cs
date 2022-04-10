
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
                managerList = new ObservableCollection<Manager>();
                Manager m = new Manager("Hana", "Smithr", new Address("Serbia", "Novi Sad", "Gogoljeva", "12"), "password123", "0654320234", "hanasmithr@gmail.com");
                managerList.Add(m);
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