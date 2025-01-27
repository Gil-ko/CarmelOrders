using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using CarmelOrders.Core.Interfaces;
using CarmelOrders.Core.Services;
using CarmelOrders.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarmelOrders.UI
{
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<CarmelDbContext>(options =>
                options.UseSqlServer("Server=.;Database=CarmelDB;Trusted_Connection=True;"));

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}