using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerRepositoryExtraLab.Models;
using Microsoft.EntityFrameworkCore;
using CustomerRepositoryExtraLab.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerRepositoryExtraLab.Controllers
{
    public class CustomerController : Controller
    {
        // GET: /<controller>/
        private readonly CustomerContext _context;

        public CustomerController(CustomerContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }
    }
}
