using PetStore.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var user = GetUsersList();
            return View(user);
        }
        private IEnumerable<Customer> GetUsersList()
        {
            return new List<Customer>{
                new Customer() { Id = 1, Name = "Jamie Schwartz", ContactInfo = "Cell", PetPref = "Dog or Cat"},
                new Customer() { Id = 2, Name = "Janet Robey", ContactInfo = "Text", PetPref = "Dog"},
                new Customer() { Id = 3, Name = "Kristen Boba", ContactInfo = "Cell", PetPref = "Dog"},
                new Customer() { Id = 4, Name = "Danielle Shnek", ContactInfo = "Email", PetPref = "Snake"},
                new Customer() { Id = 5, Name = "Olivia Sushi", ContactInfo = "Text", PetPref = "Cat"}
            };
        }
    }
}