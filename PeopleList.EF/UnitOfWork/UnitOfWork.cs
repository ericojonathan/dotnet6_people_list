using PeopleList.Domain;
using PeopleList.Domain.Interfaces;
using PeopleList.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleList.EF.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public IPeopleRespository? People { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges(); 
        }

        public async Task<int> CompleteAsnyc()
        {
            return await _context.SaveChangesAsync();
        }

        public Task<int> CompleteAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
