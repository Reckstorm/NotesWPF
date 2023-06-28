using NotesWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NotesWPF.ViewModel
{
    public class MainVM
    {
        public ObservableCollection<Note> Notes { get; set; }
        private Note selectedNote;
        public Context context = new Context();

        public Note SelectedNote
        {
            get { return selectedNote; }
            set { selectedNote = value; }
        }

        public MainVM()
        {
            Notes = new ObservableCollection<Note>();

            foreach (Note note in context.Notes)
            {
                Notes.Add(note);
            }
            //SelectedNote = Notes[0];
        }
    }
}
