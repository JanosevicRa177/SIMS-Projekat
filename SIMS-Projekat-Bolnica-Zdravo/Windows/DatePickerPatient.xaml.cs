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
    public partial class DatePickerPatient : Window
    {
        public DatePickerPatient()
        {
            this.DataContext = AddAppointmentDialogPatient.date;
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Cancel_Date(object sender, RoutedEventArgs e)
        {
            AddAppointmentDialogPatient pt = new AddAppointmentDialogPatient();
            pt.Show();
            this.Close();
        }
        private void Confirm_Date(object sender, RoutedEventArgs e)
        {
            if (DatePicker.SelectedDate == null) 
            {
                MessageBox.Show("Niste izabrali datum");
                return;
            }
            if (DatePicker.SelectedDate.Value <= DateTime.Today) 
            {
                MessageBox.Show("Ne možete zakazati pregled u prošlosti ili za danas");
                return;
            }
            AddAppointmentDialogPatient.date = DatePicker.SelectedDate.Value;
            AddAppointmentDialogPatient pt = new AddAppointmentDialogPatient();
            pt.Show();
            this.Close();
        }
        private void Calendar_SourceUpdated(object sender, DataTransferEventArgs e)
        {
        }
    }
}
