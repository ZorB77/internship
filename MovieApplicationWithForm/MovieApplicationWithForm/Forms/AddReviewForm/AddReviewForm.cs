using MovieApplicationWithForm.Models;
using MovieApplicationWithForm.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MovieApplicationWithForm
{
    public partial class AddReviewForm : Form
    {
        private readonly MovieService movieService;
        private readonly ReviewService reviewService;
        public event Action reviewAdded;

        public AddReviewForm(MovieService movieService, ReviewService reviewService)
        {
            InitializeComponent();
            this.movieService = movieService;
            this.reviewService = reviewService;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var movies = movieService.GetAllMovies();
            var movieNames = movies.Select(m => m.name).ToList();

            comboBoxAddReviewMovie.DataSource = movieNames;
            comboBoxAddReviewMovie.SelectedIndex = -1;
        }

        private void buttonAddReview_Click(object sender, EventArgs e)
        {
            string selectedMovieName = comboBoxAddReviewMovie.SelectedItem.ToString();
            int selectedRating = (int)numericUpDownRating.Value;
            string selectedComment = textBoxAddReviewComment.Text;

            if (string.IsNullOrWhiteSpace(selectedMovieName) || string.IsNullOrWhiteSpace(selectedComment))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            var movies = movieService.GetAllMovies();
            var movie = movies.FirstOrDefault(m => m.name == selectedMovieName);

            if (movie == null)
            {
                MessageBox.Show("Selected movie not found.");
                return;
            }

            try
            {
                //var newReview = new Review { movie = movie, rating = selectedRating, comment = selectedComment };
                var newReview = new ReviewMapper { MovieID = movie.id, Rating = selectedRating, Comment = selectedComment };
                reviewService.AddReview(newReview);
                MessageBox.Show("Review added successfully!");
                reviewAdded.Invoke();

                textBoxAddReviewComment.Clear();
                comboBoxAddReviewMovie.SelectedIndex = -1;
                numericUpDownRating.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
