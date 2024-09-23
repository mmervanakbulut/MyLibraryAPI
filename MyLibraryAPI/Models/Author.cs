﻿using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Author
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<Book> Books { get; } = new List<Book>(); // Collection navigation containing dependents
    }
}
