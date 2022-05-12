// File:    VacationRequesFileStorage.cs
// Author:  duros
// Created: Tuesday, May 10, 2022 8:59:57 PM
// Purpose: Definition of Class VacationRequesFileStorage
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using ConsoleApp.serialization;

namespace CrudModel
{
   public class VacationRequesFileStorage
   {
      public bool CreateVacationRequest(VacationRequest crVR)
      {
            ObservableCollection<VacationRequest> patients = new ObservableCollection<VacationRequest>();
            Serializer<VacationRequest> patientSerializer = new Serializer<VacationRequest>();
            foreach (VacationRequest p in patientSerializer.fromCSV("../../TxtFajlovi/vacationrequests.txt"))
            {
                patients.Add(p);
            }
            patients.Add(crVR);
            patientSerializer.toCSV("../../TxtFajlovi/vacationrequests.txt", patients);
            return true;
      }

        public VacationRequest GetVacationRequestById(int userID)
      {
         throw new NotImplementedException();
      }
      
      public ObservableCollection<VacationRequest> GetAllVacationRequestsByDoctorId(int doctorID)
      {
            ObservableCollection<VacationRequest> vacreq = new ObservableCollection<VacationRequest>();
            Serializer<VacationRequest> patientSerializer = new Serializer<VacationRequest>();
            foreach (VacationRequest p in patientSerializer.fromCSV("../../TxtFajlovi/vacationrequests.txt"))
            {
                if(p.doctorID == doctorID)
                    vacreq.Add(p);
            }
            return vacreq;
       }

        public ObservableCollection<VacationRequest> GetAllVacationRequests()
        {
            ObservableCollection<VacationRequest> vacreq = new ObservableCollection<VacationRequest>();
            Serializer<VacationRequest> patientSerializer = new Serializer<VacationRequest>();
            foreach (VacationRequest p in patientSerializer.fromCSV("../../TxtFajlovi/vacationrequests.txt"))
            {
                vacreq.Add(p);
            }
            return vacreq;
        }

    }
}