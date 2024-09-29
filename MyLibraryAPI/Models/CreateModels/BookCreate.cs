namespace MyLibraryAPI.Models.CreateModels
{
    public class BookCreate
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PageNumber { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
    }
}
