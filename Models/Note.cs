using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NotesWPF.Models
{
    public class Note
    {
        private int id;
        private string title;
        private string text;
        private DateTime date;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public Note()
        {
            title = string.Empty;
            text = string.Empty;
            date = DateTime.Now;
        }
    }
}
