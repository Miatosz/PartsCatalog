using System.ComponentModel.DataAnnotations;

namespace PartsCatalog.Models
{
    public class Product
    {
        public int ProductId {get; set;}

        [Required(ErrorMessage = "Proszę podać nazwę produktu.")]
        [Display(Name = "Nazwa")]
        public string Name {get; set;}

        [Required(ErrorMessage = "Proszę podać opis.")]
        [Display(Name = "Opis")]
        public string Description {get; set;}

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Proszę podać dodatnią cenę.")]
        [Display(Name = "Cena")]
        public int Price {get; set;}

        // [Required(ErrorMessage = "Proszę określić kategorię.")]
        // [Display(Name = "Kategoria")]
        public int categoryId {get; set;}
        public Category Category { get; set;}
    }
}