using Microsoft.EntityFrameworkCore;
using MovieApplicationWithForm.Forms;
using MovieApplicationWithForm.Forms.EditMovieForm;
using MovieApplicationWithForm.Forms.EditReviewForm;
using MovieApplicationWithForm.Forms.EditRoleForm;
using MovieApplicationWithForm.Forms.StudioAndDistributionForm;
using MovieApplicationWithForm.Services;
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

        public MainForm(MovieService movieService, PersonService personService, ReviewService reviewService,
            RoleService roleService, StudioService studioService, DistributionService distributionService)
        {
            InitializeComponent();
            this.movieService = movieService;
            this.personService = personService;
            this.reviewService = reviewService;
            this.roleService = roleService;
            this.studioService = studioService;
            this.distributionService = distributionService;

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.dataGridViewMovies.Refresh();
            this.dataGridViewPersons.Refresh();
            this.dataGridViewReviews.Refresh();
            this.dataGridViewRoles.Refresh();

            MessageBox.Show("Data saved successfully!");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RefreshData();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
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

        }

        private void linkLabelReviews_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddReviewForm addReviewForm = new AddReviewForm(movieService, reviewService);
            addReviewForm.Show();
            addReviewForm.reviewAdded += RefreshData;

        }

        private void linkLabelRoles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddRoleForm addRoleForm = new AddRoleForm(movieService, personService, roleService);
            addRoleForm.Show();
            addRoleForm.roleAdded += RefreshData;

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddPersonForm addPersonForm = new AddPersonForm(personService);
            addPersonForm.Show();
            addPersonForm.personAdded += RefreshData;

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StudioAndDistributionForm studioAndDistributionForm = new StudioAndDistributionForm(studioService, distributionService);
            studioAndDistributionForm.Show();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StatisticsForm statisticsForm = new StatisticsForm(movieService, reviewService);
            statisticsForm.Show();

        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            FilterForm filterForm = new FilterForm(movieService, personService, roleService, reviewService);
            filterForm.Show();

        }

        private void dataGridViewReviews_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int reviewID = (int)dataGridViewReviews.Rows[e.RowIndex].Cells[0].Value;
                var selectedReview = reviewService.GetReview(reviewID);
                if (selectedReview != null)
                {
                    EditReviewForm editReviewForm = new EditReviewForm(selectedReview, reviewService, movieService);
                    editReviewForm.Show();
                    editReviewForm.reviewUpdated += RefreshData;

                }
            }
            else
            {
                MessageBox.Show("Please choose a non-empty row.");
            }
        }
    }
}
