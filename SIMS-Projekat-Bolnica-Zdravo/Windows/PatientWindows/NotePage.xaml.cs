using CrudModel;
using SIMS_Projekat_Bolnica_Zdravo.Services;
using SIMS_Projekat_Bolnica_Zdravo.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS_Projekat_Bolnica_Zdravo.PatientWindows
{
    public partial class NotePage : Page, INotifyPropertyChanged
    {
        private NoteService NS;
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
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
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
        public NotePage(Note note)
        {
            oldNoteName = note.noteName;
            oldNoteContent = note.noteContent;
            this.note = note;
            NS = new NoteService();
            this.DataContext = this;
            InitializeComponent();
        }

        private void Show_Notes(object sender, RoutedEventArgs e)
        {
            note.noteName = oldNoteName;
            note.noteContent = oldNoteContent;
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
            note.noteName = NoteName.Text;
            note.noteContent = NoteContent.Text;
            NS.UpdateNote(note);
            PatientWindow.NavigatePatient.Navigate(new PatientNotes());;
        }
    }
}

