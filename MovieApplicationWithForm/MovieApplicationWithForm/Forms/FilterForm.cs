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

namespace MovieApplicationWithForm
{
    public partial class FilterForm : Form
    {
        private MyDBContext dbContext;
        public FilterForm()
        {
            InitializeComponent();
            comboBoxTable.Items.Add("Movies");
            comboBoxTable.Items.Add("Persons");
            comboBoxTable.Items.Add("Roles");
            comboBoxTable.Items.Add("Reviews");
            comboBoxTable.SelectedIndex = -1;
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

        private void comboBoxTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxColumn.Items.Clear();

            string selectedTable = comboBoxTable.SelectedItem.ToString();

            if (selectedTable == "Movies")
            {
                comboBoxColumn.Items.Add("Name");
                comboBoxColumn.Items.Add("Genre");
                comboBoxColumn.Items.Add("Release Year");
                comboBoxColumn.SelectedIndex = -1;
            }

            if (selectedTable == "Persons")
            {
                comboBoxColumn.Items.Add("Name");
                comboBoxColumn.SelectedIndex = -1;
            }

            if (selectedTable == "Roles")
            {
                comboBoxColumn.Items.Add("Role Name");
                comboBoxColumn.Items.Add("Actor");
                comboBoxColumn.SelectedIndex = -1;
            }

            if (selectedTable == "Reviews")
            {
                comboBoxColumn.Items.Add("Rating");
                comboBoxColumn.SelectedIndex = -1;
            }

        }

        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {
            string selectedTable = comboBoxTable.SelectedItem.ToString();
            string selectedColumn = comboBoxColumn.SelectedItem.ToString();
            string filterCriteria = textBoxFilterCriteria.Text;

            applyFilter(selectedTable, selectedColumn, filterCriteria);
        }

        private void applyFilter(string table, string column, string criteria)
        {
            dataGridViewResults.DataSource = null;

            if (table == "Movies")
            {
                var movieQuery = dbContext.movies.AsQueryable();
                if (column == "Name")
                {
                    movieQuery = movieQuery.Where(m => m.name.Contains(criteria));
                }
                else if (column == "Genre")
                {
                    movieQuery = movieQuery.Where(m => m.genre.Contains(criteria));
                }
                else if (column == "Release Year")
                {
                    movieQuery = movieQuery.Where(m => m.releaseDate.Year == int.Parse(criteria));
                }
                dataGridViewResults.DataSource = movieQuery.ToList();
            }

            if (table == "Persons")
            {
                var personQuery = dbContext.persons.AsQueryable();
                if (column == "Name")
                {
                    personQuery = personQuery.Where(p => p.firstName.Contains(criteria) || p.lastName.Contains(criteria));
                }
                dataGridViewResults.DataSource = personQuery.ToList();
            }

            if (table == "Roles") 
            {
                var roleQuery = dbContext.roles.AsQueryable();
                if (column == "Role Name")
                {
                    roleQuery = roleQuery.Where(r => r.name.Contains(criteria));
                }
                else if (column == "Actor")
                {
                    roleQuery = roleQuery.Where(r => r.person.firstName.Contains(criteria) || r.person.lastName.Contains(criteria));
                }
                dataGridViewResults.DataSource = roleQuery.ToList();
            }

            if (table == "Reviews")
            {
                var reviewQuery = dbContext.reviews.AsQueryable();
                if (column == "Rating")
                {
                   reviewQuery = reviewQuery.Where(r => r.rating == int.Parse(criteria));
                }
                dataGridViewResults.DataSource = reviewQuery.ToList();
            }        
            }
        }
    }

