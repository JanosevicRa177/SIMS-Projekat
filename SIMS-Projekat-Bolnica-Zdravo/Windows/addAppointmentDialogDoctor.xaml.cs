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
    /// Interaction logic for addAppointmentDialogDoctor.xaml
    /// </summary>
    public partial class addAppointmentDialogDoctor : Window
    {
        public int Test
        {
            set;
            get;
        }
        public addAppointmentDialogDoctor()
        {
            Test = 60;
            this.DataContext = this;
            InitializeComponent();
        }

        private void createAppointmentDoctor_Click(object sender, RoutedEventArgs e)
        {
            Appointment a = new Appointment(new DateTime(int.Parse(yearaddAppointmentDialogDoctor.Text),int.Parse(monthaddAppointmentDialogDoctor.Text),int.Parse(dayaddAppointmentDialogDoctor.Text),int.Parse(houraddAppointmentDialogDoctor.Text),int.Parse(minuteaddAppointmentDialogDoctor.Text),0), int.Parse(duiration.Text), int.Parse(room.Text), int.Parse(doctorsName.Text),int.Parse(patientsName.Text));
            AppointmentFileStorage.appointmentList.Add(a);
            MessageBox.Show("Appointment added!");
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Test = (int)xwed.Value;
            MessageBox.Show(Test.ToString());
        }
    }
}
