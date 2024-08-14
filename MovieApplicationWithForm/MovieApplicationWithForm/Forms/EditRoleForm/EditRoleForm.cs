using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieApplicationWithForm.Forms.EditRoleForm
{

    public partial class EditRoleForm : Form
    {

        private Role role;
        private MyDBContext dbContext;
        public event Action roleUpdated;
        public EditRoleForm(Role role)
        {
            InitializeComponent();
            this.role = role;
            this.dbContext = new MyDBContext();
            loadRoleDetails();

        }

        private void loadRoleDetails()
        {
            var movieNames = this.dbContext.movies.Select(m => m.name).ToList();
            comboBoxMovies.DataSource = movieNames;
            comboBoxMovies.SelectedIndex = comboBoxMovies.FindStringExact(role.movie.name);

            var personsNames = this.dbContext.persons.Select(p => p.firstName).ToList();
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

            Movie movie = dbContext.movies.FirstOrDefault(m => m.name == comboBoxMovies.SelectedItem.ToString());
            Person person = dbContext.persons.FirstOrDefault(p => p.firstName == comboBoxPersons.SelectedItem.ToString());
            role.movie = movie;
            role.person = person;

            dbContext.roles.Update(role);
            dbContext.SaveChanges();
            MessageBox.Show("Role updated successfully!");
            roleUpdated.Invoke();
            this.Close();
        }

        private void buttonDeleteRole_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this role?", "Delete Role", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                dbContext.roles.Remove(role);
                dbContext.SaveChanges();
                MessageBox.Show("Role deleted successfully!");
                roleUpdated.Invoke();
                this.Close();
            }
        }
    }
}
