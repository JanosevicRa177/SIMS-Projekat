// File:    Specialization.cs
// Author:  Dusan
// Created: Monday, April 4, 2022 5:50:25 PM
// Purpose: Definition of Class Specialization

using System;

namespace CrudModel
{
   public class Specialization
   {
        public Specialization(string spec)
        {
            this.specialization = spec;
        }
      public string specialization
        {
            set;
            get;
        }

    }
}