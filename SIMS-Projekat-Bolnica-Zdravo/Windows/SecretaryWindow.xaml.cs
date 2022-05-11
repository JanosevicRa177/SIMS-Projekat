﻿using System.Windows;

namespace SIMS_Projekat_Bolnica_Zdravo.Windows
{
    /// <summary>
    /// Interaction logic for Secretary.xaml
    /// </summary>
    public partial class SecretaryWindow : Window
    {
        public SecretaryWindow()
        {
           
            InitializeComponent();
           

        }


        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            StaffRegistrationWindow srw = new StaffRegistrationWindow();
            srw.Show();
            this.Close();
        }

        private void PacientApp_Click(object sender, RoutedEventArgs e)
        {
            SecretaryPacientAppointment spa = new SecretaryPacientAppointment();
            spa.Show();
            this.Close();
        }

        private void AddAlergen_Click(object sender, RoutedEventArgs e)
        {
            AddAlergenWindow aaw = new AddAlergenWindow();
            aaw.Show();
            this.Close();
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            var mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Equipment_Click(object sender, RoutedEventArgs e)
        {
            Equipment eq = new Equipment();
            eq.Show();
            this.Close();
        }
    }
}
