// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using tamkhoatech.ACWeb.BoroExDbMigrator;
using tamkhoatech.ACWeb.BoroExDbMigrator.Models;
using tamkhoatech.ACWeb.EntityFrameworkCore;

Console.WriteLine("Start transfer");

var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
var optionsBuilder = new DbContextOptionsBuilder<BoroExDBContext>()
    .UseSqlServer(config.GetConnectionString("BoroExDB"))
    .EnableDetailedErrors();

using (var boroExDbContext = new BoroExDBContext(optionsBuilder.Options))
{
    if (boroExDbContext.Database.CanConnect())
    {
        Console.WriteLine("Connected to ketoandb database");
        var exoptionsBuilder = new DbContextOptionsBuilder<ACWebDbContext>()
                .UseSqlServer(config.GetConnectionString("ACWebDB"))
                .EnableDetailedErrors();

        using (var acWebDbContext = new ACWebDbContext(exoptionsBuilder.Options))
        {
            if (acWebDbContext.Database.CanConnect())
            {
                Console.WriteLine("Connected to acweb database");
                var dataTransferService = new DataTransferService(boroExDbContext, acWebDbContext);
                Console.WriteLine("Transferring navigation nodes");
                dataTransferService.TransferNavigationNodes();
            }
            else
            {
                Console.WriteLine("Failed to connect to acweb database");
            }
        }
    }
    else
    {
        Console.WriteLine("Failed to connect to ketoandb database");
    }
    
}
Console.WriteLine("Transfer complete. Press any key to exit.");
Console.ReadKey();