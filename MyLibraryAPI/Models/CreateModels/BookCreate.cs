namespace MyLibraryAPI.Models.CreateModels
{
    public class BookCreate
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PageNumber { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string PublisherName { get; set; }
    }
}
