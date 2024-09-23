using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyLibraryAPI.Repository.Config
{
    public class PublisherConfig : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasData(
                new Publisher { Id = 1, Name = "tin yayınları" },
                new Publisher { Id = 2, Name = "dergah yayınları" },
                new Publisher { Id = 3, Name = "insan yayınları" }

                );
        }
    }
}
