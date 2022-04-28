using CrudModel;
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
using static SIMS_Projekat_Bolnica_Zdravo.Controllers.AppointmentController;

namespace SIMS_Projekat_Bolnica_Zdravo.Windows
{
    /// <summary>
    /// Interaction logic for DoctorsAppointments.xaml
    /// </summary>
    public partial class DoctorsAppointments : Window
    {
        private AppointmentController AC;
        public DoctorsAppointments()
        {
            AC = new AppointmentController();
            InitializeComponent();
            this.DataContext = AC.GetAllDoctorsAppointments(DoctorWindow.loggedDoc);
        }

        private void showButt_Click(object sender, RoutedEventArgs e)
        {
            ShowAppointmentDTO a = (ShowAppointmentDTO)Appointments.SelectedItem;
            var dia = new doctorShowAppointment(a.id);
            dia.Show();
        }
    }
}
