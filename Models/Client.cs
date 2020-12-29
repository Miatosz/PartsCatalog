using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace PartsCatalog.Models
{
    public class Client
    {

        public int ClientId {get; set;}

        [Required(ErrorMessage = "Proszę podać Imię.")]
        [Display(Name = "Imię")]
        public string Name {get; set;}

        [Required(ErrorMessage = "Proszę podać Nazwisko.")]
        [Display(Name = "Nazwisko")]
        public string Surname {get; set;}

        [Required(ErrorMessage = "Proszę podać kraj.")]
        [Display(Name = "Kraj")]
        public string Country {get; set;}

        [Required(ErrorMessage = "Proszę podać miasto.")]
        [Display(Name = "miasto")]
        public string City {get; set;}

        [Required(ErrorMessage = "Proszę podać ulice.")]
        [Display(Name = "ulica")]
        public string Street {get; set;}

        [Required(ErrorMessage = "Proszę podać nr domu.")]
        [Display(Name = "nr domu")]
        public string Line1 {get; set;}

        [Display(Name = "nr lokalu")]
        public string Line2 {get; set;}

        [Required(ErrorMessage = "Proszę podać kod pocztowy.")]
        [Display(Name = "kod pocztowy")]
        public string Zip {get; set;}

        [Required(ErrorMessage = "Proszę podać telefon.")]
        [Display(Name = "telefon")]
        public string Telephone {get; set;}

        // public int? AccountId {get; set;}
        // public AppUser user {get; set;}
    }
}