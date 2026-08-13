using System;
using System.Runtime.CompilerServices;

class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }


    public override bool IsComplete()
    {
        return _isComplete;
    }


    public override string GetStringRepresentation()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {GetDetailsString()}";
    }
}


