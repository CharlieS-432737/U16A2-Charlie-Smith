using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problem_2
{
    public class CurrentBooks
    {
        public void ListBooks(string outputFile)
        {
            // Check if the output file exists
            if (File.Exists(outputFile))
            {
                // Read all lines from the output file
                string[] lines = File.ReadAllLines(outputFile);

                // Iterate over each line and print it to the console
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                // If the output file doesn't exist, display an error message
                Console.WriteLine("The file that stores the books appears to be missing. Please input a CSV file before reading stored books");
            }
        }
    }
}