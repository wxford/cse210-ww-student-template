using System;

class Program
{
    static void Main(string[] args)
    {
        // You can try a scripture with a single verse or a range.
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(reference, "Trust in the Lord with all thine heart and lean not unto thine own understanding.");

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3); // Hide 3 words each time
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are now hidden. Press any key to exit.");
        Console.ReadKey();
    }
}

/*
 * Creativity Extension (for full credit):
 * - The program hides only words that are not already hidden.
 * - You can easily expand this by loading multiple scriptures from a file and selecting one at random.
 * - Consider adding hints, repetition counters, or audio in future iterations.
 */
