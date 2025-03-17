using System.ComponentModel.DataAnnotations;


namespace Petshop.Manager.WebApi.Dto
{
    public class PetDto
    {
        [Required(ErrorMessage = "The Name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Type is required")]
        [RegularExpression("^(Cat|Dog)$", ErrorMessage = "The Type must be either 'Cat' or 'Dog'")]
        public string Type { get; set; } = string.Empty;

        public int Age { get; set; }
    }
}
