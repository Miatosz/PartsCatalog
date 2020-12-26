using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PartsCatalog.Models
{
    public class Category
    {

        public int CategoryId {get; set;}

        [Required(ErrorMessage = "Proszę podać nazwę kategorii.")]
        [Display(Name = "Nazwa")]
        public string Name {get; set;}

        
        public ICollection<Product> Products {get; set;}
    }
}