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
        public Patient pat
        {
            set;
            get;
        }

        public int dur
        {
            set;
            get;
        }

        public string desc
        {
            set;
            get;
        }

        public addAppointmentDialogDoctor(Patient pat,string desc)
        {
            this.pat = pat;
            this.desc = desc;
            InitializeComponent();
            this.DataContext = new
            {
                This = this,
                Rooms = new RoomFileStorage(),
                Docs = new DoctorFileStorage()
            };

        }

        private void createAppointmentDoctor_Click(object sender, RoutedEventArgs e)
        {
            Appointment a = new Appointment(appointmentDate.SelectedDate.Value, int.Parse(houraddAppointmentDialogDoctor.Text), int.Parse(minuteaddAppointmentDialogDoctor.Text), int.Parse(duration.Text), (Room)roomID.SelectedItem, (Doctor)doctorsCB.SelectedItem, this.pat,desc);
            AppointmentFileStorage.appointmentList.Add(a);
            this.Close();
        }
    }
}
