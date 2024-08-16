using MovieApplicationWithForm.Services;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MovieApplicationWithForm.Forms.EditMovieForm
{
    public partial class EditMovieForm : Form
    {
        private readonly MovieService movieService;
        private readonly Movie movie;
        public event Action movieUpdated;

        public EditMovieForm(Movie movie, MovieService movieService)
        {
            InitializeComponent();
            this.movie = movie;
            this.movieService = movieService;
            LoadMovieDetails();
        }

        private void LoadMovieDetails()
        {
            textBoxName.Text = movie.name;
            textBoxDescription.Text = movie.description;
            textBoxGenre.Text = movie.genre;
            dateTimePicker1.Value = movie.releaseDate;
        }

        private void buttonEditMovie_Click(object sender, EventArgs e)
        {
            movie.name = textBoxName.Text;
            movie.description = textBoxDescription.Text;
            movie.genre = textBoxGenre.Text;
            movie.releaseDate = dateTimePicker1.Value;

            try
            {
                movieService.UpdateMovie(movie);
                MessageBox.Show("Movie updated successfully!");
                movieUpdated.Invoke();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void buttonDeleteMovie_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this movie?", "Delete Movie", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Debug.WriteLine($"Movie id:{movie.id}");
                    movieService.DeleteMovie(movie.id);
                    MessageBox.Show("Movie deleted successfully!");
                    movieUpdated.Invoke();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}
