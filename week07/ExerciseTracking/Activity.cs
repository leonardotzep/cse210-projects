using System;

abstract class Activity
{
    protected DateTime _date;
    protected double _duration;


    public abstract double GetDistance();    
    public abstract double GetSpeed();
    public abstract double GetPace();


    public string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        return $"{_date.ToShortDateString()} {this.GetType().Name} ({_duration} min) - " +
            $"Distance {distance:F2} km, Speed: {speed:F2} km/h, Pace: {pace:F2} min/km";
    }
}
