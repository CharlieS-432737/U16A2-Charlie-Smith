using Microsoft.VisualBasic.FileIO;
using System;
using System.Security.Cryptography;
using System.Text;
using Problem_2;

// Create instances of the BookManager and CurrentBooks classes
BookManager bookManager = new BookManager();
CurrentBooks currentBooks = new CurrentBooks();

int option = 0;
bool quit = false;
bool listBooks = false;
string outputFile = "./data/books.csv";

// Main loop for the console menu
while (!quit)
{
    // Check if the output file exists to determine if there are books stored
    listBooks = File.Exists(outputFile);

    Console.Clear();
    Console.WriteLine("1. Input CSV file");

    if (listBooks)
    {
        Console.WriteLine("2. List books stored");
        Console.WriteLine("3. Delete currently stored books");
        Console.WriteLine("4. Quit");
    }
    else
    {
        Console.WriteLine("2. Quit");
    }

    try
    {
        option = Convert.ToInt16(Console.ReadLine());
    }
    catch
    {
        Console.WriteLine("\nPlease enter a valid input");
    }

    switch (option)
    {
        case 1:
            Console.Clear();
            bookManager.ManageBooks(outputFile); // Call the ManageBooks method to input a CSV file
            Console.WriteLine("\nPress enter to continue");
            Console.ReadLine();
            break;
        case 2:
            if (listBooks)
            {
                Console.Clear();
                currentBooks.ListBooks(outputFile); // Call the ListBooks method to list the stored books if they exist
                Console.WriteLine("\nPress enter to continue");
                Console.ReadLine();
            }
            else
            {
                quit = true;
            }
            break;
        case 3:
            if (listBooks)
            {
                if (File.Exists(outputFile))
                {
                    File.Delete(outputFile); // Delete the currently stored books by deleting the output file
                }
            }
            else
            {
                Console.WriteLine("\nPlease enter a valid input");
            }
            break;
        case 4:
            if (listBooks)
            {
                quit = true; // Exit the program if there are stored books
            }
            else
            {
                Console.WriteLine("\nPlease enter a valid input");
            }
            break;
        default:
            Console.WriteLine("\nPlease enter a valid input");
            break;
    }
}