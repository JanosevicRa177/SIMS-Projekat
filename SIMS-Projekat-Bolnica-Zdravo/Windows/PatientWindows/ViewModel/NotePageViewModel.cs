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
        private NotificationService notificationService;
        public MyICommand ConfirmCommand { get; set; }
        public MyICommand ReverseCommand { get; set; }
        public Note note
        {
            get;
            set;
        }
        public String oldNoteContent
        {
            get;
            set;
        }
        public String oldNoteName
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
        public int _frequency
        {
            get;
            set;
        }
        public int Frequency
        {
            get { return _frequency; }
            set
            {
                if (value != _frequency)
                {
                    _frequency = value;
                    OnPropertyChanged("Frequency");
                }
            }
        }

        public bool isNotification
        {
            get;
            set;
        }

        public bool IsNotification
        {
            get { return isNotification; }
            set
            {
                if (value != isNotification)
                {
                    isNotification = value;
                    OnPropertyChanged("IsNotification");
                }
            }
        }

        public bool begginningIsNotification
        {
            get;
            set;
        }

        public Model.Notification notification
        {
            get;
            set;
        }

        public NotePageViewModel(Note note)
        {
            NS = new NoteService();
            notificationService = new NotificationService();
            notification = notificationService.GetNoteNotificationrByNoteID(note.noteID);
            if (notification == null)
            {
                IsNotification = false;
            }
            else
            {
                IsNotification = true;
            }
            ReverseCommand = new MyICommand(OnReverse);
            ConfirmCommand = new MyICommand(OnConfirm);
            oldNoteName = note.noteName;
            oldNoteContent = note.noteContent;
            this.note = note;

        }
        private async void ShowNotes()
        {
            while (true)
            { 
                await Task.Delay(1000);
            }
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
