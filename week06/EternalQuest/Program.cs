using System;
using System.Collections.Generic;
using System.IO;

/*
 * EXCEEDING REQUIREMENTS:
 * 
 * To go beyond the core requirements, I implemented several creative enhancements:
 * 
 * 1. Leveling System - Users gain levels based on total points earned, with special
 *    level-up messages and visual progress indicators. Each level requires more points
 *    than the previous one, creating a sense of progression.
 *    
 * 2. Badge Achievements - Users can earn special badges for accomplishing milestones
 *    like "Scripture Master" for 100 scripture study sessions or "Temple Regular" for
 *    attending the temple 12 times. Badges are displayed in the user profile.
 *    
 * 3. Streak Tracking - The program tracks consecutive days of activity and provides
 *    motivational messages to encourage maintaining streaks. Special messages appear
 *    for 3-day, 7-day, and monthly streaks.
 *    
 * 4. Negative Goals - Added a new goal type for breaking bad habits where users
 *    lose points for negative behaviors they're trying to reduce (like smoking or
 *    eating junk food).
 *    
 * 5. Enhanced Visuals - Added progress bars for checklist goals, color-coded displays
 *    (green for completed goals, red for negative goals), and ASCII art celebrations
 *    for major accomplishments.
 *    
 * 6. Motivational Messages - The program provides encouraging feedback when users
 *    reach milestones or maintain consistent activity.
 *    
 * These enhancements make the program more gamified and motivational while maintaining
 * all the core functionality required.
 */

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int totalPoints = 0;
    static LevelSystem levelSystem = new LevelSystem();
    static BadgeSystem badgeSystem = new BadgeSystem();
    static StreakTracker streakTracker = new StreakTracker();
    
    static void Main(string[] args)
    {
        LoadData();
        
        bool running = true;
        while (running)
        {
            Console.Clear();
            DisplayMenu();
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateNewGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadData();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    ShowBadges();
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            
            if (choice != "7")
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
    
    static void DisplayMenu()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("=== ETERNAL QUEST ===");
        Console.ResetColor();
        
        levelSystem.DisplayLevelProgress(totalPoints);
        streakTracker.DisplayStreak();
        
        Console.WriteLine($"\nYou have {totalPoints} points.");
        Console.WriteLine("\nMenu Options:");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Show Badges");
        Console.WriteLine("7. Quit");
        Console.Write("Select a choice from the menu: ");
    }
    
    static void CreateNewGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal (Break a bad habit)");
        Console.Write("Which type of goal would you like to create? ");
        
        string typeChoice = Console.ReadLine();
        
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());
        
        switch (typeChoice)
        {
            case "1":
                goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                
                goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case "4":
                goals.Add(new NegativeGoal(name, description, points));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
        
        Console.WriteLine("Goal created successfully!");
    }
    
    static void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Create some goals to get started!");
            return;
        }
        
        for (int i = 0; i < goals.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            GoalDisplayer.DisplayGoalWithProgress(goals[i]);
        }
    }
    
    static void RecordEvent()
    {
        ListGoals();
        
        if (goals.Count == 0) return;
        
        Console.Write("\nWhich goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;
        
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            Goal goal = goals[goalIndex];
            goal.RecordEvent();
            
            int pointsEarned = goal.GetPoints();
            totalPoints += pointsEarned;
            
            streakTracker.RecordActivity();
            levelSystem.CheckLevelUp(ref totalPoints);
            badgeSystem.CheckForBadges(goals, totalPoints);
            
            Console.WriteLine($"\nCongratulations! You earned {pointsEarned} points!");
            
            if (goal is ChecklistGoal checklist && checklist.IsComplete())
            {
                GoalDisplayer.DisplayCelebration($"CHECKLIST GOAL COMPLETE! BONUS EARNED!");
            }
            else if (goal is SimpleGoal simple && simple.IsComplete())
            {
                GoalDisplayer.DisplayCelebration($"GOAL COMPLETED! WELL DONE!");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }
    
    static void SaveGoals()
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();
        
        using (StreamWriter writer = new StreamWriter(filename))
        {
            // Save total points
            writer.WriteLine(totalPoints);
            
            // Save streak data
            writer.WriteLine($"{streakTracker.CurrentStreak},{streakTracker.LastActivityDate.Ticks}");
            
            // Save badges
            writer.WriteLine(string.Join(",", badgeSystem.GetEarnedBadges()));
            
            // Save goals
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        
        Console.WriteLine("Goals saved successfully!");
    }
    
    static void LoadData()
    {
        Console.Write("Enter filename to load goals: ");
        string filename = Console.ReadLine();
        
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found. Starting with empty goals.");
            return;
        }
        
        goals.Clear();
        
        using (StreamReader reader = new StreamReader(filename))
        {
            // Load total points
            totalPoints = int.Parse(reader.ReadLine());
            
            // Load streak data
            string[] streakData = reader.ReadLine().Split(',');
            int streak = int.Parse(streakData[0]);
            DateTime lastDate = new DateTime(long.Parse(streakData[1]));
            streakTracker.LoadStreak(streak, lastDate);
            
            // Load badges
            string badgesLine = reader.ReadLine();
            if (!string.IsNullOrEmpty(badgesLine))
            {
                badgeSystem.LoadBadges(new List<string>(badgesLine.Split(',')));
            }
            
            // Load goals
            while (!reader.EndOfStream)
            {
                string[] parts = reader.ReadLine().Split('|');
                
                switch (parts[0])
                {
                    case "SimpleGoal":
                        goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])));
                        if (bool.Parse(parts[4])) goals[^1].RecordEvent();
                        break;
                    case "EternalGoal":
                        var eternal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                        for (int i = 0; i < int.Parse(parts[4]); i++) eternal.RecordEvent();
                        goals.Add(eternal);
                        break;
                    case "ChecklistGoal":
                        var checklist = new ChecklistGoal(
                            parts[1], parts[2], int.Parse(parts[3]), 
                            int.Parse(parts[5]), int.Parse(parts[4]));
                        for (int i = 0; i < int.Parse(parts[6]); i++) checklist.RecordEvent();
                        goals.Add(checklist);
                        break;
                    case "NegativeGoal":
                        var negative = new NegativeGoal(parts[1], parts[2], int.Parse(parts[3]));
                        for (int i = 0; i < int.Parse(parts[4]); i++) negative.RecordEvent();
                        goals.Add(negative);
                        break;
                }
            }
        }
        
        Console.WriteLine("Goals loaded successfully!");
    }
    
    static void ShowBadges()
    {
        badgeSystem.DisplayBadges();
    }
}