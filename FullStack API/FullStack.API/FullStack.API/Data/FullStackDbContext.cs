//IF you know how entity framework core works we have to create db context so that can it can be talk to our Database and sql server and postgres database

using FullStack.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API.Data
{
    public class FullStackDbContext: DbContext //This class inherit the DbContext
    {
        public FullStackDbContext(DbContextOptions options) : base(options)//constructor with the option parameter
        {
        }
        public DbSet<Employee> Employees { get; set; }//create property withDbSet
    }
}
