using PetStore.Models;
using PetStore.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    public class PetsController : Controller
    {
        // GET: Pets
        public ActionResult Index()
        {
            var pet = new Pet() { Name = "Sadie", Age = "1 Year", Breed = "Beagle", Gender = 'F', PetId = 5 };
            var customers = new List<Customer>()
            {
                new Customer{Name = "Janet"},
                new Customer{Name = "Brad"}
            };
            var viewModel = new IndexPetViewModel
            {
                Pet = pet,
                Customers = customers
            };
            return View(viewModel);
        }

        public ActionResult Details(int petId)
        {
            var pet = GetPetsList().SingleOrDefault(c => c.PetId == petId);
            if (pet == null)
                return HttpNotFound();
            return View(pet);
        }
        private IEnumerable<Pet> GetPetsList()
        {
            return new List<Pet>{
                new Pet() { Name = "Watson", Age = "2 Years", Breed = "Shar Pei & Golden Retriever mix", Gender = 'M', PetId = 1},
                new Pet() { Name = "Lacy", Age = "3 Years", Breed = "Chow chow", Gender = 'F', PetId = 2},
                new Pet() { Name = "Zuzu", Age = "4 Years", Breed = "Shih Tzu", Gender = 'F', PetId = 3},
                new Pet() { Name = "Buddy", Age = "10 months", Breed = "Cocker Spaniel & King Charles Cavalier mix", Gender = 'M', PetId = 4},
                new Pet() { Name = "Holly", Age = "10 months", Breed = "Cocker Spaniel & King Charles Cavalier mix", Gender = 'F', PetId = 5}
            };
        }
    }
}