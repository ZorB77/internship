using MovieApplicationWithForm.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MovieApplicationWithForm.Forms
{
    public partial class AddMovieForm : Form
    {
        private readonly MovieService movieService;
        public event Action movieAdded;

        public AddMovieForm(MovieService movieService)
        {
            InitializeComponent();
            this.movieService = movieService;
        }

        private void AddMovieForm_Load(object sender, EventArgs e)
        {
        }

        private void AddMovieForm_Closing(object sender, CancelEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string genre = textBoxGenre.Text;
            string description = textBoxDescription.Text;
            DateTime releaseDate = dateTimePicker1.Value;

            try
            {
                Movie newMovie = new Movie { name = name, genre = genre, description = description, releaseDate = releaseDate };
                movieService.AddMovie(newMovie);
                MessageBox.Show("Movie added successfully!");

                movieAdded.Invoke();

                textBoxName.Clear();
                textBoxGenre.Clear();
                textBoxDescription.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
