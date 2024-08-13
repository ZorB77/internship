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

namespace MovieWinForms.MovieForms
{
    public partial class MovieStudiosForm : Form
    {
        private int _movieId;
        private Movie _movie;
        private MovieStudioRepository _repository;
        private IServiceProvider _serviceProvider;
        public MovieStudiosForm(int movieId)
        {
            InitializeComponent();
            _movieId = movieId;
        }

        private void MovieStudiosForm_Load(object sender, EventArgs e)
        {
            _movie = _repository.GetMovieWithStudio(_movieId);
            allStudios.DataSource = StudioRepository.GetStudios();
            allStudios.DisplayMember = "Name";
            allStudios.SelectedItem = null;
            movieNameLabel.Text = _movie.Name;
            studiosForMovie.DataSource = _movie.Studios.ToList();
            studiosForMovie.DisplayMember = "Name";
            studiosForMovie.SelectedItem = null;
        }

        private void addStudioBtn_Click(object sender, EventArgs e)
        {
            var selectedStudio = allStudios.SelectedItem as Studio;
            _repository.AddStudioToMovie(_movie.Id, selectedStudio.Id);
            MovieStudiosForm_Load(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedStudio = studiosForMovie.SelectedItem as Studio;
            _repository.DeleteStudioFromMovie(_movie.Id, selectedStudio.Id);
            MovieStudiosForm_Load(sender, e);
        }
    }
}
