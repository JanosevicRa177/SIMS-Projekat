// File:    SpecializationFileStorage.cs
// Author:  Dusan
// Created: Monday, April 4, 2022 5:59:50 PM
// Purpose: Definition of Class SpecializationFileStorage

using System;
using System.Collections.Generic;

namespace CrudModel
{
   public class SpecializationFileStorage
   {
        static public List<Specialization> specializationList = new List<Specialization>();
      public bool CreateSpecialization(Specialization newSpecialization)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteSpecialization(Specialization specialization)
      {
         throw new NotImplementedException();
      }
      
      public List<Specialization> GetAllSpecialization()
      {
         throw new NotImplementedException();
      }
   
   }
}