using Microsoft.EntityFrameworkCore;
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

namespace MovieWinForms.ReviewForms
{
    public partial class ReviewsForMovie : Form
    {
        private Movie _movie;
        public ReviewsForMovie(Movie movie)
        {
            InitializeComponent();
            _movie = movie;
        }
        private void ReviewsForMovie_Load_1(object sender, EventArgs e)
        {
            movieNameLabel.Text = _movie.Name;
            var dbContext = new MovieDbContext();
            var reviewsList = dbContext.Reviews.Where(m => m.Movie.Id == _movie.Id).ToList();
            reviewsBox.DataSource = reviewsList;
            reviewsBox.DisplayMember = "Rating";

        }
        private void changeReviewDetails(Review review)
        {
            reviewCommentBox.Text = review.Comment;
        }


        private void saveChangesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var addReviewForm = new NewReview(_movie);
            addReviewForm.Show();
            addReviewForm.Closed += (s, args) => this.Close();
        }

        private void reviewsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeReviewDetails(reviewsBox.SelectedItem as Review);
        }

        private void editReviewBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var editReviewForm = new EditReview(reviewsBox.SelectedItem as Review);
            editReviewForm.Show();
            editReviewForm.Closed += (s, args) => this.Close();

        }

        private void deleteReviewBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the review?", "Delete Review", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var selectedReview = reviewsBox.SelectedItem as Review;
                ReviewRepository.DeleteReview(selectedReview.Id);
                MessageBox.Show("Review deleted successfully!");
                ReviewsForMovie_Load_1(sender, e);
            }
            else if (dialogResult == DialogResult.No)
            {
                ReviewsForMovie_Load_1(sender, e);
            }

        }

        private void goBackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var movieList = new MovieWinForms.Movies();
            movieList.Show();
            movieList.Closed += (s, args) => this.Close();
        }
    }
}
