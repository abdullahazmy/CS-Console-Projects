namespace LibraryManagementSystem;

public class LibraryUser : User
{
    public LibraryCard CardNum { get; set; }
    public LibraryUser(string name) => Name = name;
}
