using PeopleList.Domain;
using PeopleList.Domain.Entities;
using PeopleList.Domain.Interfaces;

namespace PeopleList.EF.Repositories
{
    public class PeopleRepository : GenericRepository<Person>, IPeopleRespository
    {
        
        public PeopleRepository(ApplicationContext context) : base(context)
        {            
        }        
        
        public void AddPerson(Person person)
        {
            _context.Set<Person>().Add(person);
        }

        public Person GetPersonById(int id)
        {
            return _context.Find<Person>(id);
        }

        public void RemovePerson(Person person)
        {
            _context.Set<Person>().Remove(person);
        }

        public void UpdatePerson(Person person)
        {
            _context.Entry(person).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
