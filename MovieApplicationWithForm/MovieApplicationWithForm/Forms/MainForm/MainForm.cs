using Microsoft.EntityFrameworkCore;
using MovieApplicationWithForm.Forms;
using MovieApplicationWithForm.Forms.EditMovieForm;
using MovieApplicationWithForm.Forms.EditRoleForm;
using MovieApplicationWithForm.Forms.StudioAndDistributionForm;
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
                    name = r.name,
                    salary = r.salary,
                    description = r.description
                })
                .ToList();

            this.dataGridViewRoles.AutoGenerateColumns = true;
            this.dataGridViewRoles.DataSource = rolesWithMovieAndPersonName;

            var movies = dbContext.movies.Select(m => new Movie { description = m.description, genre = m.genre, name = m.name, releaseDate = m.releaseDate, movieID = m.movieID }).ToList();
            this.dataGridViewMovies.DataSource = movies;

            var persons = dbContext.persons.Select(p => new Person { firstName = p.firstName, lastName = p.lastName, birthdate = p.birthdate, personID = p.personID, phone = p.phone, city = p.city }).ToList();
            this.dataGridViewPersons.DataSource = persons;

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

        private void linkLabelMovies_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddMovieForm addMovieForm = new AddMovieForm();
            addMovieForm.Show();
            addMovieForm.movieAdded += RefreshData;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddPersonForm addPersonForm = new AddPersonForm();
            addPersonForm.Show();
            addPersonForm.personAdded += RefreshData;
        }

        private void dataGridViewMovies_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int movieID = (int)dataGridViewMovies.Rows[e.RowIndex].Cells[0].Value;
                var selectedMovie = dbContext.movies.FirstOrDefault(m => m.movieID == movieID);
                if (selectedMovie != null)
                {
                    EditMovieForm editMovieForm = new EditMovieForm(selectedMovie);
                    editMovieForm.Show();
                    editMovieForm.movieUpdated += RefreshData;
                }
            }
            else
            {
                MessageBox.Show("Please choose a non-empty row.");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StudioAndDistributionForm studioAndDistributionForm = new StudioAndDistributionForm();
            studioAndDistributionForm.Show();
        }

        private void dataGridViewPersons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int personID = (int)dataGridViewPersons.Rows[e.RowIndex].Cells[0].Value;
                var selectedPerson = dbContext.persons.FirstOrDefault(m => m.personID == personID);
                if (selectedPerson != null)
                {
                    EditPersonForm editPersonForm = new EditPersonForm(selectedPerson);
                    editPersonForm.Show();
                    editPersonForm.personUpdated += RefreshData;
                }
            }
            else
            {
                MessageBox.Show("Please choose a non-empty row.");
            }
        }

        private void dataGridViewRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int roleID = (int)dataGridViewRoles.Rows[e.RowIndex].Cells[0].Value;
            var selectedRole = dbContext.roles.FirstOrDefault(m => m.roleID == roleID);
            if (selectedRole != null)
            {
                EditRoleForm editRoleForm = new EditRoleForm(selectedRole);
                editRoleForm.Show();
                editRoleForm.roleUpdated += RefreshData;
            }
            else
            {
                MessageBox.Show("Please choose a non-empty row.");
            }
        }
    }
}
