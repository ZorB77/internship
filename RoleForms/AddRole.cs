using Microsoft.IdentityModel.Tokens;
using MovieWinForms.DataAccess;
using MovieWinForms.Models;
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
    public partial class AddRole : Form
    {
        Movie _movie;
        Person _selectedPerson;
        public AddRole(Movie movie)
        {
            InitializeComponent();
            _movie = movie;
        }

        private void personList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPerson = personList.SelectedItem as Person;
        }

        private void AddRole_Load(object sender, EventArgs e)
        {
            var peopleList = PeopleRepository.GetPeople();
            personList.DataSource = peopleList;
            personList.DisplayMember = "LastName";

            movieNameLabel.Text = _movie.Name;
        }

        private void addRoleBtn_Click(object sender, EventArgs e)
        {
            RoleRepository.CreateRole(_movie.Id, _selectedPerson.Id, roleNameInput.Text);
            MessageBox.Show("Succesffully added role!");
            this.Hide();
            var rolesList = new RolesForMovie(_movie);
            rolesList.Show();
            rolesList.Closed += (s, args) => this.Close();

        }

        private void roleNameInput_Validating(object sender, CancelEventArgs e)
        {
            if (roleNameInput.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Enter a name for the role!");
                e.Cancel = true;
            }
        }
    }
}
