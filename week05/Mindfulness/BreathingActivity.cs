public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        DisplayStartingMessage();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        bool isInhale = true;
        while (DateTime.Now < endTime)
        {
            ShowBreathingAnimation(isInhale ? 4 : 6, isInhale);
            isInhale = !isInhale;
        }
        
        DisplayEndingMessage();
    }
}