using Microsoft.EntityFrameworkCore;
using MovieApplicationWithForm.Forms;
using MovieApplicationWithForm.Forms.EditMovieForm;
using MovieApplicationWithForm.Forms.EditRoleForm;
using MovieApplicationWithForm.Forms.StudioAndDistributionForm;
using MovieApplicationWithForm.Services;
using MovieApplicationWithForm.Utilities;
using System.ComponentModel;
using System.Diagnostics;

namespace MovieApplicationWithForm
{
    public partial class MainForm : Form
    {
        private MovieService movieService;
        private PersonService personService;
        private ReviewService reviewService;
        private RoleService roleService;
        private StudioService studioService;
        private DistributionService distributionService;
        private LogWriter logWriter;

        public MainForm(MovieService movieService, PersonService personService, ReviewService reviewService,
            RoleService roleService, StudioService studioService, DistributionService distributionService, LogWriter logWriter)
        {
            InitializeComponent();
            this.movieService = movieService;
            this.personService = personService;
            this.reviewService = reviewService;
            this.roleService = roleService;
            this.studioService = studioService;
            this.distributionService = distributionService;
            this.logWriter = logWriter;

            logWriter.Log("MainForm initialized.");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.dataGridViewMovies.Refresh();
            this.dataGridViewPersons.Refresh();
            this.dataGridViewReviews.Refresh();
            this.dataGridViewRoles.Refresh();

            MessageBox.Show("Data saved successfully!");
            logWriter.Log("Data saved successfully.");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            logWriter.Log("MainForm loaded.");
            RefreshData();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            logWriter.Log("MainForm closed.");
        }

        private void RefreshData()
        {
            var movies = movieService.GetAllMovies();
            this.movieBindingSource.DataSource = movies;

            var persons = personService.GetAllPersons();
            this.personBindingSource.DataSource = persons;

            var roles = roleService.GetAllRoles();
            this.roleBindingSource.DataSource = roles;

            var reviews = reviewService.GetAllReviews();
            this.reviewBindingSource.DataSource = reviews;

            var reviewsWithMovieName = reviews.Select(r => new ReviewViewModel
            {
                reviewID = r.id,
                rating = r.rating,
                comment = r.comment,
                movieName = movieService.GetMovie(r.movie.id).name
            }).ToList();

            this.dataGridViewReviews.AutoGenerateColumns = true;
            this.dataGridViewReviews.DataSource = reviewsWithMovieName;

            var rolesWithMovieAndPersonName = roles.Select(r => new RoleViewModel
            {
                roleID = r.id,
                movieName = movieService.GetMovie(r.movie.id).name,
                personName = personService.GetPerson(r.person.id).firstName + ' ' + personService.GetPerson(r.person.id).lastName,
                name = r.name,
                salary = r.salary,
                description = r.description
            }).ToList();

            this.dataGridViewRoles.AutoGenerateColumns = true;
            this.dataGridViewRoles.DataSource = rolesWithMovieAndPersonName;

            logWriter.Log("Data refreshed.");
        }

        private void dataGridViewMovies_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int movieID = (int)dataGridViewMovies.Rows[e.RowIndex].Cells[0].Value;
                var selectedMovie = movieService.GetMovie(movieID);
                if (selectedMovie != null)
                {
                    EditMovieForm editMovieForm = new EditMovieForm(selectedMovie, movieService);
                    editMovieForm.Show();
                    editMovieForm.movieUpdated += RefreshData;

                    logWriter.Log($"Opened EditMovieForm for movie with id {movieID}.");
                }
            }
            else
            {
                MessageBox.Show("Please choose a non-empty row.");
            }
        }

        private void dataGridViewPersons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int personID = (int)dataGridViewPersons.Rows[e.RowIndex].Cells[0].Value;
                var selectedPerson = personService.GetPerson(personID);
                if (selectedPerson != null)
                {
                    EditPersonForm editPersonForm = new EditPersonForm(selectedPerson, personService);
                    editPersonForm.Show();
                    editPersonForm.personUpdated += RefreshData;

                    logWriter.Log($"Opened EditPersonForm for person with id {personID}.");
                }
            }
            else
            {
                MessageBox.Show("Please choose a non-empty row.");
            }
        }

        private void dataGridViewRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int roleID = (int)dataGridViewRoles.Rows[e.RowIndex].Cells[0].Value;
                var selectedRole = roleService.GetRole(roleID);
                if (selectedRole != null)
                {
                    EditRoleForm editRoleForm = new EditRoleForm(selectedRole, roleService, movieService, personService);
                    editRoleForm.Show();
                    editRoleForm.roleUpdated += RefreshData;

                    logWriter.Log($"Opened EditRoleForm for role with id {roleID}.");
                }
            }
            else
            {
                MessageBox.Show("Please choose a non-empty row.");
            }
        }

        private void linkLabelMovies_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddMovieForm addMovieForm = new AddMovieForm(movieService);
            addMovieForm.Show();
            addMovieForm.movieAdded += RefreshData;

            logWriter.Log("Opened AddMovieForm.");
        }

        private void linkLabelReviews_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddReviewForm addReviewForm = new AddReviewForm(movieService, reviewService);
            addReviewForm.Show();
            addReviewForm.reviewAdded += RefreshData;

            logWriter.Log("Opened AddReviewForm.");
        }

        private void linkLabelRoles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddRoleForm addRoleForm = new AddRoleForm(movieService, personService, roleService);
            addRoleForm.Show();
            addRoleForm.roleAdded += RefreshData;

            logWriter.Log("Opened AddRoleForm.");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddPersonForm addPersonForm = new AddPersonForm(personService);
            addPersonForm.Show();
            addPersonForm.personAdded += RefreshData;

            logWriter.Log("Opened AddPersonForm.");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StudioAndDistributionForm studioAndDistributionForm = new StudioAndDistributionForm(studioService, distributionService);
            studioAndDistributionForm.Show();

            logWriter.Log("Opened StudioAndDistributionForm.");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StatisticsForm statisticsForm = new StatisticsForm(movieService, reviewService);
            statisticsForm.Show();

            logWriter.Log("Opened StatisticsForm.");
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            FilterForm filterForm = new FilterForm(movieService, personService, roleService, reviewService);
            filterForm.Show();

            logWriter.Log("Opened FilterForm.");
        }
    }
}
