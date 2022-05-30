using SIMS_Projekat_Bolnica_Zdravo.Controllers;
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
using SIMS_Projekat_Bolnica_Zdravo.Windows.PatientWindows.Views;

namespace SIMS_Projekat_Bolnica_Zdravo.PatientWindows
{
    /// <summary>
    /// Interaction logic for HamburgerMenu1.xaml
    /// </summary>
    public partial class HamburgerMenu1 : Page
    {
        public static PatientWindow patientWindow;
        public static MainHamburgerMenu mainMenu;
        private AppointmentController AC;
        private HospitalGradeController HGC;
        public HamburgerMenu1(PatientWindow patientWindow1, MainHamburgerMenu mainMenu1)
        {
            AC = new AppointmentController();
            HGC = new HospitalGradeController();
            mainMenu = mainMenu1;
            patientWindow = patientWindow1;
            InitializeComponent();
        }
        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            patientWindow.SignOut();
        }

        private void Medical_Record_Show_Click(object sender, RoutedEventArgs e)
        {
            MainHamburgerMenu.NavigateMenu.Navigate(new HamburgerMenu2(patientWindow, mainMenu));
        }

        private void HospitalGrading_Click(object sender, RoutedEventArgs e)
        {
            if (!AC.IsPatientEligibleToGradeHospital(PatientWindow.LoggedPatient.id)) 
            {
                InformationDialog informationDialog = new InformationDialog("Niste kvalifikovani da ocenite bolnicu, morate imati barem 3 odradjena pregleda");
                informationDialog.Top = patientWindow.Top + 270;
                informationDialog.Left = patientWindow.Left + 25;
                informationDialog.Activate();
                informationDialog.Topmost = true;
                informationDialog.ShowDialog();
                return;
            }
            if (HGC.DidPatientGradeHospital(PatientWindow.LoggedPatient.id))
            {
                InformationDialog informationDialog = new InformationDialog("Već ste ocenili bolnicu");
                informationDialog.Top = patientWindow.Top + 270;
                informationDialog.Left = patientWindow.Left + 25;
                informationDialog.Activate();
                informationDialog.Topmost = true;
                informationDialog.ShowDialog();
                return;
            }
            patientWindow.PatientFrame.NavigationService.Navigate(new GradingHospital(patientWindow));
            PatientWindow.menuClosed = true;
            mainMenu.Close_menu();

        }

        private void Notifications_Click(object sender, RoutedEventArgs e)
        {
            patientWindow.PatientFrame.NavigationService.Navigate(new NotificationPageView());
            PatientWindow.menuClosed = true;
            mainMenu.Close_menu();
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            patientWindow.PatientFrame.NavigationService.Navigate(new AccountView());
            PatientWindow.menuClosed = true;
            mainMenu.Close_menu();
        }
    }
}
