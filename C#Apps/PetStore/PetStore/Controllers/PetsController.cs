using PetStore.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    public class PetsController : Controller
    {
        // GET: Pets
        public ActionResult Details()
        {
            var pets = new List<Pet>{
                new Pet() { PetId = 1, Name = "Watson", Age = "3 Years and 6 months", Breed = "Dog", Color = "Gold", Gender = 'M'},
                new Pet() { PetId = 2, Name = "Lacy", Age = "3 Years", Breed = "Dog", Color = "Auburn", Gender = 'F'},
                new Pet() { PetId = 3, Name = "Zuzu", Age = "4 Years", Breed = "Dog", Color = "Black with white spots", Gender = 'F'},
                new Pet() { PetId = 5, Name = "Holly", Age = "10 months", Breed = "Dog", Color = "Black and white", Gender = 'F'},
                new Pet() { PetId = 6, Name = "Minerva", Age = "7 years", Breed = "Cat", Color = "Gray and white", Gender = 'F'},
                new Pet() { PetId = 7, Name = "Houdini", Age = "5 years", Breed = "Snake", Color = "Green and gray", Gender = 'M'}
            };
            return View(pets);
        }
    }
}