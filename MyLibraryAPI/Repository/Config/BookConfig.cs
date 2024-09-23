using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyLibraryAPI.Repository.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "öğrenmeyi öğrenmek", PageNumber = 137, Description = "kişisel gelişim", AuthorId = 1, PublisherId = 1 },
                new Book { Id = 2, Title = "peygamberliğin ispatı", PageNumber = 510, Description = "islam", AuthorId = 1, PublisherId = 3 },
                new Book { Id = 3, Title = "ahlak", PageNumber = 214, Description = "felsefe", AuthorId = 2, PublisherId = 2 }

                );
        }
    }
}
