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
            MainViewModel.SelectedNote = MainViewModel.Notes[MainViewModel.Notes.Count-1];
            this.Date_tb.Text = DateTime.Now.ToString();
            this.Name_tb.Text = string.Empty;
            this.Text_tb.Text = string.Empty;
            this.ID_tb.Text = string.Empty;
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            Note temp = new Note() { Title = this.Name_tb.Text, Text = this.Text_tb.Text, Date = DateTime.Now };
            if (this.Name_tb.Text.Equals(string.Empty)) return;
            if (this.ID_tb.Text.Equals(string.Empty)) Add(temp);
            else Update(temp);
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
    }
}
