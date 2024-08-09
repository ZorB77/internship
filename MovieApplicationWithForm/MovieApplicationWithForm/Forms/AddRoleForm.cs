using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;

namespace MovieApplicationWithForm
{
    public partial class AddRoleForm : Form
    {
        private MyDBContext dbContext;
        public event Action roleAdded;

        public AddRoleForm()
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
            comboBoxAddRoleMovie.DataSource = movieNames;

            var personsNames = this.dbContext.persons.Select(p => p.firstName).ToList();
            comboBoxAddRolePerson.DataSource = personsNames;

            comboBoxAddRoleMovie.SelectedIndex = -1;
            comboBoxAddRolePerson.SelectedIndex = -1;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.dbContext.Dispose();
            this.dbContext = null;
        }

        private void buttonAddRole_Click(object sender, EventArgs e)
        {
            string selectedMovie = comboBoxAddRoleMovie.SelectedItem.ToString();
            string selectedPerson = comboBoxAddRolePerson.SelectedItem.ToString();
            string selectedName = textBoxAddRoleName.Text;

            if (string.IsNullOrWhiteSpace(selectedMovie) || string.IsNullOrWhiteSpace(selectedPerson) || string.IsNullOrWhiteSpace(selectedName))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            Movie movie = dbContext.movies.FirstOrDefault(m => m.name == selectedMovie);
            Person person = dbContext.persons.FirstOrDefault(p => p.firstName == selectedPerson);

            if (movie == null || person == null)
            {
                MessageBox.Show("Selected movie or person not found.");
                return;
            }

            Role newRole = new Role{name = selectedName, movie = movie, person = person};
            dbContext.roles.Add(newRole);
            dbContext.SaveChanges();

            MessageBox.Show("Role added successfully!");
            roleAdded.Invoke();

            textBoxAddRoleName.Clear();
            comboBoxAddRoleMovie.SelectedIndex = -1;
            comboBoxAddRolePerson.SelectedIndex = -1;
        }
    }
}
