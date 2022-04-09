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
    public partial class AddAppointmentDialogPatient : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public static DateTime date
        {
            get;
            set;
        }
        static Boolean initialize = true;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public AddAppointmentDialogPatient()
        {
            if (initialize) 
            {
                initialize = false;
                date = DateTime.Today;
            }
            this.DataContext = new
            {
                docs = new DoctorFileStorage(),
                This = this
            };
            InitializeComponent();
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
        public int hours
        {
            set;
            get;
        }
        public int minutes
        {
            set;
            get;
        }

        private void Pick_Date(object sender, RoutedEventArgs e)
        {
            DatePickerPatient pt = new DatePickerPatient();
            pt.Show();
            this.Close();
        }
    }
}
