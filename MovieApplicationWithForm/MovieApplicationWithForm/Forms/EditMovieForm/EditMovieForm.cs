using System;
using System.Windows.Forms;

namespace MovieApplicationWithForm.Forms.EditMovieForm
{
    public partial class EditMovieForm : Form
    {
        private Movie movie;
        private MyDBContext dbContext;
        public event Action movieUpdated;

        public EditMovieForm(Movie movie)
        {
            InitializeComponent();
            this.movie = movie;
            this.dbContext = new MyDBContext();
            loadMovieDetails();
        }

        private void loadMovieDetails()
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

            dbContext.movies.Update(movie);
            dbContext.SaveChanges();
            MessageBox.Show("Movie updated successfully!");
            movieUpdated.Invoke();
            this.Close();

        }

        private void buttonDeleteMovie_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this movie?", "Delete Movie", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                dbContext.movies.Remove(movie);
                dbContext.SaveChanges();
                MessageBox.Show("Movie deleted successfully!");
                movieUpdated.Invoke();
                this.Close();
            }
        }
    }
}
