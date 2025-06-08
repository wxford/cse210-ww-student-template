using System;

public class StreakTracker
{
    private DateTime _lastActivityDate = DateTime.MinValue;
    private int _currentStreak = 0;
    
    public void RecordActivity()
    {
        DateTime today = DateTime.Today;
        
        if (_lastActivityDate == today) return;
        
        if (_lastActivityDate.AddDays(1) == today)
        {
            _currentStreak++;
            
            // Special streak messages
            if (_currentStreak == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n🔥 You're on a 3-day streak! Keep it up!");
                Console.ResetColor();
            }
            else if (_currentStreak == 7)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n🔥 Awesome! 7-day streak! You're on fire!");
                Console.ResetColor();
            }
            else if (_currentStreak % 30 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n🔥 INCREDIBLE! {_currentStreak}-day streak! You're unstoppable!");
                Console.ResetColor();
            }
        }
        else
        {
            if (_currentStreak > 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n😢 Oh no! Your {_currentStreak}-day streak was broken.");
                Console.ResetColor();
            }
            _currentStreak = 1;
        }
        
        _lastActivityDate = today;
    }
    
    public void DisplayStreak()
    {
        if (_currentStreak > 0)
        {
            Console.WriteLine($"\nCurrent streak: {_currentStreak} day(s)");
            
            if (DateTime.Today > _lastActivityDate)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Don't forget to record your goals today to keep your streak alive!");
                Console.ResetColor();
            }
        }
    }
    
    public int CurrentStreak => _currentStreak;
    public DateTime LastActivityDate => _lastActivityDate;
    
    public void LoadStreak(int streak, DateTime lastDate)
    {
        _currentStreak = streak;
        _lastActivityDate = lastDate;
    }
}