﻿using CrudModel;
using SIMS_Projekat_Bolnica_Zdravo.Controllers;
using SIMS_Projekat_Bolnica_Zdravo.Services;
using SIMS_Projekat_Bolnica_Zdravo.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS_Projekat_Bolnica_Zdravo.PatientWindows
{
    public partial class PatientNotes : Page
    {
        private NoteController NC;
        private ObservableCollection<Note> patientNotes;
        public PatientNotes()
        {
            NC = new NoteController();
            patientNotes = NC.getAllPatientNotes(PatientWindow.LoggedPatient.id);
            this.DataContext = patientNotes;
            InitializeComponent();
        }

        private void Add_Note(object sender, RoutedEventArgs e)
        {
            Note n = new Note("Prazno", "",PatientWindow.LoggedPatient.id);
            patientNotes.Add(n);
            NC.CreateNote(n);
        }
        private void DeleteNote(object sender, RoutedEventArgs e)
        {
            Note n = new Note();
            n = (Note)NotesListGrid.SelectedItem;
            patientNotes.Remove((Note)NotesListGrid.SelectedItem);
            NC.DeleteNote(n.noteID);
        }
        private void NotesListGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ShowNote(object sender, RoutedEventArgs e)
        {
            PatientWindow.NavigatePatient.Navigate(new NotePage((Note)NotesListGrid.SelectedItem));
        }
    }
}