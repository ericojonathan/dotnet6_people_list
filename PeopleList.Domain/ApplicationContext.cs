using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Extensions.Options;
using PeopleList.Domain.Entities;
using System.Xml.Linq;

namespace PeopleList.Domain
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {            
        }

        public DbSet<Person> People { get; set; }
    }
}
