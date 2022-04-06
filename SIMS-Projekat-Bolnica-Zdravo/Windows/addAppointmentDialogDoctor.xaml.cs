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
        public addAppointmentDialogDoctor()
        {
            InitializeComponent();
        }

        private void createAppointmentDoctor_Click(object sender, RoutedEventArgs e)
        {
            Appointment a = new Appointment();
        }
    }
}
