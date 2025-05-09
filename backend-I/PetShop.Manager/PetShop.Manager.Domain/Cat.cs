namespace PetShop.Manager.Domain
{
    public class Cat : AnimalBase
    {
        public string Name { get; set; } = string.Empty;
        public string Type => "Cat";
    }
}
