using SIMS_Projekat_Bolnica_Zdravo.Windows;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace SIMS_Projekat_Bolnica_Zdravo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Sekretar_Click_1(object sender, RoutedEventArgs e)
        {
            Secretary sc = new Secretary();
            sc.Show();
            this.Close();
        }

        private void Lekar_Click(object sender, RoutedEventArgs e)
        {
            DoctorWindow dr = new DoctorWindow();
            dr.Show();
            this.Close();
        }

        private void Pacijent_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow pt = new PatientWindow();
            pt.Show();
            this.Close();
        }

        private void Upravnik_Click(object sender, RoutedEventArgs e)
        {
            Manager mn = new Manager();
            mn.Show();
            this.Close();
        }
    }
}
