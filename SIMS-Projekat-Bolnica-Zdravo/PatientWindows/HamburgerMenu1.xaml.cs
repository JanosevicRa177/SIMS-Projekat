﻿using SIMS_Projekat_Bolnica_Zdravo.Windows;
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
    /// Interaction logic for HamburgerMenu1.xaml
    /// </summary>
    public partial class HamburgerMenu1 : Page
    {
        public static PatientWindow patientWindow;
        public static MainHamburgerMenu mainMenu;
        public HamburgerMenu1(PatientWindow patientWindow1, MainHamburgerMenu mainMenu1)
        {
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
    }
}
