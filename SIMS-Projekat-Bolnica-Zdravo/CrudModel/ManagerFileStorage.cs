// File:    ManagerFileStorage.cs
// Author:  Dusan
// Created: Sunday, April 3, 2022 4:42:31 PM
// Purpose: Definition of Class ManagerFileStorage

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CrudModel
{
   public class ManagerFileStorage
   {

        static public ObservableCollection<CrudModel.Manager> managerList
        {
            get;
            set;
        }
        public ManagerFileStorage()
        {
            if (managerList == null)
            {
                managerList = new ObservableCollection<Manager>();
            }
        }
        public bool CreateManager(Manager newManager)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteManager(int userID)
      {
         throw new NotImplementedException();
      }
      
      public bool UpdateManager(Manager manager)
      {
         throw new NotImplementedException();
      }
      
      public Manager GetManagerByID(int userID)
      {
         throw new NotImplementedException();
      }
      
      public List<Manager> GetAllManagers()
      {
         throw new NotImplementedException();
      }
   
   }
}