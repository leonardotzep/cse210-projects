using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public int Points => _points;
    public string ShortName => _shortName;
    public string Description => _description;

    public virtual void RecordEvent()
    {
        // Virtual method left blank intentionally for override.
    }

    public virtual bool IsComplete()
    {
        return false;
    }

    public virtual string GetDetailsString()
    {
        return $"{_shortName}: ({_description})";
    }

    public virtual string GetStringRepresentation()
    {
        return $"{GetDetailsString()}";
    }
}