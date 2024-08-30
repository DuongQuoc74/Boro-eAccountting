using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace tamkhoatech.ACWeb.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class ACWebDbContextFactory : IDesignTimeDbContextFactory<ACWebDbContext>
{
    public ACWebDbContext CreateDbContext(string[] args)
    {
        ACWebEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ACWebDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new ACWebDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../tamkhoatech.ACWeb.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
