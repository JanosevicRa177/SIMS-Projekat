using ConsoleApp.serialization;
using CrudModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudModel
{
    class IdsStorage
    {
        public static ObservableCollection<Ids> IDS
        {
            get;
            set;
        }
        public IdsStorage()
        {
            if (IDS == null)
            {
                Serializer<Ids> appoitmentSerializer = new Serializer<Ids>();
                IDS = appoitmentSerializer.fromCSV("../../TxtFajlovi/ids.txt");
            }
            else 
            {
                IDS.Clear();
                Ids i = new Ids("Temp");
                IDS.Add(i);
            }
        }
    }
    class Ids : Serializable
    {
        private int appointmentsids { get; set; }
        private int userids { get; set; }
        private int medicalRecordids { get; set; }
        private int Meetingsids { get; set; }
        private int noteids { get; set; }
        private int roomids { get; set; }
        private int warehousids { get; set; }
        public Ids(String temp)
        {
            appointmentsids = Appointment.getids();
            userids = User.getids();
            medicalRecordids = MedicalRecord.getids();
            Meetingsids = Meeting.getids();
            noteids = Note.getids();
            roomids = Room.getids();
            warehousids = Warehouse.getids();
        }
        public Ids() 
        {
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
        }
    }
}

