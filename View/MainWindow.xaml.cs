using NotesWPF.Models;
using NotesWPF.ViewModel;
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

namespace NotesWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainVM MainViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel = new MainVM();
            this.DataContext = MainViewModel;
        }

        private void New_btn_Click(object sender, RoutedEventArgs e)
        {
            Note temp = new Note();
            MainViewModel.Notes.Add(temp);
            this.NotesList.SelectedItem = temp;
            this.NotesList.ScrollIntoView(temp);
            this.Date_tb.Text = DateTime.Now.ToString();
            this.Name_tb.Text = string.Empty;
            this.Text_tb.Text = string.Empty;
            this.ID_tb.Text = string.Empty;
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            SaveNote(this.NotesList.SelectedItem as Note);
        }

        private void SaveNote(Note note)
        {
            if (note == null) return;
            note.Title = this.Name_tb.Text;
            note.Text = this.Text_tb.Text;
            note.Date = DateTime.Now;
            if (this.Name_tb.Text.Equals(string.Empty) || this.Text_tb.Text.Equals(string.Empty)) return;
            if (this.ID_tb.Text.Equals(string.Empty)) Add(note);
            else Update(note);
        }

        private void Add(Note note)
        {
            MainViewModel.context.Notes.Add(note);
            MainViewModel.context.SaveChanges();
        }

        private void Update(Note note)
        {
            MainViewModel.context.Notes.Update(note);
            MainViewModel.context.SaveChanges();
        }

        private void Remove(Note note)
        {
            MainViewModel.context.Notes.Remove(note);
            MainViewModel.context.SaveChanges();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveNote(this.NotesList.SelectedItem as Note);
        }

        private void NotesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SaveNote(this.NotesList.SelectedItem as Note);
        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            Button t = sender as Button;
            Note temp = t.DataContext as Note;
            Remove(temp);
            MainViewModel.Notes.Remove(temp);
            NotesList.SelectedIndex = 0;
        }
    }
}
