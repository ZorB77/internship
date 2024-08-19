using MovieApplicationWithForm.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MovieApplicationWithForm
{
    public partial class StatisticsForm : Form
    {
        private readonly MovieService movieService;
        private readonly ReviewService reviewService;

        public StatisticsForm(MovieService movieService, ReviewService reviewService)
        {
            InitializeComponent();
            this.movieService = movieService;
            this.reviewService = reviewService;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LoadMoviesIntoComboBox();
            topBestMovies();
        }

        private void LoadMoviesIntoComboBox()
        {
            var movies = movieService.GetAllMovies();
            var movieNames = movies.Select(m => m.name).ToList();
            comboBoxStatisticsMovie.DataSource = movieNames;
            comboBoxStatisticsMovie.SelectedIndex = -1;
        }

        private void comboBoxStatisticsMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedMovieName = comboBoxStatisticsMovie.Text;
            if (string.IsNullOrWhiteSpace(selectedMovieName))
            {
                labelAverageRating.Text = "No movie selected.";
                return;
            }

            var reviews = movieService.GetAllReviewsForMovie(selectedMovieName);
            if (reviews.Any())
            {
                var averageRating = reviews.Average(r => r.rating);
                labelAverageRating.Text = averageRating.ToString("F2");
            }
            else
            {
                labelAverageRating.Text = "No ratings available.";
            }
        }

        private void topBestMovies()
        {
            listViewTopMovies.View = View.Details;
            listViewTopMovies.Columns.Clear();
            listViewTopMovies.Columns.Add("Movie Name", 200);
            listViewTopMovies.Columns.Add("Average Rating", 120);

            var topMovies = reviewService.GetAllReviews().GroupBy(r => r.movie).Select(g => new
            {
                movie = g.Key,
                averageRating = g.Average(r => r.rating)
            }).OrderByDescending(m => m.averageRating).Take(10).ToList();

            listViewTopMovies.Items.Clear();

            foreach (var movie in topMovies)
            {
                var listViewItem = new ListViewItem(movie.movie.name);
                listViewItem.SubItems.Add(movie.averageRating.ToString());
                listViewTopMovies.Items.Add(listViewItem);
            }
        }
    }
}
