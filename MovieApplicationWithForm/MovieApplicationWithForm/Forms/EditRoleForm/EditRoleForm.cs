using MovieApplicationWithForm.Models;
using MovieApplicationWithForm.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MovieApplicationWithForm.Forms.EditRoleForm
{
    public partial class EditRoleForm : Form
    {
        private readonly RoleService roleService;
        private readonly MovieService movieService;
        private readonly PersonService personService;
        private readonly Role role;
        public event Action roleUpdated;

        public EditRoleForm(Role role, RoleService roleService, MovieService movieService, PersonService personService)
        {
            InitializeComponent();
            this.role = role;
            this.roleService = roleService;
            this.movieService = movieService;
            this.personService = personService;
            LoadRoleDetails();
        }

        private void LoadRoleDetails()
        {
            var movieNames = movieService.GetAllMovies().Select(m => m.name).ToList();
            comboBoxMovies.DataSource = movieNames;
            comboBoxMovies.SelectedIndex = comboBoxMovies.FindStringExact(role.movie.name);

            var personsNames = personService.GetAllPersons().Select(p => p.firstName).ToList();
            comboBoxPersons.DataSource = personsNames;
            comboBoxPersons.SelectedIndex = comboBoxPersons.FindStringExact(role.person.firstName);

            textBoxDescription.Text = role.description;
            textBoxName.Text = role.name;
            textBoxSalary.Text = role.salary.ToString();
        }

        private void buttonUpdateRole_Click(object sender, EventArgs e)
        {
            role.name = textBoxName.Text;
            role.description = textBoxDescription.Text;
            role.salary = int.Parse(textBoxSalary.Text);

            var movieName = comboBoxMovies.SelectedItem.ToString();
            var personName = comboBoxPersons.SelectedItem.ToString();

            try
            {
                var movie = movieService.GetMovieByName(movieName);
                var person = personService.GetPersonByFirstName(personName);
                role.movie = movie;
                role.person = person;
                var newRole = new RoleMapper { Name = role.name, MovieID = movie.id, PersonID = person.id, Salary = role.salary, Description = role.description };
                roleService.UpdateRole(newRole);
                MessageBox.Show("Role updated successfully!");
                roleUpdated.Invoke();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void buttonDeleteRole_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this role?", "Delete Role", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    roleService.DeleteRole(role.id);
                    MessageBox.Show("Role deleted successfully!");
                    roleUpdated.Invoke();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}
