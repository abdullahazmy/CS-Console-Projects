namespace LibraryManagementSystem;

public class Librarian : User
{
    public Librarian(string name) => Name = name;
    public void AddBook(Book book, Library library)
    {
        library.AddBook(book);
    }

    public void RemoveBook(Book book, Library library)
    {
        library.RemoveBook(book);
    }

    public void DisplayBooks(Library library)
    {
        library.DisplayBooks();
    }
}
