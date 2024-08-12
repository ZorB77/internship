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

namespace MovieApplicationWithForm.Forms.StudioAndDistributionForm
{
    public partial class StudioAndDistributionForm : Form
    {
        private MyDBContext dbContext;
        public StudioAndDistributionForm()
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
            this.dbContext.studios.Load();
            this.dbContext.distributions.Load();

            this.studioBindingSource.DataSource = dbContext.studios.Local.ToBindingList();
            //this.movieStudioDistributionBindingSource.DataSource = dbContext.distributions.Local.ToBindingList();

            var distributions = dbContext.distributions
                .Select(r => new MovieStudioDistributionViewModel
                {
                    distributionID = r.distributionID,
                    distributionDate = r.distributionDate,
                    movieName = r.movie.name,
                    studioName = r.studio.name,
                    details = r.details

                })
                .ToList();

            this.dataGridViewDistribution.AutoGenerateColumns = true;
            this.movieStudioDistributionBindingSource.DataSource = distributions;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.dbContext.Dispose();
            this.dbContext = null;
        }

        private void dataGridViewStudio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
