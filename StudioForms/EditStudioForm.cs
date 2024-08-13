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

namespace MovieWinForms.StudioForms
{
    public partial class EditStudioForm : Form
    {
        private Studio _studio;
        public EditStudioForm(Studio studio)
        {
            InitializeComponent();
            _studio = studio;
            
        }

        private void saveChangesBtn_Click(object sender, EventArgs e)
        {
            _studio.Name = studioNameInput.Text;
            _studio.Location = studioLocationInput.Text;
            _studio.Year = (int)yearInput.Value;
            StudioRepository.UpdateStudio(_studio.Id, _studio);
            this.Hide();
            var studiosForm = new StudiosForm();
            studiosForm.Show();
            studiosForm.Closed += (s, args) => this.Close();
        }

        private void EditStudioForm_Load(object sender, EventArgs e)
        {
            studioNameInput.Text = _studio.Name;
            studioLocationInput.Text = _studio.Location;
            yearInput.Value = _studio.Year;
        }
    }
}
