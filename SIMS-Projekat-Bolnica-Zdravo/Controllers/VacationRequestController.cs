// File:    VacationRequestController.cs
// Author:  duros
// Created: Tuesday, May 10, 2022 8:59:56 PM
// Purpose: Definition of Class VacationRequestController
using System.Collections.Generic;
using System;

namespace CrudModel
{
   public class VacationRequestController
   {
      public bool CreateVacationRequest(VacationRequest crVR)
      {
         throw new NotImplementedException();
      }
      
      public VacationRequest GetVacationRequestById(int userID)
      {
         throw new NotImplementedException();
      }
      
      public List<VacationRequest> GetAllVacationRequestsByDoctorId(int doctorID)
      {
         throw new NotImplementedException();
      }
      
      public VacationRequestService vacationRequestService;
   
   }
}