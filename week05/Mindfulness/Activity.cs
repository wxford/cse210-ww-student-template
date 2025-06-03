using System;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    protected static int _activitiesCompleted = 0;

    public Activity()
    {
        _activitiesCompleted++;
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        
        Console.WriteLine("\nGet ready to begin...");
        ShowSpinner(3);
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("\nGreat job!");
        ShowSpinner(2);
        Console.WriteLine($"\nYou have completed the {_name} activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds * 2; i++)
        {
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write("\b \b");
            Console.Write("o");
            Thread.Sleep(500);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected void ShowBreathingAnimation(int seconds, bool isInhale)
    {
        string message = isInhale ? "Breathe in..." : "Breathe out...";
        Console.Write($"\n{message} ");
        
        // Enhanced breathing animation
        int steps = 10;
        for (int i = 0; i < steps; i++)
        {
            double progress = isInhale ? (double)i / steps : (double)(steps - i) / steps;
            int size = (int)(progress * 10) + 1;
            
            Console.Write(new string('=', size));
            Thread.Sleep(seconds * 100 / steps);
            Console.Write("\r" + new string(' ', 20) + "\r");
            Console.Write(message + " ");
        }
        
        Console.WriteLine();
    }

    public static int GetActivitiesCompleted()
    {
        return _activitiesCompleted;
    }
}