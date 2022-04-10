using CrudModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class ChangeAppointmentDialogPatient : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public static DateTime date
        {
            get;
            set;
        }
        public static Appointment appointment;
        static Boolean initialize = true;
        public ChangeAppointmentDialogPatient(Appointment appointment1)
        {
            InitializeComponent();
            if (initialize)
            {
                initialize = false;
                date = appointment1.timeBegin;
            }
            appointment = appointment1;
            this.DataContext = this;
        }
        public ChangeAppointmentDialogPatient()
        {
            InitializeComponent();
            if (initialize)
            {
                initialize = false;
            }
            this.DataContext = this;
        }
        private void Show_Notes(object sender, RoutedEventArgs e)
        {
            PatientNotes pn = new PatientNotes();
            initialize = true;
            pn.Show();
            this.Close();
        }

        private void Show_Home(object sender, RoutedEventArgs e)
        {
            PatientWindow pt = new PatientWindow();
            initialize = true;
            pt.Show();
            this.Close();
        }
        private void Change_Date(object sender, RoutedEventArgs e)
        {
            DateChangerPatient pt = new DateChangerPatient();
            pt.Show();
            this.Close();
        }

        private void Cancel_Change_Appointment(object sender, RoutedEventArgs e)
        {
            PatientWindow pt = new PatientWindow();
            initialize = true;
            pt.Show();
            this.Close();
        }

        private void Confirm_Change_appointment(object sender, RoutedEventArgs e)
        {
            appointment.timeBegin = date;
            appointment.hour = (int)sliderHours.Value;
            appointment.minute = (int)sliderMinutes.Value;
            ShowAppointmentDialogPatient pt = new ShowAppointmentDialogPatient();
            initialize = true;
            pt.Show();
            this.Close();
        }
    }
}
