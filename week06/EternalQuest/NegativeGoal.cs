public class NegativeGoal : Goal
{
    private int _occurrences;

    public NegativeGoal(string name, string description, int penaltyPoints) 
        : base(name, description, penaltyPoints)
    {
        _occurrences = 0;
    }

    public override void RecordEvent()
    {
        _occurrences++;
    }

    public override bool IsComplete()
    {
        return false; // Negative goals are never complete
    }

    public override string GetDetailsString()
    {
        return $"{_name} ({_description}) - Occurrences: {_occurrences} (Try to reduce!)";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal|{_name}|{_description}|{_points}|{_occurrences}";
    }

    public override int GetPoints()
    {
        return -(_points * _occurrences);
    }

    public int Occurrences => _occurrences;
}