using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ETickets.Models
{
    public class Cinemas
    {
        public int CinemasId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CinemaLogo { get; set; }
        [Required]
        public string Address { get; set; }
        [ValidateNever]
        public ICollection<Movies> Movies { get; set; }
    }
}
