using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Book
    {
        [Key] public int Id { get; set; }
        public string Title { get; set; }
        public int PageNumber { get; set; }
        public string Description { get; set; }



        public int PublisherId { get; set; } // Required foreign key property
        public Publisher Publishers { get; set; } = null!; // Required reference navigation to principal

        public int AuthorId { get; set; } // Required foreign key property
        public Author Authors { get; set; } = null!; // Required reference navigation to principal

    }
}
