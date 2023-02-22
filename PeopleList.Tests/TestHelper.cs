using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly PeopleContext peopleContext;

        public TestHelper()
        { 
            var builder = new DbContextOptionsBuilder<PeopleContext>();
            builder.UseInMemoryDatabase(databaseName: "PeopleDbInMemory");

            var dbContextOptions = builder.Options;
            peopleContext = new PeopleContext(dbContextOptions);
            peopleContext.Database.EnsureDeleted();
            peopleContext.Database.EnsureCreated();
        }

        public PeopleContext GetInMemoryPeopleRepository()
        {
            return peopleContext;
        }
    }
}
