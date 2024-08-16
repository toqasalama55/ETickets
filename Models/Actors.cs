namespace ETickets.Models
{
    public class Actors
    {
        public int ActorsId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
        public string News { get; set; }
        public ICollection<Movies> Movies { get; set; }
        //public ICollection<ActorsMovies> ActorsMovies { get; set; }

    }
}
