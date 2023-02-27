using PeopleListAPI.Controllers;
using PeopleList.Domain.Entities;
using PeopleList.EF.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleList.Domain.Interfaces;
 
namespace PeopleList.Tests
{
    public class testPeopleListAPI
    {
        [Fact]
        public async Task TestGetPersonById()
        {
            // Arrange
            var helper = new TestHelper();
            var repo = helper.GetInMemoryPeopleRepository();
            repo.People.Add(new Person { FirstName = "UserA" });
            IUnitOfWork unitOfWork = new UnitOfWork(repo);
            var controller = new PeopleController(unitOfWork);

            //Act
            var result = await controller.GetPerson(1);

            //Assert
            Assert.Equal("UserA", result?.Value?.FirstName);
        }

        [Fact]
        public async Task TestGetAllPeople()
        {
            // Arrange
            var helper = new TestHelper();
            var repo = helper.GetInMemoryPeopleRepository();
            repo.People.Add(new Person { FirstName = "UserA" });
            repo.People.Add(new Person { FirstName = "UserB" });
            repo.People.Add(new Person { FirstName = "UserC" });
            repo.SaveChanges();
            IUnitOfWork unitOfWork = new UnitOfWork(repo);
            var controller = new PeopleController(unitOfWork);

            //Act
            var result = await controller.GetPeople();

            //Assert
            Assert.Equal(3, result?.Value?.Count());
            Assert.True(result?.Value?.Any(u => u.FirstName == "UserA"));
            Assert.True(result?.Value?.Any(u => u.FirstName == "UserB"));
            Assert.True(result?.Value?.Any(u => u.FirstName == "UserC"));
        }

        [Fact]
        public async Task TestPostPerson()
        {
            // Arrange
            var helper = new TestHelper();
            var repo = helper.GetInMemoryPeopleRepository();
            IUnitOfWork unitOfWork = new UnitOfWork(repo);
            var controller = new PeopleController(unitOfWork);

            // Act
            Person newPerson = new Person { FirstName = "UserA" };
            var result = await controller.PostPerson(newPerson);

            //Assert
            Assert.True(repo.People.First().FirstName == "UserA");
        }

        [Fact]
        public async Task TestCannotPostPersonIfFirstNameIsLessThan3()
        {
            // Arrange
            var helper = new TestHelper();
            var repo = helper.GetInMemoryPeopleRepository();
            IUnitOfWork unitOfWork = new UnitOfWork(repo);
            var controller = new PeopleController(unitOfWork);

            // Act
            Person newPerson = new Person { FirstName = "Us" };
            var result = await controller.PostPerson(newPerson);

            //Assert
            Assert.True(repo.People.Count() == 0);
        }

        [Fact]
        public async Task TestPutPerson()
        {
            // Arrange
            var helper = new TestHelper();
            var repo = helper.GetInMemoryPeopleRepository();
            repo.People.Add(new Person { FirstName = "UserA" });
            repo.People.Add(new Person { FirstName = "UserB" });
            repo.People.Add(new Person { FirstName = "UserC" });
            await repo.SaveChangesAsync();
            IUnitOfWork unitOfWork = new UnitOfWork(repo);
            var controller = new PeopleController(unitOfWork);

            //Act
            var people = await controller.GetPeople();
            Person? putPerson = people?.Value?.Where(p => p.FirstName == "UserB").FirstOrDefault();
            putPerson.FirstName = "UserD";
            await controller.PutPerson(putPerson.ID, putPerson);

            //Assert
            Assert.True(repo.People.Any(p => p.FirstName == "UserD"));
        }

        [Fact]
        public async Task TestCannotPutPersonIfFirstNameIsLessThan3()
        {
            // Arrange
            var helper = new TestHelper();
            var repo = helper.GetInMemoryPeopleRepository();
            repo.People.Add(new Person { FirstName = "UserA" });
            repo.People.Add(new Person { FirstName = "UserB" });
            repo.People.Add(new Person { FirstName = "UserC" });
            await repo.SaveChangesAsync();
            IUnitOfWork unitOfWork = new UnitOfWork(repo);
            var controller = new PeopleController(unitOfWork);

            //Act
            var people = await controller.GetPeople();
            Person? putPerson = people?.Value?.Where(p => p.FirstName == "UserB").FirstOrDefault();
            putPerson.FirstName = "Us";
            await controller.PutPerson(putPerson.ID, putPerson);

            //Assert
            Assert.True(!repo.People.Any(p => p.FirstName == "Us"));
        }

        [Fact]
        public async Task TestDeletePerson()
        {
            // Arrange
            var helper = new TestHelper();
            var repo = helper.GetInMemoryPeopleRepository();
            repo.People.Add(new Person { FirstName = "UserA" });
            repo.People.Add(new Person { FirstName = "UserB" });
            repo.People.Add(new Person { FirstName = "UserC" });
            await repo.SaveChangesAsync();
            IUnitOfWork unitOfWork = new UnitOfWork(repo);
            var controller = new PeopleController(unitOfWork);

            //Act            
            var people = await controller.GetPeople();
            Person? deletePerson = people?.Value?.Where(p => p.FirstName == "UserB").FirstOrDefault();
            await controller.DeletePerson(deletePerson.ID);

            //Assert
            Assert.True(!repo.People.Any(p => p.FirstName == "UserB"));
        }
    }
}
