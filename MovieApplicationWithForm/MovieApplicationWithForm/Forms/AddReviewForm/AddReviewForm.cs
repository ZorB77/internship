using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;

namespace MovieApplicationWithForm
{
    public partial class AddReviewForm : Form
    {
        private MyDBContext dbContext;
        public event Action reviewAdded;

        public AddReviewForm()
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

            var movieNames = this.dbContext.movies.Select(m => m.name).ToList();
            comboBoxAddReviewMovie.DataSource = movieNames;


            comboBoxAddReviewMovie.SelectedIndex = -1;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.dbContext.Dispose();
            this.dbContext = null;
        }

        private void buttonAddReview_Click(object sender, EventArgs e)
        {
            string selectedMovie = comboBoxAddReviewMovie.SelectedItem?.ToString();
            int selectedRating = (int)numericUpDownRating.Value;
            string selectedComment = textBoxAddReviewComment.Text;

            if (string.IsNullOrWhiteSpace(selectedMovie) || string.IsNullOrWhiteSpace(selectedComment) || selectedRating < 1 || selectedRating > 10)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            Movie movie = dbContext.movies.FirstOrDefault(m => m.name == selectedMovie);

            if (movie == null)
            {
                MessageBox.Show("Selected movie not found.");
                return;
            }

            Review newReview = new Review { movie = movie, rating = selectedRating, comment = selectedComment };
            dbContext.reviews.Add(newReview);
            dbContext.SaveChanges();

            MessageBox.Show("Review added successfully!");
            reviewAdded.Invoke();

            textBoxAddReviewComment.Clear();
            comboBoxAddReviewMovie.SelectedIndex = -1;
            numericUpDownRating.Value = 0;
        }

    }
}
