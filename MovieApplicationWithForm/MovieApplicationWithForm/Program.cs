using Microsoft.VisualBasic.Logging;
using MovieApplicationWithForm.Services;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace MovieApplicationWithForm
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7108/")
            };

            var movieService = new MovieService(httpClient);
            var personService = new PersonService(httpClient);
            var reviewService = new ReviewService(httpClient);
            var roleService = new RoleService(httpClient);
            var studioService = new StudioService(httpClient);
            var distributionService = new DistributionService(httpClient);
            
            Application.Run(new MainForm(movieService, personService, reviewService,
                roleService, studioService, distributionService));
        }
    }
}
