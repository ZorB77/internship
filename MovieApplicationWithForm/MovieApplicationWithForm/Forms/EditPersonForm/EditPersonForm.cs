using MovieApplicationWithForm.Services;
using System;
using System.Windows.Forms;

namespace MovieApplicationWithForm.Forms
{
    public partial class EditPersonForm : Form
    {
        private readonly PersonService personService;
        private readonly Person person;
        public event Action personUpdated;

        public EditPersonForm(Person person, PersonService personService)
        {
            InitializeComponent();
            this.person = person;
            this.personService = personService;
            LoadPersonDetails();
        }

        private void LoadPersonDetails()
        {
            textBoxFirstName.Text = person.firstName;
            textBoxLastName.Text = person.lastName;
            textBoxCity.Text = person.city;
            textBoxPhone.Text = person.phone;
            dateTimePicker1.Value = person.birthdate;
        }

        private void buttonUpdatePerson_Click_1(object sender, EventArgs e)
        {
            person.firstName = textBoxFirstName.Text;
            person.lastName = textBoxLastName.Text;
            person.city = textBoxCity.Text;
            person.phone = textBoxPhone.Text;
            person.birthdate = dateTimePicker1.Value;

            try
            {
                personService.UpdatePerson(person);
                MessageBox.Show("Person updated successfully!");
                personUpdated.Invoke();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void buttonDeletePerson_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this person?", "Delete Person", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    personService.DeletePerson(person.id);
                    MessageBox.Show("Person deleted successfully!");
                    personUpdated.Invoke();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}
