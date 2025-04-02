namespace PetShop.Manager.Domain
{
    public class Dog : AnimalBase
    {
        public string Name { get; set; } = string.Empty;
        public string Type => "Cat";
    }
}
