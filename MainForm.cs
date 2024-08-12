using MovieWinForms.DataAccess;
using MovieWinForms.Models;
using MovieWinForms.PersonForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieWinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void viewMoviesBtn_Click(object sender, EventArgs e)
        {
            Form movieForm = new Movies();
            movieForm.ShowDialog();
        }

        private void viewPeopleBtn_Click(object sender, EventArgs e)
        {
            Form peopleForm = new PeopleForm();
            peopleForm.ShowDialog();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            topTenMoviesList.DataSource = MovieRepository.GetTopTenMovies();
            topTenMoviesList.DisplayMember = "Name";
        }
    }
}
