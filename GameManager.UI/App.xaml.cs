using GameManager.Lib.Models;
using GameManager.Lib.Repositories;
using GameManager.Lib.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GameManager.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        protected void AppStartup(object sender, StartupEventArgs e)
        {
            var context = _serviceProvider.GetService<GameDbContext>();
            context?.Database.EnsureCreated();
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<GameDbContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MMODB2;Trusted_Connection=True;MultipleActiveResultSets=true"));
            // Add custom repositories
            services.AddScoped<IDataRepository, SQLRepository>();

            // Add custom services
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IAccountService, AccountService>();

            // Add windows
            services.AddTransient<MainWindow>();
        }
    }
}
