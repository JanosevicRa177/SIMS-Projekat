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
            if (ADoc.IsChecked.Value) {
                addAppointmentDialogDoctor dia = new addAppointmentDialogDoctor((Patient)PatientsG.SelectedItem, desc.Text);
                dia.ShowDialog();
            }
            //else if()
            {

            }
           // else
            {

            }
        }
    }
}
