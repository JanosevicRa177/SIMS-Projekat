// File:    MedicalRecordFileStorage.cs
// Author:  Dusan
// Created: Sunday, April 3, 2022 8:06:22 PM
// Purpose: Definition of Class MedicalRecordFileStorage

using System;
using System.Collections.Generic;

namespace CrudModel
{
   public class MedicalRecordFileStorage
   {
        List<MedicalRecord> medicalRecordList;
      public bool CreateMedicalRecord(MedicalRecord newMedicalRecord)
      {
         throw new NotImplementedException();
      }
      
      public bool DeleteMedicalRecord(int medicalRecordID)
      {
         throw new NotImplementedException();
      }
      
      public bool UpdateMedicalRecord(MedicalRecord medicalRecord)
      {
         throw new NotImplementedException();
      }
      
      public MedicalRecord GetMedicalRecordByID(int medicalRecordID)
      {
         throw new NotImplementedException();
      }
      
      public List<MedicalRecord> GetAllMedicalRecord()
      {
         throw new NotImplementedException();
      }
      
      public List<MedicalRecord> GetMedicalRecordByDoctor(int doctorID)
      {
         throw new NotImplementedException();
      }
      
      public List<MedicalRecord> GetMedicalRecordByPatient(int patientID)
      {
         throw new NotImplementedException();
      }
   
   }
}