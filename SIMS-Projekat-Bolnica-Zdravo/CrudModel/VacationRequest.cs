// File:    VacationRequest.cs
// Author:  duros
// Created: Tuesday, May 10, 2022 7:39:56 PM
// Purpose: Definition of Class VacationRequest

using ConsoleApp.serialization;
using SIMS_Projekat_Bolnica_Zdravo.Windows;
using System;

namespace CrudModel
{
   public class VacationRequest : Serializable
    {
        private static int ids;
        public VacationRequest(DateTime startDate, DateTime endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.state = StateEnum.waiting;
            this.doctorID = DoctorWindow.loggedDoc;
            this.id = ids++;
        }
        public static int getids()
        {
            return ids;
        }

        public static void setids(int set)
        {
            ids = set;
        }

        public DateTime startDate
        {
            set;
            get;
        }
      public DateTime endDate
        {
            set;
            get;
        }
        public StateEnum state
        {
            set;
            get;
        }
        public int doctorID
        {
            set;
            get;
        }
        public int id
        {
            set;
            get;
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                name,
                surname,
                address.country,
                address.city,
                address.street,
                address.number,
                password,
                mobilePhone,
                mail,
                userID.ToString()
            };
            return csvValues;
        }

        public void fromCSV(string[] values)
        {
            name = values[0];
            surname = values[1];
            address.country = values[2];
            address.city = values[3];
            address.street = values[4];
            address.number = values[5];
            password = values[6];
            mobilePhone = values[7];
            mail = values[8];
            userID = int.Parse(values[9]);
        }

    }
}