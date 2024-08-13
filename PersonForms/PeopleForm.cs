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

namespace MovieWinForms.PersonForms
{
    public partial class PeopleForm : Form
    {
        public PeopleForm()
        {
            InitializeComponent();
        }

        private void PeopleForm_Load(object sender, EventArgs e)
        {
            peopleListBox.DataSource = PeopleRepository.GetPeople();
            peopleListBox.DisplayMember = "LastName";
            genreDropdown.DataSource = MovieRepository.GetGenres();
        }

        private void addPersonBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var addPersonForm = new NewPerson();
            addPersonForm.Show();
            addPersonForm.Closed += (s, args) => this.Close();
        }

        private void editPersonBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var editPersonForm = new EditPersonForm(peopleListBox.SelectedItem as Person);
            editPersonForm.Show();
            editPersonForm.Closed += (s, args) => this.Close();
        }

        private void genreSubmit_Click(object sender, EventArgs e)
        {
            peopleListBox.DataSource = PeopleRepository.GetPeopleByGenre(genreDropdown.SelectedItem.ToString());
            peopleListBox.DisplayMember = "LastName";
        }

        private void numberOfRolesSubmit_Click(object sender, EventArgs e)
        {
            int noOfRoles = (int)numberOfRolesInput.Value;
            peopleListBox.DataSource = PeopleRepository.GetPeopleByNumberOfRoles(noOfRoles);
            peopleListBox.DisplayMember = "LastName";
        }

        private void deletePersonBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this Person?\nThis will result in deleting all roles associated with this Person.", "Delete Person?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var selectedPerson = peopleListBox.SelectedItem as Person;
                PeopleRepository.DeletePerson(selectedPerson.Id);
                this.PeopleForm_Load(sender, e);
            }
            else if (dialogResult == DialogResult.No)
            {
                this.PeopleForm_Load(sender, e);
            }
        }
    }
}
