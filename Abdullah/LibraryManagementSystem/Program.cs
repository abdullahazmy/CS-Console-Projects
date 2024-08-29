using System;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Library Management System!");
            Library library = new Library();
            Console.WriteLine("Are you a Librarian or Regular user? (L/R)");

            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input. Exiting...");
                return;
            }

            char userType = input.ToUpper()[0];

            if (userType == 'L')
            {
                Console.WriteLine("Welcome Librarian, please enter your name: ");
                Librarian librarian = new Librarian(Console.ReadLine());
                Console.WriteLine($"Welcome {librarian.Name}");

                while (true)
                {
                    Console.WriteLine("Please choose an option: (A/R/D/Q) to Add, Remove, Display books, or Quit: ");
                    var actionInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(actionInput))
                    {
                        Console.WriteLine("Invalid input. Exiting...");
                        return;
                    }

                    char action = actionInput.ToUpper()[0];
                    switch (action)
                    {
                        case 'A':
                            Book newBook = ReadBook();
                            librarian.AddBook(newBook, library);
                            break;
                        case 'R':
                            Book bookToRemove = ReadBook();
                            librarian.RemoveBook(bookToRemove, library);
                            break;
                        case 'D':
                            Console.WriteLine("The Book List is: ");
                            library.DisplayBooks();
                            break;
                        case 'Q':
                            Console.WriteLine("Exiting the system...");
                            return;
                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }
            }
            else if (userType == 'R')
            {
                Console.WriteLine("Welcome, please enter your name: ");
                string userName = Console.ReadLine();
                Console.WriteLine($"Welcome {userName}");
                LibraryUser libraryUser = new LibraryUser(userName);

                while (true)
                {
                    Console.WriteLine("Please select an option: (D/B/Q) to Display, Borrow books, or Quit: ");
                    var actionInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(actionInput))
                    {
                        Console.WriteLine("Invalid input. Exiting...");
                        return;
                    }

                    char action = actionInput.ToUpper()[0];
                    switch (action)
                    {
                        case 'D':
                            libraryUser.DisplayBooks(library);
                            break;
                        case 'B':
                            Book bookToBorrow = ReadBook();
                            libraryUser.BorrowBooks(bookToBorrow, library);
                            break;
                        case 'Q':
                            Console.WriteLine("Exiting the system...");
                            return;
                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid user type. Exiting...");
            }
        }

        public static Book ReadBook()
        {
            Console.WriteLine("Please Enter Book Name: ");
            string bookName = Console.ReadLine();
            Console.WriteLine("Please Enter Book Author: ");
            string author = Console.ReadLine();
            Console.WriteLine("Please Enter Book Description: ");
            string bookDescription = Console.ReadLine();
            Console.WriteLine("Please Enter Book Year: ");
            int year = int.Parse(Console.ReadLine());

            return new Book()
            {
                Title = bookName,
                Author = author,
                BookDescription = bookDescription,
                Year = year
            };
        }
    }
}
