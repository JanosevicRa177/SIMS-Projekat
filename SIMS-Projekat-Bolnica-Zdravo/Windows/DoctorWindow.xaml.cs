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
    /// Interaction logic for DoctorWindow.xaml
    /// </summary>
    public partial class DoctorWindow : Window
    {
        public static Doctor loggedDoc
        {
            set;
            get;
        }
        public DoctorWindow()
        {
            InitializeComponent();
            loggedDoc = DoctorFileStorage.GetDoctorByID(0);
            
            this.DataContext = loggedDoc;
        }

        private void addAppointment_Click(object sender, RoutedEventArgs e)
        {
            _1addAppointmentDialogDoctor dia = new _1addAppointmentDialogDoctor();
            dia.ShowDialog();
        }

        private void deleteAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (Appointments.SelectedIndex == -1 ) { MessageBox.Show("no row selected!"); return; }
            loggedDoc.Appointment.Remove((Appointment)Appointments.SelectedItem);
        }
    }
}
