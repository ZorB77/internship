using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieWinForms.DataAccess;
using MovieWinForms.MovieForms;
using MovieWinForms.PersonForms;
using System.Windows.Forms;

namespace MovieWinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //var services = new ServiceCollection();
            //services.AddDbContext<MovieDbContext>();
            //services.AddScoped<MovieStudioRepository>();
            //services.AddTransient<MovieStudiosForm>();
            //services.AddTransient<MainForm>();
            //services.AddTransient<Movies>();
            //var serviceProvider = services.BuildServiceProvider();
            //ApplicationConfiguration.Initialize();
            //Application.Run(serviceProvider.GetRequiredService<MainForm>());
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

    }
}