// File:    SecretaryFileStorage.cs
// Author:  Dusan
// Created: Sunday, April 3, 2022 4:42:32 PM
// Purpose: Definition of Class SecretaryFileStorage

using System;
using System.Collections.Generic;

namespace CrudModel
{
   public class SecretaryFileStorage
   {

        static public List<Secretary> secretaryList = new List<Secretary>();
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