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

namespace MovieWinForms.PersonForms
{
    public partial class NewPerson : Form
    {
        public NewPerson()
        {
            InitializeComponent();
        }

        private void addPersonBtn_Click(object sender, EventArgs e)
        {
            var person = new Person();
            person.FirstName = firstNameInput.Text;
            person.LastName = lastNameInput.Text;
            person.Email = emailInput.Text;
            person.Birthdate = DateTime.Parse(birthDateInput.SelectionRange.Start.ToString());
            PeopleRepository.CreatePerson(person);
            MessageBox.Show("Person added successfully!");
            this.Hide();
            var personList = new PeopleForm();
            personList.Show();
            personList.Closed += (s, args) => this.Close();
        }

        private void firstNameInput_Validating(object sender, CancelEventArgs e)
        {
            if (firstNameInput.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Person needs a First Name!");
                e.Cancel = true;
            }
        }
        private void dateInput_Validating(object sender, CancelEventArgs e)
        {
            if (birthDateInput.SelectionRange.Start > DateTime.Today)
            {
                MessageBox.Show("Birht Date cannot be in the future!");
                e.Cancel = true;
            }
        }

        private void lastNameInput_Validating(object sender, CancelEventArgs e)
        {
            if (lastNameInput.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Person needs a Last Name!");
                e.Cancel = true;
            }

        }
    }
}
