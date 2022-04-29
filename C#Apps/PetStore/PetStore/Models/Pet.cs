namespace PetStore.Models
{
    public class Pet
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Age { get; set; }
        public char Gender { get; set; }
        public string Color { get; set; }
        public int StoreId { get; set; }

    }
}