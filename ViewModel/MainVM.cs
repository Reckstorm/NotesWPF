using NotesWPF.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesWPF.ViewModel
{
    public class MainVM : BindableBase
    {
        readonly NoteModel _model = new NoteModel();
        private Note selectedNote;
        public MainVM() 
        {
            _model.PropertyChanged += (s, e) => RaisePropertyChanged(e.PropertyName);
            AddCommand = new DelegateCommand(() =>
            {
                _model.AddCommand(new Note() { Date = DateTime.Now});
            });
            RemoveCommand = new DelegateCommand<Note>(note =>
            {
                _model.RemoveCommand(note);
            });
            SaveCommand = new DelegateCommand<Note>(note =>
            {
                if (note == null) return;
                if (note.Text.Equals(string.Empty) || note.Text.Equals(string.Empty)) return;
                else _model.SaveCommad(note);
            });
        }
        public DelegateCommand AddCommand { get; }
        public DelegateCommand<Note> RemoveCommand { get; }
        public DelegateCommand<Note> SaveCommand { get; }
        public ReadOnlyObservableCollection<Note> Notes => _model.PublicNotes;

        public Note SelectedNote
        {
            get { return _model.SelectedNote; }
            set { _model.SelectedNote = value; }
        }

    }
}
