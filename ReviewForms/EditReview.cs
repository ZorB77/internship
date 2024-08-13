using Microsoft.EntityFrameworkCore;
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
    public partial class EditReview : Form
    {
        private Review _review;
        public EditReview(Review review)
        {
            InitializeComponent();
            _review = review;
        }

        private void EditReview_Load(object sender, EventArgs e)
        {
            reviewCommentBox.Text = _review.Comment;
            ratingInputValue.Value = _review.Rating;
        }

        private void saveChangesBtn_Click(object sender, EventArgs e)
        {
            var dbContext = new MovieDbContext();
            var review = dbContext.Reviews.Include(m => m.Movie).Where(m => m.Id == _review.Id).FirstOrDefault();
            review.Comment = reviewCommentBox.Text;
            review.Rating = ratingInputValue.Value;
            dbContext.Reviews.Update(review);
            dbContext.SaveChanges();
            MessageBox.Show("Review Updated successfully!");
            this.Hide();
            var reviewsForm = new ReviewsForMovie(review.Movie);
            reviewsForm.Show();
            reviewsForm.Closed += (s, args) => this.Close();
        }
    }
}
