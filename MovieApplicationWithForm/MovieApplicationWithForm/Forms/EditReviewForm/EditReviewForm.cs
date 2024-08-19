using MovieApplicationWithForm.Models;
using MovieApplicationWithForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieApplicationWithForm.Forms.EditReviewForm
{
    public partial class EditReviewForm : Form
    {
        private readonly ReviewService reviewService;
        private readonly MovieService movieService;
        private readonly Review review;
        public event Action reviewUpdated;

        public EditReviewForm(Review review, ReviewService reviewService, MovieService movieService)
        {
            InitializeComponent();
            this.review = review;
            this.movieService = movieService;
            this.reviewService = reviewService;
            LoadReviewDetails();
        }

        private void LoadReviewDetails()
        {
            var movieNames = movieService.GetAllMovies().Select(m => m.name).ToList();
            comboBoxMovies.DataSource = movieNames;
            comboBoxMovies.SelectedIndex = comboBoxMovies.FindStringExact(review.movie.name);


            textBoxComment.Text = review.comment;
            numericUpDownRating.Value = review.rating;

        }

        private void buttonUpdateReview_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonDeleteReview_Click(object sender, EventArgs e)
        {

        }

        private void EditReviewForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonDeleteReview_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this review?", "Delete Review", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    reviewService.DeleteReview(review.id);
                    MessageBox.Show("Review deleted successfully!");
                    reviewUpdated.Invoke();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void buttonUpdateReview_Click_1(object sender, EventArgs e)
        {
            review.comment = textBoxComment.Text;
            review.rating = (int)numericUpDownRating.Value;

            var movieName = comboBoxMovies.SelectedItem.ToString();

            try
            {
                var movie = movieService.GetMovieByName(movieName);
                review.movie = movie;
                var newReview = new ReviewMapper { Comment = review.comment, MovieID = movie.id, Rating = review.rating };
                reviewService.UpdateReview(newReview);
                MessageBox.Show("Review updated successfully!");
                reviewUpdated.Invoke();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
