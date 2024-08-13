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
    public partial class NewStudioForm : Form
    {
        public NewStudioForm()
        {
            InitializeComponent();
        }

        private void addStudioBtn_Click(object sender, EventArgs e)
        {
            var studio = new Studio();
            studio.Name = studioNameInput.Text;
            studio.Location = studioLocationInput.Text;
            studio.Year = (int)yearInput.Value;
            StudioRepository.CreateStudio(studio);
            this.Hide();
            var studiosForm = new StudiosForm();
            studiosForm.Show();
            studiosForm.Closed += (s, args) => this.Close();
        }
    }
}
