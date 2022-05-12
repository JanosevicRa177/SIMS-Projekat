using CrudModel;
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

namespace SIMS_Projekat_Bolnica_Zdravo.DoctorAll.DoctorWindows
{
    /// <summary>
    /// Interaction logic for VacationWindow.xaml
    /// </summary>
    public partial class VacationWindow : Window
    {
        private DoctorController DC;
        private VacationRequestController VRC;
        public VacationWindow()
        {
            DC = new DoctorController();
            VRC = new VacationRequestController();
            InitializeComponent();
            this.DataContext = DC.getDoctorById(DoctorWindow.loggedDoc).VacationDays;
        }

        private void sreq_Click(object sender, RoutedEventArgs e)
        {
            VRC.CreateVacationRequest(new VacationRequest((DateTime)date1.SelectedDate, (DateTime)date2.SelectedDate));
        }
    }
}
