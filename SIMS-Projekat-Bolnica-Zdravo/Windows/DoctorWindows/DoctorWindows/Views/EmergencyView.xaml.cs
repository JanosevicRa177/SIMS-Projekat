using SIMS_Projekat_Bolnica_Zdravo.Windows.DoctorWindows.DoctorWindows.ViewModel;
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

namespace SIMS_Projekat_Bolnica_Zdravo.Windows.DoctorWindows.DoctorWindows.Views
{
    /// <summary>
    /// Interaction logic for EmergencyView.xaml
    /// </summary>
    public partial class EmergencyView : UserControl
    {
        public EmergencyView(int patID)
        {
            this.DataContext = new EmergencyViewModel(patID);
            InitializeComponent();
        }
    }
}
