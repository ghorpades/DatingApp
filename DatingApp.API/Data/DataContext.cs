using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DataContext : DbContext                // DataContext Class with DbContext from Entity Framework
    {
        //construction of DataContext Class with Db Connect Options
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }

        //create a table as Values with Properties in Values table
        public DbSet<Value> Values { get; set; }   // Values is the table

        public DbSet<User> Users { get; set; }


    }
}