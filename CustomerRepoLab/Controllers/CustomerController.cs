using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerRepoLab.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerRepoLab.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRespository;

        public CustomerController(ICustomerRepository todoRository)
        {
            _customerRespository = todoRository;
        }

        // GET: api/values
        [HttpGet]
        [Produces("application/json", Type = typeof(IEnumerable<Customer>))]
        public IEnumerable<Customer> GetAll()
        {
            return _customerRespository.GetAll();
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        [Produces("application/json", Type = typeof(Customer))]
        public IActionResult GetById(int id)
        {
            var item = _customerRespository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            _customerRespository.Add(customer);

            return CreatedAtRoute("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int customerId, [FromBody] Customer customer)
        {
            if (customer == null || customer.CustomerId != customerId)
            {
                return BadRequest();
            }

            var _Customer = _customerRespository.Find(customerId);
            if (_Customer == null)
            {
                return NotFound();
            }

            _Customer.IsComplete = customer.IsComplete;
            _Customer.FirstName = customer.FirstName;
            _Customer.LastName = customer.LastName;
            _Customer.Email = customer.Email;
            _Customer.Phone = customer.Phone;
            _Customer.Address = customer.Address;
            _Customer.City = customer.City;
            _Customer.State = customer.State;
            _Customer.PostalAddress = customer.PostalAddress;

            _customerRespository.Update(_Customer);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _customerRespository.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _customerRespository.Remove(id);
            return new NoContentResult();
        }


    }
}
