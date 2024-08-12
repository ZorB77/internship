using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieApplicationWithForm.Forms
{
    public partial class AddPersonForm : Form
    {
        private MyDBContext dbContext;
        public event Action personAdded;
        public AddPersonForm()
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

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.dbContext.Dispose();
            this.dbContext = null;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
            string selectedFirstName = textBoxFirstName.Text;
            string selectedLastName = textBoxLastName.Text;
            string selectedCity = textBoxCity.Text;
            string selectedPhoneNumber = textBoxPhoneNumber.Text;
            DateTime birthdate = dateTimePickerBirthdate.Value;

            if (string.IsNullOrEmpty(selectedCity) || string.IsNullOrEmpty(selectedFirstName) || string.IsNullOrEmpty(selectedLastName))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            Person newPerson = new Person { firstName = selectedFirstName, lastName = selectedLastName, birthdate = birthdate, city = selectedCity, phone = selectedPhoneNumber };
            dbContext.persons.Add(newPerson);
            dbContext.SaveChanges();

            MessageBox.Show("Person added successfully!");
            personAdded.Invoke();

            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxCity.Clear();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
