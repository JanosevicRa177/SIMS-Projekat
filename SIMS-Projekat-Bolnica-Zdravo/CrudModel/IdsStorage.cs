﻿using ConsoleApp.serialization;
using CrudModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CrudModel
{
    class IdsStorage : Serializable
    {
        private int appointmentsids;
        private int userids;
        private int medicalRecordids;
        private int Meetingsids;
        private int noteids;
        private int roomids;
        private int warehousids;
        private int appointmentNotificationids;

        public static ObservableCollection<IdsStorage> IDS;
        public IdsStorage()
        {
            appointmentsids = Appointment.getids();
            userids = User.getids();
            medicalRecordids = MedicalRecord.getids();
            Meetingsids = Meeting.getids();
            noteids = Note.getids();
            roomids = Room.getids();
            warehousids = Warehouse.getids();
            appointmentNotificationids = AppointmentNotification.getids();
            IDS = new ObservableCollection<IdsStorage>();
            IDS.Add(this);
        }

        public void fromCSV(string[] values)
        {
            appointmentsids = int.Parse(values[0]);
            userids = int.Parse(values[1]);
            medicalRecordids = int.Parse(values[2]);
            Meetingsids = int.Parse(values[3]);
            noteids = int.Parse(values[4]);
            roomids = int.Parse(values[5]);
            warehousids = int.Parse(values[6]);
            appointmentNotificationids = int.Parse(values[7]);
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                appointmentsids.ToString(),
                userids.ToString(),
                medicalRecordids.ToString(),
                Meetingsids.ToString(),
                noteids.ToString(),
                roomids.ToString(),
                warehousids.ToString(),
                appointmentNotificationids.ToString()
            };
            return csvValues;
        }

        public void setALLIDS()
        {
            Appointment.setids(appointmentsids);
            User.setids(userids);
            MedicalRecord.setids(medicalRecordids);
            Meeting.setids(Meetingsids);
            Note.setids(noteids);
            Room.setids(roomids);
            Warehouse.setids(warehousids);
            AppointmentNotification.setids(appointmentNotificationids);
        }
    }
}