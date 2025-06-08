using System;

public static class GoalDisplayer
{
    public static void DisplayGoalWithProgress(Goal goal)
    {
        if (goal is ChecklistGoal checklistGoal)
        {
            double progress = (double)checklistGoal.CurrentCount / checklistGoal.TargetCount;
            Console.Write($"[{GetProgressBar(progress, 20)}] ");
            Console.WriteLine(checklistGoal.GetDetailsString());
        }
        else if (goal is NegativeGoal negativeGoal)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(negativeGoal.GetDetailsString());
            Console.ResetColor();
        }
        else if (goal.IsComplete())
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(goal.GetDetailsString());
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }
    
    private static string GetProgressBar(double progress, int length)
    {
        int filled = (int)(progress * length);
        return new string('█', filled) + new string(' ', length - filled);
    }
    
    public static void DisplayCelebration(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n*********************************");
        Console.WriteLine($"* {message} *");
        Console.WriteLine("*********************************");
        Console.ResetColor();
    }
}