using PetStore.Models;
using System.Collections.Generic;

namespace PetStore.ViewModels
{
    public class StorePetViewModel
    {
        public List<Store> Stores { get; set; }
        public List<Pet> Pets { get; set; }
    }
}