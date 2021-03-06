using PetStore.Models;
using System.Collections.Generic;

namespace PetStore.ViewModels
{
    public class IndexPetViewModel
    {
        public List<Pet> Pet { get; set; }
        public List<Customer> User { get; set; }
        public List<Store> Store { get; set; }
    }
}