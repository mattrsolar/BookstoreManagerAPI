using BookstoreManagerAPI.Enums;

namespace BookstoreManagerAPI.Models
{
    public class Book
    {
        private Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
