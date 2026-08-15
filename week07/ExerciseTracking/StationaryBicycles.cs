using System;

class StationaryBicycles : Activity
{
    private double _distanceDone;

    public StationaryBicycles(double distanceDone, DateTime date, double duration)
    {
        _distanceDone = distanceDone;
        _date = date;
        _duration = duration;
    }


    public override double GetDistance()
    {
        return _distanceDone;
    }


    public override double GetSpeed()
    {
        return _distanceDone / (_duration / 60);
    }


    public override double GetPace()
    {
        return _duration / _distanceDone;
    }
}
