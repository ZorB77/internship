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
    public partial class EditPersonForm : Form
    {
        private Person person;
        private MyDBContext dbContext;
        public event Action personUpdated;

        public EditPersonForm(Person person)
        {
            InitializeComponent();
            this.person = person;
            this.dbContext = new MyDBContext();
            loadPersonDetails();
        }

        private void loadPersonDetails()
        {
            textBoxFirstName.Text = person.firstName;
            textBoxLastName.Text = person.lastName;
            textBoxCity.Text = person.city;
            textBoxPhone.Text = person.phone;
            dateTimePicker1.Value = person.birthdate;
        }

        private void buttonEditPerson_Click(object sender, EventArgs e)
        {
            person.firstName = textBoxFirstName.Text;
            person.lastName = textBoxLastName.Text;
            person.city = textBoxCity.Text;
            person.phone = textBoxPhone.Text;
            person.birthdate = dateTimePicker1.Value;

            dbContext.persons.Update(person);
            dbContext.SaveChanges();
            MessageBox.Show("Person updated successfully!");
            personUpdated.Invoke();
            this.Close();

        }

        private void buttonDeletePerson_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this person?", "Delete Person", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                dbContext.persons.Remove(person);
                dbContext.SaveChanges();
                MessageBox.Show("Person deleted successfully!");
                personUpdated.Invoke();
                this.Close();
            }
        }
    }
}
