public class EternalGoal : Goal
{
    private int _recordCount;

    public EternalGoal(string name, string description, int points) 
        : base(name, description, points) 
    {
        _recordCount = 0;
    }

    public override void RecordEvent()
    {
        _recordCount++;
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals are never complete
    }

    public override string GetDetailsString()
    {
        return $"{_name} ({_description}) - Completed {_recordCount} times";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{_name}|{_description}|{_points}|{_recordCount}";
    }

    public override int GetPoints()
    {
        return _points * _recordCount;
    }

    public int RecordCount => _recordCount;
}