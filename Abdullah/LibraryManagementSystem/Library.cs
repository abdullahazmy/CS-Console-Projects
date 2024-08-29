namespace LibraryManagementSystem
{
    public class Library
    {
        private List<Book> Books;
        private List<Book> BorrowedBooks;

        public Library()
        {
            Books = new List<Book>();
            BorrowedBooks = new List<Book>();
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                Console.WriteLine("Cannot add a null book to the library.");
                return;
            }

            Books.Add(book);
            Console.WriteLine("Book added to library");
        }

        private int FindBook(Book book)
        {
            if (book == null)
                return -1;

            for (int i = 0; i < Books.Count; i++)
            {
                // The '?' is to ensure that the string is not null, to handle NullReferenceException error
                if (string.Equals(Books[i].Title?.Trim(), book.Title?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(Books[i].Author?.Trim(), book.Author?.Trim(), StringComparison.OrdinalIgnoreCase) &&
                    Books[i].Year == book.Year)
                {
                    return i;
                }
            }

            return -1;
        }

        public void RemoveBook(Book book)
        {
            int index = FindBook(book);
            if (index != -1 && index < Books.Count)
            {
                Books.RemoveAt(index);
                Console.WriteLine("Book removed from library");
            }
            else
            {
                Console.WriteLine("There is no such book in the library.");
            }
        }

        public void DisplayBooks()
        {
            foreach (var book in Books)
            {
                Console.WriteLine(book.Title);
            }
        }

        public void BorrowBook(Book book)
        {
            int index = FindBook(book);
            if (index != -1 && index < Books.Count)
            {
                BorrowedBooks.Add(book);
                Books.RemoveAt(index);
                Console.WriteLine("Book borrowed from library");
            }
            else
            {
                Console.WriteLine("Book not available for borrowing.");
            }
        }
    }
}
