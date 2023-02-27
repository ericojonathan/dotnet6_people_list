using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleList.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPeopleRespository People { get; }     
        int Complete();
        Task<int> CompleteAsync();
    }
}
