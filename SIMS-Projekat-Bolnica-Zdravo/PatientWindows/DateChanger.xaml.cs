using CrudModel;
using SIMS_Projekat_Bolnica_Zdravo.Services;
using SIMS_Projekat_Bolnica_Zdravo.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS_Projekat_Bolnica_Zdravo.PatientWindows
{
    public partial class DateChanger : Page
    {
        public DateChanger()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Cancel_Date(object sender, RoutedEventArgs e)
        {
            PatientWindow.NavigatePatient.Navigate(new ChangeAppointment());
        }
        private void Confirm_Date(object sender, RoutedEventArgs e)
        {
            if (DatePicker_Date.SelectedDate == null)
            {
                MessageBox.Show("Niste izabrali datum");
                return;
            }
            if (DatePicker_Date.SelectedDate.Value <= DateTime.Today)
            {
                MessageBox.Show("Ne možete zakazati pregled u prošlosti ili za danas");
                return;
            }
            ChangeAppointment.date = DatePicker_Date.SelectedDate.Value;
            PatientWindow.NavigatePatient.Navigate(new ChangeAppointment());
        }
        private void Calendar_SourceUpdated(object sender, DataTransferEventArgs e)
        {
        }
    }
}
