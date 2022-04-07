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
    public partial class PatientWindow : Window
    {
        static public Patient loggedPatient
        {
            get;
            set;
        }


        public PatientWindow()
        {
            this.DataContext = this;
            if (loggedPatient == null) 
            {
                Patient p = new Patient("Mika", "Mikic",new Address("Srbija","Novi Sad","Ive Andrica", "23"),
                "asdasd","06111111","mailinator@gmail.com", Gender.male, 34058970);
                PatientFileStorage.patientList.Add(p);
                loggedPatient = p;
                loggedPatient.AddNote(new Note("Beleska1", "Neki kontent 1"));
                loggedPatient.AddNote(new Note("Beleska2", "Neki kontent 2"));
                loggedPatient.AddNote(new Note("Beleska3", "Neki kontent 3"));
                loggedPatient.AddNote(new Note("Beleska4", "Neki kontent 4"));
            }
            InitializeComponent();
        }

        private void Show_Notes(object sender, RoutedEventArgs e)
        {
            PatientNotes pn = new PatientNotes(loggedPatient);
            pn.Show();
            this.Close();
        }
    }
}
