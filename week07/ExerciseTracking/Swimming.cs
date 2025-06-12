public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps) 
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 50 / 1000.0; // km
    public override double GetSpeed() => (GetDistance() / _minutes) * 60;
    public override double GetPace() => _minutes / GetDistance();
}