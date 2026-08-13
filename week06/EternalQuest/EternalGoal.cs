using System;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {

    }


    public override void RecordEvent()
    {
        // Intentionally left blank for override.
    }


    public override bool IsComplete()
    {
        return false;
    }


    public override string GetStringRepresentation()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {GetDetailsString()}";
    }
}




