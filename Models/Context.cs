using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesWPF.Models
{
    public class Context : DbContext
    {
        public DbSet<Note> Notes { get; set;}
        public Context() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=WPFNotesDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
