using System;
using System.Collections.Generic;

namespace Address_Book_Application
{
    internal class Program
    {
        static List<AddressContacts> contacts = new List<AddressContacts>();
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("---------------Main Menu--------------");
                Console.WriteLine("1. View Contacts");
                Console.WriteLine("2. Add Contact");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Exit");
                Console.Write("Please select an option by writing its number (1-5): ");
                switch (Console.ReadLine())
                    {
                        case "1": ViewContacts();
                            break;
                        case "2": AddContacts();
                            break;
                        case "3": EditContacts();
                            break;
                        case "4": DeleteContacts();
                            break;
                        case "5":
                            exit = true;
                            Console.WriteLine("Goodbye.");
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            Console.ReadKey();
                            break;
                    }
            }
        }

        class AddressContacts
        {
            public string Name { get; set; }
            public string Email { get; set; }

            // Constructor
            public AddressContacts(string name, string email)
            {
                Name = name;
                Email = email;
            }
            
            
        }
        static void ViewContacts()
        {
            Console.Clear();
            Console.WriteLine("---------------My Contacts--------------");
            if (contacts.Count == 0)
                Console.WriteLine("No Contacts Found.");
            else
            {
                for (int i = 0; i < contacts.Count; i++)
                    Console.WriteLine("{0}. {1} ({2})", i + 1, contacts[i].Name, contacts[i].Email);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            
        }
        static void AddContacts()
        {
            bool continueAdding = true;
            while (continueAdding)
            {
                Console.Clear();
                string name, email ;

                do
                {
                    Console.WriteLine("Enter Contact Name: ");
                    name = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Name cannot be empty.");
                    }
                } while (string.IsNullOrEmpty(name));

                do
                {
                    Console.WriteLine("Enter Contact Email: ");
                    email = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
                    {
                        Console.WriteLine("Invalid email format.");
                    }
                } while (string.IsNullOrEmpty(email) || !IsValidEmail(email));

                contacts.Add(new AddressContacts(name, email));
                Console.WriteLine("Contact added successfully!");
                Console.WriteLine();
                
                Console.WriteLine("Do you want to add another contact? (y/n): ");
                string userChoice = Console.ReadLine()?.Trim().ToLower();
                if (userChoice != "y")
                {
                    continueAdding = false;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void EditContacts()
        {
            Console.Clear();
            Console.WriteLine("---------------My Contacts--------------");
            if (contacts.Count == 0)
            {
                Console.WriteLine("No Contacts Found.");
                Console.WriteLine("Press any key to return...");
                Console.ReadKey();
                return;
            }
            
            for (int i = 0; i < contacts.Count; i++) 
                Console.WriteLine("{0}. {1} ({2})", i + 1, contacts[i].Name, contacts[i].Email);
            
            Console.Write("Please select a contact do you need to edit by writing its number: ");
            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > contacts.Count)
            {
                Console.Write("Invalid selection. Please enter a valid number:");
            }
            option--; // zero-based for the list index
            
            string name;
            do
            {
                Console.WriteLine("Enter new contact name: ");
                name = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Name cannot be empty.");
                }
            } while (string.IsNullOrEmpty(name));
            contacts[option].Name = name;
            
            string email;
            do
            {
                Console.WriteLine("Enter new contact email: ");
                email = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
                {
                    Console.WriteLine("Invalid email format.");
                }
            } while (string.IsNullOrEmpty(email) || !IsValidEmail(email));
            contacts[option].Email = email;

            Console.WriteLine("Contact edited successfully!");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void DeleteContacts()
        {
            if (contacts.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("---------------My Contacts--------------");
                Console.WriteLine("No Contacts Found.");
                Console.WriteLine("Press any key to return...");
                Console.ReadKey();
                return;
            }

            bool continueDeleting = true;
            while (continueDeleting)
            {
                Console.Clear();
                Console.WriteLine("---------------My Contacts--------------");
                for (int i = 0; i < contacts.Count; i++) 
                    Console.WriteLine("{0}. {1} ({2})", i + 1, contacts[i].Name, contacts[i].Email);
                
                Console.Write("Please select a contact do you need to delete by writing its number: ");
                int option;
                while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > contacts.Count)
                {
                    Console.Write("Invalid selection. Please enter a valid number:");
                }
                
                option--; // zero-based for the list index
                contacts.RemoveAt(option);
                Console.WriteLine("Contact deleted successfully!");
                Console.WriteLine();
                
                Console.WriteLine("Do you want to delete another contact? (y/n): ");
                string userChoice = Console.ReadLine()?.Trim().ToLower();
                if (userChoice != "y")
                {
                    continueDeleting = false;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
