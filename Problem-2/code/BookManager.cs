using Microsoft.VisualBasic.FileIO;
using Problem_2;

namespace Problem_2
{
    public class BookManager
    {
        public void ManageBooks(string outputFile)
        {
            // Create an instance of the serial number generator
            SerialNumberGenerator.ISerialNumberGenerator serialNumberGenerator = new SerialNumberGenerator.HashBasedSerialNumberGenerator();

            // Create a dictionary to store books
            Dictionary<string, Book> books = new Dictionary<string, Book>();

            // Initialize a flag to validate user input
            bool valid = false;

            string? path = "";

            // Prompt the user to enter the path to the CSV file
            while (valid == false)
            {
                Console.WriteLine("Please enter the full path to the .csv file: (Default: ./data/U16A2Task2Data.csv)");
                path = Console.ReadLine();

                // Check if the user input is empty or null, if so, use the default path
                if (string.IsNullOrEmpty(path))
                {
                    Console.WriteLine("Using default");
                    path = "./data/U16A2Task2Data.csv";
                    valid = true;
                }
                else
                {
                    valid = true;
                }
            }

            // Check if the output file already exists, and delete it if it does
            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }
            else
            {
                // Create the output file if it doesn't exist
                File.Create(outputFile).Close();
            }

            try
            {
                // Read the CSV file using TextFieldParser
                using (TextFieldParser parser = new TextFieldParser(path))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    // Loop through each line of the CSV file
                    while (!parser.EndOfData)
                    {
                        string[]? fields = parser.ReadFields();
                        if (fields?.Length >= 5)
                        {
                            // Generate a serial number for the book
                            string serialNumber = serialNumberGenerator.GenerateSerialNumber(fields[1], fields[0], fields[2], fields[3], fields[4]);

                            // Create a new Book object
                            Book book = new Book(
                                serialNumber,
                                fields[1],
                                fields[0],
                                fields[2],
                                fields[3],
                                fields[4]
                            );

                            // Check for duplicate books based on serial number
                            if (books.ContainsKey(book.SerialNumber))
                            {
                                Console.WriteLine($"Duplicate book found with serial number: {book.SerialNumber}");
                                continue;
                            }

                            // Add the book to the dictionary
                            books.Add(book.SerialNumber, book);
                        }
                    }
                    using (StreamWriter writer = new StreamWriter(outputFile))
                    {
                        // Write the header row
                        writer.WriteLine("Serial Number,Title,Author,Place Published,Publisher,Publication Date");

                        // Write the book information rows
                        foreach (var bookEntry in books)
                        {
                            Book book = bookEntry.Value;
                            writer.WriteLine($"{book.SerialNumber},{book.Title},{book.Author},{book.PlacePublication},{book.Publisher},{book.PublicationDate}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while reading the CSV file: " + ex.Message);
            }
        }
    }

    public class Book
    {
        // Properties of the Book class
        public string? SerialNumber { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? PlacePublication { get; set; }
        public string? Publisher { get; set; }
        public string? PublicationDate { get; set; }

        // Constructor for the Book class
        public Book(string serialNumber, string title, string author, string placePublication, string publisher, string publicationDate)
        {
            SerialNumber = serialNumber;
            Title = title;
            Author = author;
            PlacePublication = placePublication;
            Publisher = publisher;
            PublicationDate = publicationDate;
        }

        // Method to get the book information
        public virtual string GetBookInfo()
        {
            return $"Serial Number: {SerialNumber}, Title: {Title}, Author: {Author}, Place Published: {PlacePublication}, Publisher: {Publisher}, Publication Date: {PublicationDate}";
        }
    }
}
