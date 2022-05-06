using SIMS_Projekat_Bolnica_Zdravo.CrudModel;
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

namespace SIMS_Projekat_Bolnica_Zdravo.DoctorAll.DoctorWindows
{
    /// <summary>
    /// Interaction logic for AddMedicine.xaml
    /// </summary>
    public partial class AddMedicine : Window
    {

        public TherapyDia MedW
        {
            set;
            get;
        }
        public AddMedicine(TherapyDia xd)
        {
            InitializeComponent();
            this.MedW = xd;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.MedW.obcMed.Add(new Medicine(medName.Text,medAmount.Text,medFreq.Text));
            this.Close();
        }
    }
}
