using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ETickets.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        [ValidateNever]
        public Movies Movies { get; set; }
        [ValidateNever]
        public int MoviesId { get; set; }
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        [ValidateNever]
        public string ApplicationUserId  { get; set; }
        public int Count { get; set; }
    }
}
