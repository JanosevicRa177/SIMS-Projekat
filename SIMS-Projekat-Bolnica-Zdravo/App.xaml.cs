﻿using ConsoleApp.serialization;
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
            Serializer<Patient> patientSerializer = new Serializer<Patient>();
            patientSerializer.toCSV("patients.txt", PatientFileStorage.patientList);
            Serializer<Doctor> doctorSerializer = new Serializer<Doctor>();
            doctorSerializer.toCSV("doctors.txt", DoctorFileStorage.doctorList);
            Serializer<IdsStorage> idsSerializer = new Serializer<IdsStorage>();
            new IdsStorage();
            idsSerializer.toCSV("ids.txt", IdsStorage.IDS);
        }
    }
}
