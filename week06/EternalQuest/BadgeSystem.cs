using System.Collections.Generic;
using System.Linq;

public class BadgeSystem
{
    private List<string> _earnedBadges = new List<string>();
    
    public void CheckForBadges(List<Goal> goals, int totalPoints)
    {
        // Scripture Master
        int scriptureCount = goals
            .OfType<EternalGoal>()
            .Where(g => g.GetName().ToLower().Contains("scripture"))
            .Sum(g => g.RecordCount);
            
        if (scriptureCount >= 100 && !_earnedBadges.Contains("Scripture Master"))
        {
            _earnedBadges.Add("Scripture Master");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n★ Earned Badge: Scripture Master ★");
            Console.WriteLine("You've studied scriptures 100 times! Amazing dedication!");
            Console.ResetColor();
        }
        
        // Marathon Runner
        bool marathonComplete = goals
            .OfType<SimpleGoal>()
            .Any(g => g.GetName().ToLower().Contains("marathon") && g.IsComplete());
            
        if (marathonComplete && !_earnedBadges.Contains("Marathon Runner"))
        {
            _earnedBadges.Add("Marathon Runner");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n★ Earned Badge: Marathon Runner ★");
            Console.WriteLine("You completed a marathon! Incredible achievement!");
            Console.ResetColor();
        }
        
        // Temple Regular
        int templeCount = goals
            .OfType<ChecklistGoal>()
            .Where(g => g.GetName().ToLower().Contains("temple"))
            .Sum(g => g.CurrentCount);
            
        if (templeCount >= 12 && !_earnedBadges.Contains("Temple Regular"))
        {
            _earnedBadges.Add("Temple Regular");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n★ Earned Badge: Temple Regular ★");
            Console.WriteLine("You've attended the temple 12 times this year! Wonderful!");
            Console.ResetColor();
        }
        
        // Points Master
        if (totalPoints >= 5000 && !_earnedBadges.Contains("Points Master"))
        {
            _earnedBadges.Add("Points Master");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n★ Earned Badge: Points Master ★");
            Console.WriteLine("You've earned over 5000 points! You're a goal-crushing machine!");
            Console.ResetColor();
        }
    }
    
    public void DisplayBadges()
    {
        if (_earnedBadges.Count == 0)
        {
            Console.WriteLine("\nYou haven't earned any badges yet. Keep working on your goals!");
            return;
        }
        
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n=== YOUR EARNED BADGES ===");
        foreach (var badge in _earnedBadges)
        {
            Console.WriteLine($"★ {badge}");
        }
        Console.ResetColor();
    }
    
    public List<string> GetEarnedBadges()
    {
        return _earnedBadges;
    }
    
    public void LoadBadges(List<string> badges)
    {
        _earnedBadges = badges;
    }
}