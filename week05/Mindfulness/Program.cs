using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program Menu");
            Console.WriteLine("=========================");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Show Activity Log");
            Console.WriteLine("5. Quit");
            Console.Write("\nSelect an option: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    break;
                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    break;
                case "4":
                    ShowActivityLog();
                    break;
                case "5":
                    Console.WriteLine("\nThank you for using the Mindfulness Program. Have a peaceful day!");
                    return;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }

    static void ShowActivityLog()
    {
        Console.Clear();
        Console.WriteLine($"Activity Log\n============\n\nTotal activities completed: {Activity.GetActivitiesCompleted()}");
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }
}