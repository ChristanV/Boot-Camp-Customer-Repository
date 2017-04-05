using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRepoLab.Models
{
    public interface ICustomerRepository
    {
        void Add(Customer item);
        IEnumerable<Customer> GetAll();
        Customer Find(int CustomerId);
        void Remove(int CustomerId);
        void Update(Customer item);
    }
}
