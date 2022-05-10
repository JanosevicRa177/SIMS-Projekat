// File:    VacationRequest.cs
// Author:  duros
// Created: Tuesday, May 10, 2022 7:39:56 PM
// Purpose: Definition of Class VacationRequest

using System;

namespace CrudModel
{
   public class VacationRequest
   {
      public DateTime startDate;
      public DateTime endDate;
      public StateEnum state;
      public int doctorID;
      public int id;
   
   }
}