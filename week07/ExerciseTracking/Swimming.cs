using System;

class Swimming : Activity
{
    private double _laps;

    public Swimming(double laps, DateTime date, double duration)
    {
        _laps = laps;
        _date = date;
        _duration = duration;
    }


    public override double GetDistance()
    {
        return _laps * 50 / 1000;
    }


    public override double GetSpeed()
    {
        double distanceInKm = _laps * 50 / 1000;
        double durationInHours = _duration / 60;
        return distanceInKm / durationInHours;
    }


    public override double GetPace()
    {
        double distanceInKm = (_laps * 50) / 1000;
        return _duration / distanceInKm;
    }
}
