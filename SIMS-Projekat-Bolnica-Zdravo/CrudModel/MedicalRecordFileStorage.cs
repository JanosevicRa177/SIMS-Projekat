// File:    MedicalRecordFileStorage.cs
// Author:  Dusan
// Created: Sunday, April 3, 2022 8:06:22 PM
// Purpose: Definition of Class MedicalRecordFileStorage

using ConsoleApp.serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CrudModel
{
   public class MedicalRecordFileStorage
   {
        static public ObservableCollection<MedicalRecord> medicalRecordList
        {
            set;
            get;
        }
        public MedicalRecordFileStorage()
        {
            if (medicalRecordList == null)
            {
                medicalRecordList = new ObservableCollection<MedicalRecord>();
                Serializer<MedicalRecord> medicalRecordSerializer = new Serializer<MedicalRecord>();
                medicalRecordList = medicalRecordSerializer.fromCSV("medicalRecords.txt");
            }
        }
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
      
      public static MedicalRecord GetMedicalRecordByID(int medicalRecordID)
      {
         foreach (MedicalRecord mr in medicalRecordList)
            {
                if (mr.medicalRecordID == medicalRecordID) return mr;
            }
            return null;
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