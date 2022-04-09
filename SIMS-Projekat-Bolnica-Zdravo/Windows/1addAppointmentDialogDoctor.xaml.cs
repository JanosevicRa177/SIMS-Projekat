using CrudModel;
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

namespace SIMS_Projekat_Bolnica_Zdravo.Windows
{
    /// <summary>
    /// Interaction logic for _1addAppointmentDialogDoctor.xaml
    /// </summary>
    public partial class _1addAppointmentDialogDoctor : Window
    {
        public _1addAppointmentDialogDoctor()
        {
            InitializeComponent();
            this.DataContext = new PatientFileStorage();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (PatientsG.SelectedIndex == -1)
            {
                MessageBox.Show("No row selected!");
                return;
            }
            this.Close();
            addAppointmentDialogDoctor dia = new addAppointmentDialogDoctor((Patient)PatientsG.SelectedItem, desc.Text);
            dia.ShowDialog();
        }

        private void searchP_KeyUp(object sender, KeyEventArgs e)
        {
            var filtered = PatientFileStorage.patientList.Where(patient => patient.name.StartsWith(searchP.Text));

            PatientsG.ItemsSource = filtered;
        }

        private void searchP_GotFocus(object sender, RoutedEventArgs e)
        {
            searchP.Text = "";
        }

        private void searchP_LostFocus(object sender, RoutedEventArgs e)
        {
            if(searchP.Text.Equals(""))
                searchP.Text = "Search patient";
        }
    }
}
