using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyLibraryAPI.Repository.Config
{
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData(
                new Author { Id = 1, Name = "altay cem", Surname = "meriç" },
                new Author { Id = 2, Name = "nurettin", Surname = "topçu" }
                );
        }
    }
}
