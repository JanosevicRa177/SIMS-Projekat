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

namespace SIMS_Projekat_Bolnica_Zdravo.Windows
{
    /// <summary>
    /// Interaction logic for doctorShowAppointment.xaml
    /// </summary>
    public partial class doctorShowAppointment : Window
    {
        private AppointmentController AC;
        public static int appointmentID
        {
            set;
            get;
        }

        //public static DoctorsAppointments da
        //{
        //    set;
        //    get;
        //}

        public doctorShowAppointment(int appoID)
        {
            AC = new AppointmentController();
            InitializeComponent();
            appointmentID = appoID;
            this.DataContext = AC.getShowAppointmentDTO(appoID);
        }
        //public doctorShowAppointment(Appointment appo,DoctorsAppointments dax)
        //{
        //    da = dax;
        //    InitializeComponent();
        //    appointment = appo;
        //    this.DataContext = appointment;
        //}
        
        private void DeleteA_Click(object sender, RoutedEventArgs e)
        {
            AC.removeAppointment(appointmentID);
            this.Close();
        }
        private void EtitA_Click(object sender, RoutedEventArgs e)
        {
            //var dia = new addAppointmentDialogDoctor(appointment,this);
            //dia.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //da.Appointments.Items.Refresh();
            this.Close();
        }
    }
}
