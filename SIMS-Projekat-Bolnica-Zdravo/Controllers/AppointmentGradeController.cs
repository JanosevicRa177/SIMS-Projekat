// File:    AppointmentGradeController.cs
// Author:  duros
// Created: Tuesday, May 10, 2022 9:05:35 PM
// Purpose: Definition of Class AppointmentGradeController

using System;
using System.Collections.Generic;

namespace CrudModel
{
   public class AppointmentGradeController
   {
        private AppointmentGradeService AGS;
        public AppointmentGradeController() 
        {
            AGS = new AppointmentGradeService();
        }
        public bool CreateAppointmentGrade(AppointmentGrade appointmentGrade)
        {
            return AGS.CreateAppointmentGrade(appointmentGrade);
        }
      
        public AppointmentGrade GetAppointmentGradeById(int appGID)
        {
           throw new NotImplementedException();
        }

        public List<AppointmentGrade> GetAppointmentGradeByAppId(int appoId)
        {
            throw new NotImplementedException();
        }
   }
}