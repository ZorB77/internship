using MovieWinForms.DataAccess;
using MovieWinForms.Models;
using MovieWinForms.ReviewForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieWinForms.RoleForms
{
    public partial class RolesForMovie : Form
    {
        Movie _movie;
        public RolesForMovie(Movie movie)
        {
            InitializeComponent();
            _movie = movie;
        }

        private void RolesForMovie_Load(object sender, EventArgs e)
        {
            rolesList.DataSource = RoleRepository.GetRolesForMovie(_movie.Id);
            rolesList.DisplayMember = "Name";
            movieNameLabel.Text = _movie.Name;
        }

        private void saveChangesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var addRoleForm = new AddRole(_movie);
            addRoleForm.Show();
            addRoleForm.Closed += (s, args) => this.Close();
        }

        private void rolesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var role = rolesList.SelectedItem as Role;
            var roleFromDb = RoleRepository.GetRoleById(role.Id);
            changeCharacterDetails(role, role.Person);

        }
        private void changeCharacterDetails(Role role, Person person)
        {
            roleNameLabel.Text = role.Name;
            actorNameLabel.Text = person.FirstName + " " + person.LastName;
        }

        private void editRoleBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var editRoleForm = new EditRole(rolesList.SelectedItem as Role, _movie);
            editRoleForm.Show();
            editRoleForm.Closed += (s, args) => this.Close();

        }

        private void goBackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var moviesForm = new Movies();
            moviesForm.Show();
            moviesForm.Closed += (s, args) => this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this role?", "Delete role", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var selectedRole= rolesList.SelectedItem as Role;
                RoleRepository.DeleteRole(selectedRole.Id);
                MessageBox.Show("Role deleted successfully!");
                RolesForMovie_Load(sender, e);
            }
            else if (dialogResult == DialogResult.No)
            {
                RolesForMovie_Load(sender, e);
            }
        }
    }
}
