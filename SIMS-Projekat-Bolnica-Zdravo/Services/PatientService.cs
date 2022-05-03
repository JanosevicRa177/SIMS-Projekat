using CrudModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS_Projekat_Bolnica_Zdravo.Services
{
    class PatientService
    {
        private PatientFileStorage PFS;

        public PatientService()
        {
            PFS = new PatientFileStorage();
        }
        public ObservableCollection<Patient> getAllPatients()
        {
            return PFS.getAllPatientsFS();
        }
         
        public Patient GetPatientByID(int patientID)
        {
            return PFS.GetPatientByID(patientID);
        }
        public bool CreatePatient(Patient pat)
        {
            PFS.CreatePatient(pat);
            return true;
        }
    }
}
