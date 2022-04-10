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
    /// Interaction logic for DoctorsAppointments.xaml
    /// </summary>
    public partial class DoctorsAppointments : Window
    {
        public DoctorsAppointments()
        {
            InitializeComponent();
            this.DataContext = DoctorWindow.loggedDoc;
        }

        private void showButt_Click(object sender, RoutedEventArgs e)
        {
            var dia = new doctorShowAppointment((Appointment)Appointments.SelectedItem,this);
            dia.Show();
        }
    }
}
