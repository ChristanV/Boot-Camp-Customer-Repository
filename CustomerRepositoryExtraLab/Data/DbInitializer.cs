using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerRepositoryExtraLab.Models;

namespace CustomerRepositoryExtraLab.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CustomerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            var _Customers = new Customer[]
            {
              new Customer { FirstName = "Chris", LastName = "Vrey", Email = "Mymail@gmail.com", Phone = "071611571", Address = "Address", City = "City", State = "State", PostalAddress = "PostalAddress" }
             };
            foreach (Customer s in _Customers)
            {
                context.Customers.Add(s);
            }
            context.SaveChanges();
        }
    }
}
