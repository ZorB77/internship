using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieApplicationWithForm
{
    public partial class StatisticsForm : Form
    {
        private MyDBContext dbContext;
        public StatisticsForm()
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
            comboBoxStatisticsMovie.DataSource = movieNames;


            comboBoxStatisticsMovie.SelectedIndex = -1;

            topBestMovies();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.dbContext.Dispose();
            this.dbContext = null;
        }

        private void comboBoxStatisticsMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ratings = this.dbContext.reviews.Where(r => r.movie.name == comboBoxStatisticsMovie.Text).Select(r => r.rating).ToList();

            if (ratings.Any())
            {
                var averageRating = ratings.Average();

                labelAverageRating.Text = averageRating.ToString();
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

            var topMovies = this.dbContext.reviews.GroupBy(r => r.movie).Select(g => new
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
