using System;
using System.Drawing;
using System.Runtime.CompilerServices;

class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points) 
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }


    public override void RecordEvent()
    {
        _amountCompleted+=1;
    }


    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }


    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Progress: {_amountCompleted}/{_target}";
    }


    public override string GetStringRepresentation()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {GetDetailsString()}";
        
    }


    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = amount;
    }


    public int Bonus => _bonus;
    public int Target => _target;
    public int AmountCompleted => _amountCompleted;
}