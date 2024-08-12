using Microsoft.IdentityModel.Tokens;
using MovieWinForms.DataAccess;
using MovieWinForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieWinForms
{
    public partial class NewMovie : Form
    {
        public NewMovie()
        {
            InitializeComponent();
        }

        private void addMovieBtn_Click(object sender, EventArgs e)
        {
            var movie = new Movie();
            movie.Name = titleInput.Text;
            movie.Description = descriptionInput.Text;
            movie.Genre = genreInput.Text;
            var date = new DateTime();
            movie.Year = DateTime.Parse(dateInput.SelectionRange.Start.ToString());
            MovieRepository.CreateMovie(movie);
            this.Hide();
            var movieForm = new Movies();
            movieForm.Show();
            movieForm.Closed += (s, args) => this.Close();
        }

        private void titleInput_Validating(object sender, CancelEventArgs e)
        {
            if (titleInput.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Title cannot be empty!");
                e.Cancel = true;
            }
        }
        private void genreInput_Validating(object sender, CancelEventArgs e)
        {
            if (genreInput.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Genre cannot be empty!");
                e.Cancel = true;
            }
        }

        private void descriptionInput_Validating(object sender, CancelEventArgs e)
        {
            if (descriptionInput.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Genre cannot be empty!");
                e.Cancel = true;
            }
        }

        private void dateInput_Validating(object sender, CancelEventArgs e)
        {
            if (dateInput.SelectionRange.Start > DateTime.Today)
            {
                MessageBox.Show("Date cannot be in the future!");
                e.Cancel = true;
            }
        }
    }
}
