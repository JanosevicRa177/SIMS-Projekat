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
        static public List<Specialization> specializationList
        {
            set;
            get;
        }

        public SpecializationFileStorage()
        {
            if (specializationList == null)
            {
                specializationList = new List<Specialization>();
                Specialization sp = new Specialization("No specialization");
                specializationList.Add(sp);
                sp = new Specialization("Kardiohirurg");
                specializationList.Add(sp);
            }
        }
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