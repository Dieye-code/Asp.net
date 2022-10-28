 using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace MyProject.Models;

public class DatabaseContext : DbContext
{

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
        if (databaseCreator != null)
        {
            //create database
            if (!databaseCreator.CanConnect()) databaseCreator.Create();

            //create Tables
            if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
        }
    }
    /*public static bool Remove<TConvention>(System.Collections.Generic.IList<TConvention> conventionsList, Type existingConventionType);*/

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }



}
