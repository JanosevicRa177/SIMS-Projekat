using CrudModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class PatientNotes: Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public PatientNotes()
        {
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.DataContext = new PatientWindow();
            InitializeComponent();
        }
        private void Show_Home(object sender, RoutedEventArgs e)
        {
            PatientWindow pt = new PatientWindow();
            pt.Show();
            this.Close();
        }

        private void Add_Note(object sender, RoutedEventArgs e)
        {
            Note n = new Note("Prazno", "");
            PatientWindow.loggedPatient.AddNote(n);
            NotesListGrid.Items.Refresh();
        }

        private void DeleteNote(object sender, RoutedEventArgs e)
        {
            PatientWindow.loggedPatient.RemoveNote((Note)NotesListGrid.SelectedItem);
            NotesListGrid.Items.Refresh();
        }

        private void ShowNote(object sender, RoutedEventArgs e)
        {
            NoteWindow nt = new NoteWindow((Note)NotesListGrid.SelectedItem);
            nt.Show();
            this.Close();
        }

        private void NotesListGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
