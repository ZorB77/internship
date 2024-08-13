using MovieWinForms.DataAccess;
using MovieWinForms.Models;
using MovieWinForms.MovieForms;
using MovieWinForms.ReviewForms;
using MovieWinForms.RoleForms;
using MovieWinForms.StudioForms;
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
    public partial class Movies : Form
    {
        public Movies()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            movieList.DataSource = MovieRepository.GetMovies();
            movieList.DisplayMember = "Name";
            genreDropdown.DataSource = MovieRepository.GetGenres();
        }
        private void movieList_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeMovieDetails(movieList.SelectedItem as Movie);

        }
        private void changeMovieDetails(Movie movie)
        {
            movieTitleLabel.Text = movie.Name;
            genreLabel.Text = movie.Genre;
            releaseDateLabel.Text = movie.Year.ToString("Y");
            descriptionBox.Text = movie.Description;
            var averageRating = MovieRepository.GetAverageRating(movie.Id);
            if (averageRating == 0)
            {
                averageRatingLabel.Text = "No ratings yet.";
            }
            else
            {
                averageRatingLabel.Text = averageRating.ToString("#.#");
            }
        }

        private void addMovieButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var movieForm = new NewMovie();
            movieForm.Show();
            movieForm.Closed += (s, args) => this.Close();
        }

        private void editSelectedMovie_Click(object sender, EventArgs e)
        {
            this.Hide();
            var movieForm = new EditMovie(movieList.SelectedItem as Movie);
            movieForm.Show();
            movieForm.Closed += (s, args) => this.Close();

        }
        private void viewReviewsBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var reviewsForm = new ReviewsForMovie(movieList.SelectedItem as Movie);
            reviewsForm.Show();
            reviewsForm.Closed += (s, args) => this.Close();

        }

        private void viewRolesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var rolesList = new RolesForMovie(movieList.SelectedItem as Movie);
            rolesList.Show();
            rolesList.Closed += (s, args) => this.Close();

        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            movieList.DataSource = MovieRepository.GetMoviesInRange(startDatePick.Value, endDatePick.Value);
            movieList.DisplayMember = "Name";
        }

        private void genreSubmit_Click(object sender, EventArgs e)
        {
            movieList.DataSource = MovieRepository.GetMoviesByGenre(genreDropdown.SelectedItem.ToString());
            movieList.DisplayMember = "Name";

        }

        private void sortSubmitBtn_Click(object sender, EventArgs e)
        {
            if (sortByBoxInput.Text == "Name")
            {
                movieList.DataSource = MovieRepository.GetSortedMoviesByName();
                movieList.DisplayMember = "Name";
            }
            else if (sortByBoxInput.Text == "Release Date")
            {
                movieList.DataSource = MovieRepository.GetSortedMoviesByReleaseDate();
                movieList.DisplayMember = "Name";
            }
        }

        private void deleteMovieBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this Movie?\nThis will result in deleting all Roles and Reviews associated with this Movie!", "Delete Movie?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var selectedMovie = movieList.SelectedItem as Movie;
                MovieRepository.DeleteMovie(selectedMovie.Id);
                this.OnLoad(e);
            }
            else if (dialogResult == DialogResult.No)
            {
                this.OnLoad(e);
            }
        }

        private void editStudiosBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var selectedMovie = movieList.SelectedItem as Movie;
            var movieStudiosForm = new MovieStudiosForm(selectedMovie.Id);
            movieStudiosForm.Show();
            movieStudiosForm.Closed += (s, args) => this.Close();
        }
    }
}
