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
    public partial class StudiosForm : Form
    {
        public StudiosForm()
        {
            InitializeComponent();
        }

        private void StudiosForm_Load(object sender, EventArgs e)
        {
            studiosList.DataSource = StudioRepository.GetStudios();
            studiosList.DisplayMember = "Name";
        }

        private void studiosList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeStudioDetails(studiosList.SelectedItem as Studio);
        }
        private void ChangeStudioDetails(Studio studio)
        {
            studioNameLabel.Text = studio.Name;
            studioLocationLabel.Text = studio.Location;
            foundedDateLabel.Text = studio.Year.ToString();
        }

        private void addStudioBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newStudioForm = new NewStudioForm();
            newStudioForm.Show();
            newStudioForm.Closed += (s, args) => this.Close();
        }

        private void edtiStudioBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var editStudioForm = new EditStudioForm(studiosList.SelectedItem as Studio);
            editStudioForm.Show();
            editStudioForm.Closed += (s, args) => this.Close();
        }

        private void deleteStudioBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this Studio?", "Delete Studio?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var selectedStudio = studiosList.SelectedItem as Studio;
                StudioRepository.DeleteStudio(selectedStudio.Id);
                this.OnLoad(e);
            }
            else if (dialogResult == DialogResult.No)
            {
                this.OnLoad(e);
            }
        }
    }
}
