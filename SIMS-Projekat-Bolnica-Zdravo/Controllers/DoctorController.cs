using CrudModel;
using SIMS_Projekat_Bolnica_Zdravo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SIMS_Projekat_Bolnica_Zdravo.Controllers
{
    class DoctorController
    {
        private DoctorService DS;

        public DoctorController()
        {
            DS = new DoctorService();
        }

        //public void addAppointmentToDoctor(int newAppID,DoctorCrAppDTO dcadto)
        //{
        //    DS.addAppointmentToDoctor(newAppID, dcadto.id);
        //}

        public int calculateMaxDur(int dur, Time time, BindingList<Time> tims)
        {
            return DS.calculateMaxDur(dur, time.ID ,tims);
        }

        public ObservableCollection<DoctorCrAppDTO> getAllDoctorsDTO()
        {
            ObservableCollection<Doctor> doctors = DS.getAllDoctors();
            ObservableCollection<DoctorCrAppDTO> docdto = new ObservableCollection<DoctorCrAppDTO>();
            foreach (Doctor d in doctors)
            {
                docdto.Add(new DoctorCrAppDTO(d.name, d.surname, d.userID));
            }
            return docdto;
        }
        public DoctorCrAppDTO getDoctorDTO(int doctorID)
        {
            Doctor d = DS.GetDoctorByID(doctorID);
            DoctorCrAppDTO docDTO = new DoctorCrAppDTO(d.name, d.surname, d.userID);
            return docDTO;
        }
        public BindingList<Time> getDoctorTimes(DoctorCrAppDTO doc,DateTime dt)
        {
            if (doc == null) return DS.getDoctorTimes(0, dt);
            return DS.getDoctorTimes(doc.id,dt);
        }

        public Doctor getDoctorById(int docID)
        {
            foreach (Doctor d in DS.getAllDoctors())
            {
                if (d.userID == docID) return d;
            }
            return null;
        }

        public DoctorCrAppDTO getDoctorDTOById(int docID)
        {
            Doctor d = getDoctorById(docID);
            return new DoctorCrAppDTO(d.name, d.surname, d.userID);
        }
    }

    public class DoctorCrAppDTO
    {
        public string name { set; get; }
        public string surname { set; get; }
        public int id { set; get; }

        public DoctorCrAppDTO(string name, string surname, int id)
        {
            this.name = name;
            this.surname = surname;
            this.id = id;
        }
    }
}
