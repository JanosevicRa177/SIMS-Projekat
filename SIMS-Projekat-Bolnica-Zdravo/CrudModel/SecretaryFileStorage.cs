// File:    SecretaryFileStorage.cs
// Author:  Dusan
// Created: Sunday, April 3, 2022 4:42:32 PM
// Purpose: Definition of Class SecretaryFileStorage

using ConsoleApp.serialization;
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
                Serializer<Secretary> secretarySerializer = new Serializer<Secretary>();
                secretaryList = secretarySerializer.fromCSV("secretary.txt"); 
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