using System.Security.Cryptography;

namespace LibraryManagementSystem;

public abstract class User
{
    public string Name { get; set; }

    public void DisplayBooks(Library library)
    {
       library.DisplayBooks();
    }

    public void BorrowBooks(Book book, Library library)
    {
        library.BorrowBook(book);
    }
}
