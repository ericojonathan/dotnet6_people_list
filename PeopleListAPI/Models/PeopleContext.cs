using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace PeopleListAPI.Models
{
    public class PeopleContext: DbContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options) { }
        public DbSet<Person> People { get; set; } = null!;
    }
}
