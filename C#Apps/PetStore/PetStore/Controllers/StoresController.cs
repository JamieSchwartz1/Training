using PetStore.Models;
using PetStore.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    public class StoresController : Controller
    {
        // GET: Stores
        public ActionResult Locations()
        {
            var stores = new List<Store>
            {
                new Store{ Id = 1, Name = "Doggie Dreamland", State = "Mississippi"},
                new Store{ Id = 2, Name = "Kitty Playground", State = "New York"},
                new Store{ Id = 3, Name = "Snakes for Sale", State = "Alabama"}
            };
            var pets = new List<Pet>
            {
                new Pet{ PetId = 1, StoreId = 1},
                new Pet{ PetId = 2, StoreId = 1},
                new Pet{ PetId = 3, StoreId = 1},
                new Pet{ PetId = 4, StoreId = 1},
                new Pet{ PetId = 5, StoreId = 1},
                new Pet{ PetId = 6, StoreId = 2},
                new Pet{ PetId = 7, StoreId = 3},
            };
            var viewModel = new IndexPetViewModel { Store = stores, Pet = pets };

            return View(viewModel);
        }
    }
}