using PeopleList.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleList.Domain.Interfaces
{
    public interface IPeopleRespository: IGenericRepository<Person>
    {
        Person GetPersonById(int id);
        void AddPerson(Person person);
        void UpdatePerson(Person person);
        void RemovePerson(Person person);
    }
}
