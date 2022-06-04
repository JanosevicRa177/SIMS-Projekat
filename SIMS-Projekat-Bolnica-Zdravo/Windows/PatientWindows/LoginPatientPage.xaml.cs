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
using SIMS_Projekat_Bolnica_Zdravo.Controllers;
using SIMS_Projekat_Bolnica_Zdravo.PatientWindows;

namespace SIMS_Projekat_Bolnica_Zdravo.Windows.PatientWindows
{
    public partial class LoginPatientPage : Page
    {
        private PatientController PC = new PatientController();
        public static LoginPatient WindowLogin;
        public static MainWindow MW
        {
            set;
            get;
        }
        public LoginPatientPage(MainWindow MW1)
        {
            MW = MW1;
            InitializeComponent();
        }
        public LoginPatientPage()
        {
            InitializeComponent();
        }
        public LoginPatientPage(int patientID)
        {
            InitializeComponent();
            Mail.Text = "";
            Password.Clear();
            PassText.Visibility = Visibility.Visible;
            PatientWindow pt = new PatientWindow((LoginPatient)System.Windows.Window.GetWindow(this), patientID);
            pt.Show();
            WindowLogin = (LoginPatient)System.Windows.Window.GetWindow(this);
            if (WindowLogin == null)
            {
                return;
            }
            WindowLogin.Hide();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            /*int patientID = PC.LoginPatient(Mail.Text, Password.Password.ToString());
            if (patientID == -1)
            {
                var patientWindow = Window.GetWindow(this);
                InformationDialog informationDialog = new InformationDialog("Pogresan mail ili sifra");
                informationDialog.Top = patientWindow.Top + 270;
                informationDialog.Left = patientWindow.Left + 25;
                informationDialog.Activate();
                informationDialog.Topmost = true;
                informationDialog.ShowDialog();
                return;
            }*/
            if (PC.IsAccountBlocked(5))
            {
                InformationDialog informationDialog = new InformationDialog("Vas nalog je blokiran zbog zloupotrebe");
                informationDialog.Top = WindowLogin.Top + 270;
                informationDialog.Left = WindowLogin.Left + 25;
                informationDialog.Activate();
                informationDialog.Topmost = true;
                informationDialog.ShowDialog();
                return;
            }
            Mail.Text = "";
            Password.Clear();
            PassText.Visibility = Visibility.Visible;
            PatientWindow pt = new PatientWindow((LoginPatient)System.Windows.Window.GetWindow(this), 5);
            pt.Show();
            WindowLogin = (LoginPatient)System.Windows.Window.GetWindow(this);
            if (WindowLogin == null)
            {
                return;
            }

            WindowLogin.Hide();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MW.Show();
            var Window = (LoginPatient)System.Windows.Window.GetWindow(this);
            Window.Close();
        }
        private void Password_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Password.Password.ToString().Equals(""))
            {
                PassText.Visibility = Visibility.Hidden;
            }
        }

        private void Password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Password.Password.ToString().Equals(""))
            {
                PassText.Visibility = Visibility.Visible;
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            LoginPatient.NavigateLogin.Navigate(new RegisterPatient());
        }
    }
}