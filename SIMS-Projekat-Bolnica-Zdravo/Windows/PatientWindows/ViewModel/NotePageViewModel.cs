using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CrudModel;
using MVVM;
using SIMS_Projekat_Bolnica_Zdravo.PatientWindows;
using SIMS_Projekat_Bolnica_Zdravo.Services;
using SIMS_Projekat_Bolnica_Zdravo.Windows.PatientWindows.Views;

namespace SIMS_Projekat_Bolnica_Zdravo.Windows.PatientWindows.ViewModel
{
    class NotePageViewModel : BindableBase
    {
        private NoteService NS;
        public MyICommand ConfirmCommand { get; set; }
        public MyICommand ReverseCommand { get; set; }
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
            get { return note.noteName; }
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
        public NotePageViewModel(Note note)
        {
            ReverseCommand = new MyICommand(OnReverse);
            ConfirmCommand = new MyICommand(OnConfirm);
            oldNoteName = note.noteName;
            oldNoteContent = note.noteContent;
            this.note = note;
            NS = new NoteService();
        }
        private void OnReverse()
        {
            NameNote = oldNoteName;
            ContentNote = oldNoteContent;
        }
        private void OnConfirm()
        {
            note.noteName = NameNote;
            note.noteContent = ContentNote;
            NS.UpdateNote(note);
            PatientWindow.NavigatePatient.Navigate(new PatientNotes()); 
        }
    }
}
