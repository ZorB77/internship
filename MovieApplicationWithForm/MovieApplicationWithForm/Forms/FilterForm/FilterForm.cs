using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieApplicationWithForm.Services;

namespace MovieApplicationWithForm
{
    public partial class FilterForm : Form
    {
        private readonly MovieService movieService;
        private readonly PersonService personService;
        private readonly RoleService roleService;
        private readonly ReviewService reviewService;

        public FilterForm(MovieService movieService, PersonService personService, RoleService roleService, ReviewService reviewService)
        {
            InitializeComponent();
            comboBoxTable.Items.Add("Movies");
            comboBoxTable.Items.Add("Persons");
            comboBoxTable.Items.Add("Roles");
            comboBoxTable.Items.Add("Reviews");
            comboBoxTable.SelectedIndex = -1;

            this.movieService = movieService;
            this.personService = personService;
            this.roleService = roleService;
            this.reviewService = reviewService;
        }

        private void comboBoxTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxColumn.Items.Clear();

            string selectedTable = comboBoxTable.SelectedItem.ToString();

            if (selectedTable == "Movies")
            {
                comboBoxColumn.Items.Add("Name");
                comboBoxColumn.Items.Add("Genre");
                comboBoxColumn.Items.Add("Release Year");
                comboBoxColumn.SelectedIndex = -1;
            }
            else if (selectedTable == "Persons")
            {
                comboBoxColumn.Items.Add("Name");
                comboBoxColumn.Items.Add("City");
                comboBoxColumn.SelectedIndex = -1;
            }
            else if (selectedTable == "Roles")
            {
                comboBoxColumn.Items.Add("Name");
                comboBoxColumn.Items.Add("Description");
                comboBoxColumn.SelectedIndex = -1;
            }
            else if (selectedTable == "Reviews")
            {
                comboBoxColumn.Items.Add("Movie name");
                comboBoxColumn.Items.Add("Comment");
                comboBoxColumn.SelectedIndex = -1;
            }
        }

        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {
            string selectedTable = comboBoxTable.SelectedItem.ToString();
            string selectedColumn = comboBoxColumn.SelectedItem.ToString();
            string filterCriteria = textBoxFilterCriteria.Text;

            applyFilter(selectedTable, selectedColumn, filterCriteria);
        }

        private void applyFilter(string table, string column, string criteria)
        {
            dataGridViewResults.DataSource = null;

            if (table == "Movies")
            {
                var movies = movieService.GetMovies(column, criteria);
                dataGridViewResults.DataSource = movies;
            }
            else if (table == "Persons")
            {
                var persons = personService.GetPersons(column, criteria);
                dataGridViewResults.DataSource = persons;
            }
            else if (table == "Roles")
            {
                var roles = roleService.GetRoles(column, criteria);
                var rolesWithMovieAndPersonName = roles.Select(r => new RoleViewModel
                {
                    roleID = r.id,
                    movieName = movieService.GetMovie(r.movie.id).name,
                    personName = personService.GetPerson(r.person.id).firstName + ' ' + personService.GetPerson(r.person.id).lastName,
                    name = r.name,
                    salary = r.salary,
                    description = r.description
                }).ToList();
                dataGridViewResults.DataSource = rolesWithMovieAndPersonName;
            }
            else if (table == "Reviews")
            {
                var reviews = reviewService.GetReviews(column, criteria);
                var reviewsWithMovieName = reviews.Select(r => new ReviewViewModel
                {
                    reviewID = r.id,
                    rating = r.rating,
                    comment = r.comment,
                    movieName = movieService.GetMovie(r.movie.id).name
                }).ToList();
                dataGridViewResults.DataSource = reviewsWithMovieName;
            }
        }
    }
}
