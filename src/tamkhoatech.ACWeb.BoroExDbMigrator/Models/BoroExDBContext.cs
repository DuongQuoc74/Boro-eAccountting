using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace tamkhoatech.ACWeb.BoroExDbMigrator.Models;

public class BoroExDBContext : DbContext
{
    public DbSet<NavigationNode> NavigationNodes { get; set; }

    public BoroExDBContext(DbContextOptions<BoroExDBContext> options)
        : base(options)
    {
    }
}
