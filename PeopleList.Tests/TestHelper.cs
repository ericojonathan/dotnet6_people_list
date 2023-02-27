using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleList.Domain;
using PeopleListAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleList.Tests
{
    public class TestHelper
    {
        private readonly ApplicationContext peopleContext;

        public TestHelper()
        { 
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseInMemoryDatabase(databaseName: "PeopleDbInMemory");

            var dbContextOptions = builder.Options;
            var peopleContext = new ApplicationContext(dbContextOptions);
            peopleContext.Database.EnsureDeleted();
            peopleContext.Database.EnsureCreated();
        }

        public ApplicationContext GetInMemoryPeopleRepository()
        {
            return peopleContext;
        }
    }
}
