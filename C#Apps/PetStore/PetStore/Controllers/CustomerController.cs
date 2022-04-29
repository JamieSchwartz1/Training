using PetStore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Users()
        {
            var customers = GetCustomers();
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            //single or default returns the value in the sequence that matches the parameter
            if (customer == null) return HttpNotFound();
            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{ Id = 1, Name = "Janet"},
                new Customer{ Id = 2, Name = "Brad"},
                new Customer{ Id = 3, Name = "Jamie"},
                new Customer{ Id = 4, Name = "Jake"},
                new Customer{ Id = 5, Name = "Kristen"}
            };
        }
    }
}