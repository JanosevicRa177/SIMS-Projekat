using ConsoleApp.serialization;
using CrudModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SIMS_Projekat_Bolnica_Zdravo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Serializer<MedicalRecord> medicalRecorderializer = new Serializer<MedicalRecord>();
            medicalRecorderializer.toCSV("medicalRecords.txt", MedicalRecordFileStorage.medicalRecordList);
            Serializer<Patient> patientSerializer = new Serializer<Patient>();
            patientSerializer.toCSV("patients.txt", PatientFileStorage.patientList);
        }
    }
}
