using PeopleList.Core.Models;
using PeopleList.EF;

namespace PeopleList.Repository.People
{
    public class PeopleRepository
    {
        private readonly PeopleInMemoryDbContext _context;
        public PeopleRepository(PeopleInMemoryDbContext context)
        {
            _context = context;            
        }

        public void Delete(object id)
        {
            var person = _context.People.Find(id);
            if (person == null)
                return;
            _context.People.Remove(person);
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.People.ToList();
        }

        public Person? GetById(long id)
        {
            var person = _context.People.FindAsync(id).Result;

            if (person == null)
                return null;

            return person;
        }

        public void Insert(Person person)
        {
            _context.People.Add(person);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Person person)
        {
            _context.People.Update(person);
        }
    }
}
