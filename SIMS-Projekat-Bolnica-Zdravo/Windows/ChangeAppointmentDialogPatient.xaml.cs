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
        public static double hour
        {
            get;
            set;
        }
        public static double minute
        {
            get;
            set;
        }
        static Boolean initialize = true;
        public ChangeAppointmentDialogPatient(Appointment appointment1)
        {
            InitializeComponent();
            date = appointment1.timeBegin;
            hour = appointment1.hour;
            minute = appointment1.minute;
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
            pn.Show();
            this.Close();
        }

        private void Show_Home(object sender, RoutedEventArgs e)
        {
            PatientWindow pt = new PatientWindow();
            pt.Show();
            this.Close();
        }
        private void Change_Date(object sender, RoutedEventArgs e)
        {
            minute = sliderMinutes.Value;
            hour = sliderHours.Value;
            DateChangerPatient pt = new DateChangerPatient();
            pt.Show();
            this.Close();
        }

        private void Cancel_Change_Appointment(object sender, RoutedEventArgs e)
        {
            PatientWindow pt = new PatientWindow();
            pt.Show();
            this.Close();
        }

        private void Confirm_Change_appointment(object sender, RoutedEventArgs e)
        {
            ShowAppointmentDialogPatient.appointment.timeBegin = date;
            ShowAppointmentDialogPatient.appointment.hour = (int)hour;
            ShowAppointmentDialogPatient.appointment.minute = (int)minute;
            ShowAppointmentDialogPatient.appointment.setTime();
            ShowAppointmentDialogPatient pt = new ShowAppointmentDialogPatient();
            pt.Show();
            this.Close();
        }

        private void sliderMinutes_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            minute = sliderMinutes.Value;
            Minutes.Text = sliderMinutes.Value.ToString();
        }

        private void sliderHours_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            hour = sliderHours.Value;
            Hours.Text = sliderHours.Value.ToString();
        }
    }
}
