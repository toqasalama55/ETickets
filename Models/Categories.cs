using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ETickets.Models
{
    public class Categories
    {
        public int CategoriesId { get; set; }
        [Required]
        public string Name { get; set; }
        [ValidateNever]
        public ICollection<Movies>  Movies { get; set; }    
    }
}
