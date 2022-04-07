using CrudModel;
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

namespace SIMS_Projekat_Bolnica_Zdravo.Windows
{
    public partial class NoteWindow : Window
    {
        Patient loggedPatient;
        public NoteWindow()
        {
            this.DataContext = this;
            Patient p = new Patient("Mika", "Mikic",new Address("Srbija","Novi Sad","Ive Andrica", "23"),
                "asdasd","06111111","mailinator@gmail.com", Gender.male, 34058970);
            PatientFileStorage.patientList.Add(p);
            loggedPatient = p;
            InitializeComponent();
        }

        private void Show_Notes(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
