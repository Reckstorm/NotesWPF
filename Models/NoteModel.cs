using NotesWPF.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NotesWPF.Models
{
    public class NoteModel : BindableBase
    {
        private readonly ObservableCollection<Note> _notes = new ObservableCollection<Note>();
        public readonly ReadOnlyObservableCollection<Note> PublicNotes;
        private Note selectedNote;
        private Context _context = new Context();

        public Note SelectedNote
        {
            get { return selectedNote; }
            set
            {
                selectedNote = value;
                RaisePropertyChanged(nameof(SelectedNote));
            }
        }

        public NoteModel()
        {
            foreach (Note note in _context.Notes)
            {
                _notes.Add(note);
            }
            SelectedNote = _notes[0];
            PublicNotes = new ReadOnlyObservableCollection<Note>(_notes);
        }

        public void AddCommand(Note note)
        {
            _notes.Add(note);
            SelectedNote = note;
        }

        public void RemoveCommand(Note note)
        {
            _notes.Remove(note);
            Remove(note);
            SelectedNote = _notes[0];
        }

        public void SaveCommad(Note note)
        {
            if (note.Text.Equals(string.Empty)) Add(note);
            else Update(note);
        }

        public void Add(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        public void Update(Note note)
        {
            _context.Notes.Update(note);
            _context.SaveChanges();
        }

        public void Remove(Note note)
        {
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }
    }
}
