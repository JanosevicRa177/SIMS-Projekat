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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SIMS_Projekat_Bolnica_Zdravo.Windows;

namespace SIMS_Projekat_Bolnica_Zdravo.PatientWindows
{
    public partial class NotificationPage : Page
    {
        private AppointmentNotificationController ANC = new AppointmentNotificationController();
        public NotificationPage()
        {
            this.DataContext = ANC.GetAppointmentNotificationrByPatientID(PatientWindow.LoggedPatient.id);
            InitializeComponent();
        }
    }
}
