using Microsoft.EntityFrameworkCore;
using PeopleListAPI.Models;
using System.Diagnostics;

namespace PeopleList.Tests
{
    public class TestPeopleContext
    {        
        [Fact]
        public void Test_SavingAndFetchingAPersonFirstName()
        {
            var helper = new TestHelper();
            var repo = helper.GetInMemoryPeopleRepository();
            
            repo.People.Add(new Person { FirstName = "UserA" });
            repo.SaveChanges();

            Person? savedPerson = repo.People.SingleOrDefault();

            Assert.Equal("UserA", savedPerson?.FirstName);
        }

        [Fact]
        public void Test_SavingAndFetchingPeopleData()
        {
            var helper = new TestHelper();
            var repo = helper.GetInMemoryPeopleRepository();
            repo.People.AddRange(
                new Person { FirstName = "UserA", LastName = "A1" },
                new Person { FirstName = "UserB", LastName = "B1" },
                new Person { FirstName = "UserC", LastName = "C1" }
            );
            repo.SaveChanges();
            List<Person> savedPeople = repo.People.ToList();
            Assert.True(savedPeople?.Any(p => p.FirstName == "UserA" && p.LastName == "A1"));
            Assert.True(savedPeople?.Any(p => p.FirstName == "UserB" && p.LastName == "B1"));
            Assert.True(savedPeople?.Any(p => p.FirstName == "UserC" && p.LastName == "C1"));
        }

        [Fact]
        public void Test_SavingAndChangingPeopleData()
        {
            var helper = new TestHelper();
            var repo = helper.GetInMemoryPeopleRepository();
            repo.People.AddRange(
                new Person { FirstName = "UserA", LastName = "A1" },
                new Person { FirstName = "UserB", LastName = "B1" },
                new Person { FirstName = "UserC", LastName = "C1" }
            );
            repo.SaveChanges();

            Person? updatePerson = repo.People.Where(p => p.FirstName == "UserB").FirstOrDefault();
            updatePerson.FirstName = "UserD";
            updatePerson.LastName = "D1";
            repo.Update(updatePerson);
            repo.SaveChanges();

            List<Person> savedPeople = repo.People.ToList();
            Assert.True(savedPeople?.Any(p => p.FirstName == "UserD" && p.LastName == "D1"));
        }

        [Fact]
        public void Test_SavingPeopleDataAndDeleteAPerson()
        {
            var helper = new TestHelper();
            var repo = helper.GetInMemoryPeopleRepository();
            repo.People.AddRange(
                new Person { FirstName = "UserA", LastName = "A1" },
                new Person { FirstName = "UserB", LastName = "B1" },
                new Person { FirstName = "UserC", LastName = "C1" }
            );
            repo.SaveChanges();

            Person? deletePerson = repo.People.Where(p => p.FirstName == "UserB").First();           
            repo.Remove(deletePerson);
            repo.SaveChanges();

            List<Person> savedPeople = repo.People.ToList();
            Assert.True(savedPeople?.Any(p => p.FirstName == "UserB") == false);
        }
    }
}