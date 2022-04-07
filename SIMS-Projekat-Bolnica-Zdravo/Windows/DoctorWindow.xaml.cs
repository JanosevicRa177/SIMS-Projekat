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
        public DoctorWindow()
        {
            Appointments.DataContext = new AppointmentFileStorage();
            Appointment xd = new Appointment();
            MessageBox.Show(xd.duration.ToString());
            AppointmentFileStorage.appointmentList.Add(xd);
            InitializeComponent();
        }

        private void addAppointment_Click(object sender, RoutedEventArgs e)
        {
            addAppointmentDialogDoctor dia = new addAppointmentDialogDoctor();
            dia.Show();
            Appointments.Items.Refresh();
        }
    }
}
