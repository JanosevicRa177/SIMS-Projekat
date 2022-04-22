using CrudModel;
using SIMS_Projekat_Bolnica_Zdravo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat_Bolnica_Zdravo.Controllers
{
    public class PatientController
    {
        private PatientService PS;

        public PatientController()
        {
            PS = new PatientService();
        }
        public ObservableCollection<PatientCrAppDTO> getAllPatientsChooseDTO()
        {
            ObservableCollection<PatientCrAppDTO> ocp = new ObservableCollection<PatientCrAppDTO>();
            ObservableCollection<Patient> patients = PS.getAllPatients();
            foreach(Patient p in patients)
            {
                ocp.Add(new PatientCrAppDTO(p.name, p.surname, p.userID.ToString(),p.userID));
            }
            return ocp;
        }

        public Patient GetPatientByID(int patientID)
        {
            return PS.GetPatientByID(patientID);
        }
    }

    public class PatientCrAppDTO
    {
        public string name { set; get; }
        public string surname { set; get; }
        public string JMBG { set; get; }
        public int id { set; get; }

        public PatientCrAppDTO(string name, string surname, string JMBG,int id)
        {
            this.name = name;
            this.surname = surname;
            this.JMBG = JMBG;
            this.id = id;
        }
    }
}
