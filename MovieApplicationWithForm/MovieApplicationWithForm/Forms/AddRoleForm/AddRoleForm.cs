using MovieApplicationWithForm.Models;
using MovieApplicationWithForm.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MovieApplicationWithForm
{
    public partial class AddRoleForm : Form
    {
        private readonly MovieService movieService;
        private readonly PersonService personService;
        private readonly RoleService roleService;
        public event Action roleAdded;

        public AddRoleForm(MovieService movieService, PersonService personService, RoleService roleService)
        {
            InitializeComponent();
            this.movieService = movieService;
            this.personService = personService;
            this.roleService = roleService;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var movies = movieService.GetAllMovies();
            var movieNames = movies.Select(m => m.name).ToList();
            comboBoxAddRoleMovie.DataSource = movieNames;

            var persons = personService.GetAllPersons();
            var personNames = persons.Select(p => p.firstName).ToList();
            comboBoxAddRolePerson.DataSource = personNames;

            comboBoxAddRoleMovie.SelectedIndex = -1;
            comboBoxAddRolePerson.SelectedIndex = -1;
        }

        private void buttonAddRole_Click(object sender, EventArgs e)
        {
            string selectedMovieName = comboBoxAddRoleMovie.SelectedItem.ToString();
            string selectedPersonName = comboBoxAddRolePerson.SelectedItem.ToString();
            string roleName = textBoxAddRoleName.Text;
            string selectedDescription = textBoxAddRoleDescription.Text;
            int selectedSalary = (int)numericUpDownSalary.Value;

            if (string.IsNullOrWhiteSpace(selectedMovieName) || string.IsNullOrWhiteSpace(selectedPersonName))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            var movies = movieService.GetAllMovies();
            var movie = movies.FirstOrDefault(m => m.name == selectedMovieName);

            var persons = personService.GetAllPersons();
            var person = persons.FirstOrDefault(p => p.firstName == selectedPersonName);

            if (movie == null || person == null)
            {
                MessageBox.Show("Selected movie or person not found.");
                return;
            }


            try
            {
                //var newRole = new Role { name = roleName, movie = movie, person = person, salary = selectedSalary, description = selectedDescription };
                var newRole = new RoleMapper { Name = roleName, MovieID = movie.id, PersonID = person.id, Salary = selectedSalary, Description = selectedDescription };
                roleService.AddRole(newRole);
                MessageBox.Show("Role added successfully!");
                roleAdded.Invoke();

                textBoxAddRoleName.Clear();
                comboBoxAddRoleMovie.SelectedIndex = -1;
                comboBoxAddRolePerson.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
