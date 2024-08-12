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
    public partial class NewReview : Form
    {
        private Movie _movie;
        public NewReview(Movie movie)
        {
            InitializeComponent();
            _movie = movie;
        }

        private void NewReview_Load(object sender, EventArgs e)
        {
            movieNameLabel.Text = _movie.Name;
        }

        private void addReviewBtn_Click(object sender, EventArgs e)
        {
            var dbContext = new MovieDbContext();
            var review = new Review();
            review.Movie = dbContext.Movies.Where(m => m.Id == _movie.Id).FirstOrDefault();
            review.Comment = reviewCommentBox.Text;
            review.Rating = ratingInputValue.Value;
            dbContext.Reviews.Add(review);
            dbContext.SaveChanges();
            MessageBox.Show("Review Added successfully!");
            this.Hide();
            var reviewsForm = new ReviewsForMovie(_movie);
            reviewsForm.Show();
            reviewsForm.Closed += (s, args) => this.Close();
        }
    }
}
