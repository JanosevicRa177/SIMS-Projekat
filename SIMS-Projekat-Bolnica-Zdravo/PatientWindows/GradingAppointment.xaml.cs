using SIMS_Projekat_Bolnica_Zdravo.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS_Projekat_Bolnica_Zdravo.PatientWindows
{
    /// <summary>
    /// Interaction logic for GradingAppointment.xaml
    /// </summary>
    public partial class GradingAppointment : Page
    {
        public static PatientWindow patientWindow;
        public GradingAppointment(PatientWindow patientWindow1)
        {
            patientWindow = patientWindow1;
            InitializeComponent();
        }
        private void Cancel_Grading_Click(object sender, RoutedEventArgs e)
        {
            patientWindow.PatientFrame.NavigationService.Navigate(new AppointmentsForGrading(patientWindow));
        }
    }
}
