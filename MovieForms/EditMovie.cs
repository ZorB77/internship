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
    public partial class EditMovie : Form
    {
        private Movie _movie;
        public EditMovie(Movie movie)
        {
            InitializeComponent();
            _movie = movie;
        }

        private void EditMovie_Load(object sender, EventArgs e)
        {
            titleInput.Text = _movie.Name;
            genreInput.Text = _movie.Genre;
            dateInput.SetDate(_movie.Year);
            descriptionInput.Text = _movie.Description;
        }

        private void saveChangesBtn_Click(object sender, EventArgs e)
        {
            _movie.Name = titleInput.Text;
            _movie.Genre = genreInput.Text;
            _movie.Description = descriptionInput.Text;
            _movie.Year = DateTime.Parse(dateInput.SelectionRange.Start.ToString());
            MovieRepository.UpdateMovie(_movie.Id, _movie);
            this.Hide();
            var movieForm = new Movies();
            movieForm.Show();
            movieForm.Closed += (s, args) => this.Close();

        }
    }
}
