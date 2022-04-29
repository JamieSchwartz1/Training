using PetStore.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    public class PetsController : Controller
    {
        // GET: Pets
        [Route("pets/bystore/{id}")]
        public ActionResult ViewPetsList()
        {
            var pet = GetPetsList();
            return View(pet);
        }
        private IEnumerable<Pet> GetPetsList()
        {
            return new List<Pet>{
                new Pet() { PetId = 1, Name = "Watson", Age = "3 Years and 6 months", Breed = "Golden Retriever", Color = "Gold", Gender = 'M'},
                new Pet() { PetId = 2, Name = "Lacy", Age = "3 Years", Breed = "Chow Chow", Color = "Auburn", Gender = 'F'},
                new Pet() { PetId = 3, Name = "Zuzu", Age = "4 Years", Breed = "Shih Tzu", Color = "Black with white patches", Gender = 'F'},
                new Pet() { PetId = 5, Name = "Holly", Age = "10 months", Breed = "Cocker Spaniel / Cavalier mix", Color = "Black and white", Gender = 'F'},
                new Pet() { PetId = 6, Name = "Minerva", Age = "7 years", Breed = "Short Hair Persian", Color = "Gray and white", Gender = 'F'},
                new Pet() { PetId = 7, Name = "Houdini", Age = "5 years", Breed = "Woma Python", Color = "Green and gray", Gender = 'M'}
            };
        }
    }
}