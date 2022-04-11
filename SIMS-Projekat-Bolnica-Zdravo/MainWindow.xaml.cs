﻿using ConsoleApp.serialization;
using CrudModel;
using SIMS_Projekat_Bolnica_Zdravo.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS_Projekat_Bolnica_Zdravo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            new NoteFileStorage();
            new MedicalRecordFileStorage();
            new RoomFileStorage();
            new AppointmentFileStorage();
            new SpecializationFileStorage();
            new DoctorFileStorage();
            new PatientFileStorage();
            new ManagerFileStorage();
            loadIDS();
            InitializeComponent();
            //new EquipmentFileStorage();
            //new MeetingFileStorage();
            //new SecretaryFileStorage();
            //new WarehouseFileStorage();
        }

        public void loadIDS()
        {
            ObservableCollection<IdsStorage> ids = new ObservableCollection<IdsStorage>();
            Serializer <IdsStorage> doctorserialzer = new Serializer<IdsStorage>();
            ids = doctorserialzer.fromCSV("ids.txt");
            ids[0].setALLIDS();

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)cb.SelectedItem;
            string xd = cbi.Content.ToString();
            if (xd.Equals("Selektuj ulogu!"))
            {
                MessageBox.Show("SELEKTUJ ULOGU XD!");
                return;
            }
  

            if (xd.Equals("Sekretar"))
            {
                Windows.Secretary sc = new Windows.Secretary();
                sc.Show();
            }
            else if (xd.Equals("Lekar"))
            {
                DoctorWindow dr = new DoctorWindow();
                dr.Show();
            }
            else if (xd.Equals("Pacijent"))
            {
                PatientWindow pt = new PatientWindow();
                pt.Show();
            }
            else if (xd.Equals("Upravnik"))
            {
                ManagerWindow m = new ManagerWindow();
                m.Show();
            }


            this.Close();
        }

        private void cb_Loaded(object sender, RoutedEventArgs e)
        {
            cb.Text = "Selektuj ulogu!";
        }
    }
}
