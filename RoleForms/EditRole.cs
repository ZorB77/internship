﻿using MovieWinForms.DataAccess;
using MovieWinForms.Models;
using MovieWinForms.ReviewForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieWinForms.RoleForms
{
    public partial class EditRole : Form
    {
        Role _role;
        Movie _movie;
        public EditRole(Role role, Movie movie)
        {
            InitializeComponent();
            _role = role;
            _movie = movie;
        }

        private void EditRole_Load(object sender, EventArgs e)
        {
            inputRoleName.Text = _role.Name;
        }

        private void saveChangesBtn_Click(object sender, EventArgs e)
        {
            RoleRepository.UpdateRole(_role.Id,inputRoleName.Text);
            MessageBox.Show("Role updated successfully!");
            this.Hide();
            var rolesForMovie = new RolesForMovie(_movie);
            rolesForMovie.Show();
            rolesForMovie.Closed += (s, args) => this.Close();
        }
    }
}
