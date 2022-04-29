using PetStore.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    public class PetsController : Controller
    {
        // GET: Pets
        public ActionResult Index()
        {
            var pet = GetPetsList();
            return View(pet);
        }
        public ActionResult Details()
        {
            var pet = GetPetsList();
            if (pet == null)
                return HttpNotFound();
            return View(pet);
        }
        private IEnumerable<Pet> GetPetsList()
        {
            return new List<Pet>{
                new Pet() { PetId = 1, Name = "Watson", Age = "3 Years and 6 months", Breed = "Shar Pei & Golden Retriever mix", Gender = 'M'},
                new Pet() { PetId = 2, Name = "Lacy", Age = "3 Years", Breed = "Chow Chow", Gender = 'F'},
                new Pet() { PetId = 3, Name = "Zuzu", Age = "4 Years", Breed = "Shih Tzu", Gender = 'F'},
                new Pet() { PetId = 4, Name = "Buddy", Age = "10 months", Breed = "Cocker Spaniel & King Charles Cavalier mix", Gender = 'M'},
                new Pet() { PetId = 5, Name = "Holly", Age = "10 months", Breed = "Cocker Spaniel & King Charles Cavalier mix", Gender = 'F'},
                new Pet() { PetId = 6, Name = "Sadie", Age = "3 years", Breed = "Hairless Sphinx", Gender = 'F'},
                new Pet() { PetId = 7, Name = "Houdini", Age = "5 years", Breed = "Woma Python", Gender = 'M'}
            };
        }
    }
}