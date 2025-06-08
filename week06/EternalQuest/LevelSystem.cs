public class LevelSystem
{
    private int _currentLevel = 1;
    private int _pointsForNextLevel = 1000;
    
    public void CheckLevelUp(ref int totalPoints)
    {
        while (totalPoints >= _pointsForNextLevel)
        {
            totalPoints -= _pointsForNextLevel;
            _currentLevel++;
            int previousThreshold = _pointsForNextLevel;
            _pointsForNextLevel = (int)(_pointsForNextLevel * 1.5);
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n★ LEVEL UP! You've reached Level {_currentLevel} ★");
            Console.WriteLine($"You needed {previousThreshold} points for this level.");
            Console.WriteLine($"Next level requires {_pointsForNextLevel} points.");
            Console.ResetColor();
        }
    }
    
    public void DisplayLevelProgress(int totalPoints)
    {
        Console.WriteLine($"\nCurrent Level: {_currentLevel}");
        Console.WriteLine($"Progress to next level: {totalPoints}/{_pointsForNextLevel} points");
        double progress = (double)totalPoints / _pointsForNextLevel;
        DrawProgressBar(progress, 25);
    }
    
    private void DrawProgressBar(double progress, int barLength)
    {
        Console.Write("[");
        int filled = (int)(progress * barLength);
        for (int i = 0; i < barLength; i++)
        {
            Console.Write(i < filled ? "█" : " ");
        }
        Console.WriteLine($"] {progress * 100:0}%");
    }
}