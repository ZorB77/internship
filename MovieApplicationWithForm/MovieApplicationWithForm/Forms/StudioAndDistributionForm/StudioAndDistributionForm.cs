using MovieApplicationWithForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace MovieApplicationWithForm.Forms.StudioAndDistributionForm
{
    public partial class StudioAndDistributionForm : Form
    {
        private StudioService studioService;
        private DistributionService distributionService;

        public StudioAndDistributionForm(StudioService studioService, DistributionService distributionService)
        {
            InitializeComponent();
            this.studioService = studioService;
            this.distributionService = distributionService;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                var studios = studioService.GetAllStudios();
                this.studioBindingSource.DataSource = studios.ToList();

                var distributions = distributionService.GetAllDistributions();
                var distributionViewModels = distributions
                    .Select(d => new MovieStudioDistributionViewModel
                    {
                        distributionID = d.id,
                        distributionDate = d.distributionDate,
                        movieName = d.movie.name,
                        studioName = d.studio.name,
                        details = d.details
                    })
                    .ToList();

                this.dataGridViewDistribution.AutoGenerateColumns = true;
                this.movieStudioDistributionBindingSource.DataSource = distributionViewModels;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        private void dataGridViewStudio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
