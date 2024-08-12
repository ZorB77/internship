using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieApplicationWithForm.Forms
{
    public partial class AddMovieForm : Form
    {
        private MyDBContext dbContext;
        public event Action movieAdded;
        public AddMovieForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.dbContext = new MyDBContext();

            this.dbContext.Database.EnsureCreated();
            this.dbContext.movies.Load();
            this.dbContext.persons.Load();
            this.dbContext.roles.Load();
            this.dbContext.reviews.Load();

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.dbContext.Dispose();
            this.dbContext = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string genre = textBoxGenre.Text;
            string description = textBoxDescription.Text;
            DateTime releaseDate = dateTimePicker1.Value;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(genre) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }


            Movie newMovie = new Movie { name = name, genre = genre, description = description, releaseDate = releaseDate };
            dbContext.movies.Add(newMovie);
            dbContext.SaveChanges();

            MessageBox.Show("Movie added successfully!");
            movieAdded.Invoke();

            textBoxName.Clear();
            textBoxGenre.Clear();
            textBoxDescription.Clear();
        }
    }
}
