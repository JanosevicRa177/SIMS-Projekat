// File:    SecretaryFileStorage.cs
// Author:  Dusan
// Created: Sunday, April 3, 2022 4:42:32 PM
// Purpose: Definition of Class SecretaryFileStorage

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CrudModel
{
   public class SecretaryFileStorage
   {
        
        static public ObservableCollection<Secretary> secretaryList
        {
            set;
            get;
        }

        public SecretaryFileStorage()
        {
            if (secretaryList == null)
            {
                secretaryList = new ObservableCollection<Secretary>();
                secretaryList.Add(new Secretary("Dragan", "Petrovic", "Dragan@gmail.com", "321",new Address("Serbia", "Novi Sad", "Slobodana Bajica", "5a"),"06987654321","Secretary"));

            }
        }
        public bool CreateSecretary(Secretary newSecretary)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteSecretary(int userID)
      {
         throw new NotImplementedException();
      }
      
      public bool UpdateSecretary(Secretary secretary)
      {
         throw new NotImplementedException();
      }
      
      public Secretary GetSecretaryrByID(int userID)
      {
         throw new NotImplementedException();
      }
      
      public List<Secretary> GetAllSecretaries()
      {
         throw new NotImplementedException();
      }
   
   }
}