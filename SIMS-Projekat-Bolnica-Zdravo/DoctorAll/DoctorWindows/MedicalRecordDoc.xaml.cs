using SIMS_Projekat_Bolnica_Zdravo.Controllers;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace SIMS_Projekat_Bolnica_Zdravo.DoctorAll.DoctorWindows
{
    /// <summary>
    /// Interaction logic for MedicalRecordDoc.xaml
    /// </summary>
    public partial class MedicalRecordDoc : Window
    {
        AppointmentController AC;
        PatientController PC;
        public MedicalRecordDoc(int patientID)
        {
            PC = new PatientController();
            AC = new AppointmentController();
            InitializeComponent();
            DataContext = PC.GetPatientByID(patientID);
            PatientsApps.DataContext = AC.getAllPatientsAppointments(patientID);


        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void openA_Click(object sender, RoutedEventArgs e)
        {
            if (PatientsApps.SelectedItem == null) return;
            ShowAppointmentPatientDTO sadto = (ShowAppointmentPatientDTO)PatientsApps.SelectedItem;
            var dia = new TherapyDia(sadto.id);
            dia.ShowDialog();
        }
    }
}
