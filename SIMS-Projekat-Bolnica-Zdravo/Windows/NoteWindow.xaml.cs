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
    public partial class NoteWindow : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        Note note
        {
            get;
            set;
        }
        String oldNoteContent
        {
            get;
            set;
        }
        String oldNoteName
        {
            get;
            set;
        }
        public string NameNote
        {
            get { return note.noteName;}
            set
            {
                if (value != note.noteName)
                {
                    note.noteName = value;
                    OnPropertyChanged("NameNote");
                }
            }
        }
        public string ContentNote
        {
            get { return note.noteContent; }
            set
            {
                if (value != note.noteContent)
                {
                    note.noteContent = value;
                    OnPropertyChanged("ContentNote");
                }
            }
        }
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public NoteWindow(Note note)
        {
            oldNoteName = note.noteName;
            oldNoteContent = note.noteContent;
            this.note = note;
            this.DataContext = this;
            InitializeComponent();
        }

        private void Show_Notes(object sender, RoutedEventArgs e)
        {
            PatientNotes pn = new PatientNotes();
            note.noteName = oldNoteName;
            note.noteContent = oldNoteContent;
            pn.Show();
            this.Close();
        }

        private void Show_Home(object sender, RoutedEventArgs e)
        {
            PatientWindow pt = new PatientWindow();
            note.noteName = oldNoteName;
            note.noteContent = oldNoteContent;
            pt.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void ReverseNote(object sender, RoutedEventArgs e)
        {
            NoteName.Text = oldNoteName;
            NoteContent.Text = oldNoteContent;
        }
        private void ConfirmNote(object sender, RoutedEventArgs e)
        {
            PatientNotes pn = new PatientNotes();
            pn.Show();
            this.Close();
        }
    }
}
