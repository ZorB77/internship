using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace MovieApplicationWithForm
{
    public partial class MainForm : Form
    {
        private MyDBContext dbContext;
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.dbContext.SaveChanges();

            this.dataGridViewMovies.Refresh();
            this.dataGridViewPersons.Refresh();
            this.dataGridViewReviews.Refresh();
            this.dataGridViewRoles.Refresh();

            MessageBox.Show("Data saved successfully!");
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

            RefreshData();

        }


        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.dbContext.Dispose();
            this.dbContext = null;
        }

        private void dataGridViewMovies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewMovies_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            FilterForm filterForm = new FilterForm();

            filterForm.Show();
        }

        private void linkLabelRoles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddRoleForm addRoleForm = new AddRoleForm();
            addRoleForm.Show();
            addRoleForm.roleAdded += RefreshData;
        }
        private void RefreshData()
        {
            this.movieBindingSource.DataSource = dbContext.movies.Local.ToBindingList();
            this.personBindingSource.DataSource = dbContext.persons.Local.ToBindingList();
            this.roleBindingSource.DataSource = dbContext.roles.Local.ToBindingList();
            this.reviewBindingSource.DataSource = dbContext.reviews.Local.ToBindingList();

            var reviewsWithMovieName = dbContext.reviews
                .Select(r => new ReviewViewModel
                {
                    reviewID = r.reviewID,
                    rating = r.rating,
                    comment = r.comment,
                    movieName = r.movie.name
                })
                .ToList();

            this.dataGridViewReviews.AutoGenerateColumns = true;
            this.dataGridViewReviews.DataSource = reviewsWithMovieName;

            var rolesWithMovieAndPersonName = dbContext.roles
                .Select(r => new RoleViewModel
                {
                    roleID = r.roleID,
                    movieName = r.movie.name,
                    personName = r.person.firstName + ' ' + r.person.lastName,
                    name = r.name
                })
                .ToList();

            this.dataGridViewRoles.AutoGenerateColumns = true;
            this.dataGridViewRoles.DataSource = rolesWithMovieAndPersonName;
        }

        private void linkLabelReviews_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddReviewForm addReviewForm = new AddReviewForm();
            addReviewForm.Show();
            addReviewForm.reviewAdded += RefreshData;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StatisticsForm statisticsForm = new StatisticsForm();
            statisticsForm.Show();
        }
    }
}
