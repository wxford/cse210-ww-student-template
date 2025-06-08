public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        return $"{_name} ({_description}) [{(IsComplete() ? "X" : " ")}]";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{_name}|{_description}|{_points}|{_isComplete}";
    }
}