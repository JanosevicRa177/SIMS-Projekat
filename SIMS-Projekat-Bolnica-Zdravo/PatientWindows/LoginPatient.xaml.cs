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
using System.Windows.Shapes;

namespace SIMS_Projekat_Bolnica_Zdravo.PatientWindows
{

    public partial class LoginPatient : Window
    {
        private PatientController PC = new PatientController();
        public static Window MW
        {
            set;
            get;
        }
        public string PlaceholderText { get; set; }
        public LoginPatient(MainWindow MW2)
        {
            MW = MW2;
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            /*int patientID = PC.LoginPatient(Mail.Text, Password.Password.ToString());
            if (patientID == -1)
            {
                MessageBox.Show("Pogresan mail ili sifra");
                return;
            }*/
            Mail.Text = "";
            Password.Clear();
            PassText.Visibility = Visibility.Visible;
            PatientWindow pt = new PatientWindow(this, 5);
            pt.Show();
            this.Hide();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MW.Show();
            this.Close();
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
    }
}
