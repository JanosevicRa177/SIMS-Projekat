using CrudModel;
using SIMS_Projekat_Bolnica_Zdravo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ObservableCollection<Doctor> getAllDocs()
        {
            return DS.getAllDoctors();
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
        public void AddDoct(Doctor d)
        {
            DS.AddDoctor(d);
        }
        public void DeleteDoct(DoctorSecDTO d)
        {
            DS.DeleteDoct(d);
        }
        public void UpdateDoctor(Doctor d)
        {
            DS.UpdateDoctor(d);
        }
        public Doctor getDocByEmail(string email)
        {
            ObservableCollection<Doctor> doctors = DS.getAllDoctors();
            Doctor d = DS.getDocByMail(email);
            return d;
        }
     
        public BindingList<Time> getDoctorTimes(DoctorCrAppDTO doc,DateTime dt)
        {
            if (doc == null) return DS.getDoctorTimes(0, dt);
            return DS.getDoctorTimes(doc.id,dt);
        }

        public ObservableCollection<DoctorSecDTO> getAllDocsDTO()
        {
            ObservableCollection<DoctorSecDTO> thr = new ObservableCollection<DoctorSecDTO>();
            ObservableCollection<Doctor> docs = DS.getAllDoctors();
            foreach (Doctor d in docs)
            {
                thr.Add(new DoctorSecDTO(d.name, d.surname, d.mail));
            }
            return thr;
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
    public class DoctorSecDTO
    {
        public string name { set; get; }
        public string surname { set; get; }
        public string email { set; get; }

        public DoctorSecDTO(string name, string surname, string email)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
        }
    }
}
