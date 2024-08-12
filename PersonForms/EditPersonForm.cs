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
    public partial class EditPersonForm : Form
    {
        private Person _person;
        public EditPersonForm(Person person)
        {
            InitializeComponent();
            _person = person;
        }

        private void EditPersonForm_Load(object sender, EventArgs e)
        {
            firstNameInput.Text = _person.FirstName;
            lastNameInput.Text = _person.LastName;
            birthDateInput.SetDate(_person.Birthdate);
            emailInput.Text = _person.Email;
        }

        private void saveChangesBtn_Click(object sender, EventArgs e)
        {
            _person.FirstName = firstNameInput.Text;
            _person.LastName = lastNameInput.Text;
            _person.Birthdate = DateTime.Parse(birthDateInput.SelectionRange.Start.ToString());
            _person.Email = emailInput.Text;
            PeopleRepository.UpdatePerson(_person.Id, _person);
            MessageBox.Show("Person updated successfully!");
            this.Hide();
            var personList = new PeopleForm();
            personList.Show();
            personList.Closed += (s, args) => this.Close();
        }
    }
}
