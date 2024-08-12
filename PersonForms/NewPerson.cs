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
    }
}
