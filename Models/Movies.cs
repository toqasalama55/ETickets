using ETickets.Data.Enum;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace ETickets.Models
{
    public class Movies
    {
        public int MoviesId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        [Required]
        public string TrailerUrl { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [ValidateNever]
        public MovieStatus MovieStatus { get; set; }
        public int? CinemasId { get; set; }
        [ValidateNever]
        public Cinemas Cinemas { get; set; }
        public int? CategoriesId { get; set; }
        [ValidateNever]
        public Categories Categories { get; set; }
        [ValidateNever]
        public ICollection<Actors> Actors { get; set; }
        [DefaultValue(0)]
        public int? ViewCounter { get; set; }
        //public object ActorsMovies { get; internal set; }
       // public ICollection<ActorsMovies> ActorsMovies { get; set; }
    }
}
