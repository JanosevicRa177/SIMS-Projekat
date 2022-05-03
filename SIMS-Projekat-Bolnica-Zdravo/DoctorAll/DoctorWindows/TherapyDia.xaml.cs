using SIMS_Projekat_Bolnica_Zdravo.Controllers;
using SIMS_Projekat_Bolnica_Zdravo.CrudModel;
using SIMS_Projekat_Bolnica_Zdravo.DoctorWindows;
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
using System.Windows.Shapes;
using static SIMS_Projekat_Bolnica_Zdravo.Controllers.AppointmentController;

namespace SIMS_Projekat_Bolnica_Zdravo.DoctorAll.DoctorWindows
{
    /// <summary>
    /// Interaction logic for TherapyDia.xaml
    /// </summary>
    public partial class TherapyDia : Window
    {
        private AppointmentController AC;
        public ObservableCollection<Medicine> obcMed
        {
            set;
            get;
        }
        private int appoID;
        public TherapyDia(int appoID)
        {
            this.appoID = appoID;
            AC = new AppointmentController();
            obcMed = AC.getStartAppointmentDTOById(appoID).medicineList;
            InitializeComponent();
            this.DataContext = new
            {
                Appo = AC.getStartAppointmentDTOById(appoID),
                Meds = obcMed
            };
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StartAppointmentDTO sadto = new StartAppointmentDTO(descBox.Text, TherapyT.Text,ConditionT.Text, obcMed, appoID);
            AC.ExecutedAppointment(sadto);
            var dia = new DialogWindow("Changes saved","Cancel","Ok");
            dia.ShowDialog();
        }

        private void AddMed_Click(object sender, RoutedEventArgs e)
        {
            var dia = new AddMedicine(this);
            dia.ShowDialog();
        }
    }
}
