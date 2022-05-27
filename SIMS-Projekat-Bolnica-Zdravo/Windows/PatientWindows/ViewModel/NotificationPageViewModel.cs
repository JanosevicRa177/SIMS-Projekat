using System.Collections.ObjectModel;
using CrudModel;
using MVVM;
using SIMS_Projekat_Bolnica_Zdravo.Model;

namespace SIMS_Projekat_Bolnica_Zdravo.Windows.PatientWindows.ViewModel
{
    class NotificationPageViewModel : BindableBase
    {
        private AppointmentNotificationController ANC = new AppointmentNotificationController();
        public ObservableCollection<AppointmentNotification> Notifications { get; set; }
        public NotificationPageViewModel()
        {
            Notifications = ANC.GetAppointmentNotificationrByPatientID(PatientWindow.LoggedPatient.id);
        }
    }
}
