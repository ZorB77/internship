using MovieApplicationWithForm.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MovieApplicationWithForm.Forms
{
    public partial class AddPersonForm : Form
    {
        private readonly PersonService personService;
        public event Action personAdded;

        public AddPersonForm(PersonService personService)
        {
            InitializeComponent();
            this.personService = personService;
        }

        private void AddPersonForm_Load(object sender, EventArgs e)
        {
        }

        private void AddPersonForm_Closing(object sender, CancelEventArgs e)
        {
        }

        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
            string selectedFirstName = textBoxFirstName.Text;
            string selectedLastName = textBoxLastName.Text;
            string selectedCity = textBoxCity.Text;
            string selectedPhoneNumber = textBoxPhoneNumber.Text;
            DateTime birthdate = dateTimePickerBirthdate.Value;

            try
            {
                Person newPerson = new Person
                {
                    firstName = selectedFirstName,
                    lastName = selectedLastName,
                    birthdate = birthdate,
                    city = selectedCity,
                    phone = selectedPhoneNumber
                };

                personService.AddPerson(newPerson);
                MessageBox.Show("Person added successfully!");
                personAdded.Invoke();

                textBoxFirstName.Clear();
                textBoxLastName.Clear();
                textBoxCity.Clear();
                textBoxPhoneNumber.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
