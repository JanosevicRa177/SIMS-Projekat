using ConsoleApp.serialization;
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
            new SpecializationFileStorage();
            new DoctorFileStorage();
            //new PatientFileStorage();
            new ManagerFileStorage();
            new SecretaryFileStorage();
            //new NoteFileStorage();
            //new MedicalRecordFileStorage();
            new SecretaryFileStorage();
            new RoomFileStorage();
            new AppointmentFileStorage();
            loadIDS();
            InitializeComponent();
            //new EquipmentFileStorage();
            //new MeetingFileStorage();
            //new WarehouseFileStorage();
        }

        public void loadIDS()
        {
            new IdsStorage();
            Serializer <Ids> doctorserialzer = new Serializer<Ids>();
            IdsStorage.IDS = doctorserialzer.fromCSV("../../TxtFajlovi/ids.txt");
            IdsStorage.IDS[0].setALLIDS();

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
                SecretaryWindow sc = new SecretaryWindow();
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
