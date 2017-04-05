using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerRepoLab.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            this._context = context;
            Add(new Customer { FirstName = "Chris" , LastName = "Vrey" , Email = "Mymail@gmail.com" , Phone = "071611571" , Address ="Address" , City = "City", State = "State" , PostalAddress = "PostalAddress" });
        }

        public void Add(Customer item)
        {
            _context.Customers.Add(item);
            _context.SaveChanges();
        }

        public Customer Find(int CustomerId)
        {
            return _context.Customers.FirstOrDefault(t => t.CustomerId == CustomerId);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public void Remove(int CustomerId)
        {
            var entity = _context.Customers.First(t => t.CustomerId == CustomerId);
            _context.Customers.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Customer item)
        {
            _context.Customers.Update(item);
            _context.SaveChanges();
        }

 
    }
}
