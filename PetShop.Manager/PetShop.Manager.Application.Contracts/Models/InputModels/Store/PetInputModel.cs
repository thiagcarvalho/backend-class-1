using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Manager.Application.Contracts.Models.InputModels.Store
{
    public class PetInputModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "The name of the pet is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "The type of the pet is required")]
        public string Type { get; set; } = string.Empty;
    }
}
