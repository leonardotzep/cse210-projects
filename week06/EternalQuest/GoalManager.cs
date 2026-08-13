using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class GoalManager
{
    List<Goal> _goals;
    private int _score;
    private int _level;
    private const int _maxLevel = 10;
    private const int _pointsPerLevel = 500;


    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
    }


    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points / Current Level: {_level}/{_maxLevel}");
    }

    private void UpdateLevel()
    {
        int calculatedLevel = (_score / _pointsPerLevel) + 1;
        if (calculatedLevel > _maxLevel)
            calculatedLevel = _maxLevel;

        if (calculatedLevel > _level)
        {
            _level = calculatedLevel;
            if (_level == _maxLevel)
            {
                Console.WriteLine("Congrats! You reached the maximum level! Keep up the great work!");
            }
            else
            {
                Console.WriteLine($"Good job! You are now Level {_level}");
            }
        }
    }


    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i=0; i< _goals.Count; i++)
        {
            Console.WriteLine($"{i+1}. {_goals[i].GetStringRepresentation()}");
        }
        // Pending of usage.
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i=0; i< _goals.Count; i++)
        {
            Console.WriteLine($"{i+1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        int typechoice = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        if (typechoice == 1)
        {
            newGoal = new SimpleGoal(name, description, points);
        }
        else if (typechoice == 2)
        {
            newGoal = new EternalGoal(name, description, points);
        }
        else if (typechoice == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            newGoal = new ChecklistGoal(name, description, points, target, bonus);
        }
        if (newGoal != null)
        {
            _goals.Add(newGoal);
            Console.WriteLine("Goal have been created successfully!\n");
        }
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 1 && goalIndex <= _goals.Count)
        {
            Goal goal = _goals[goalIndex -1];
            bool wasComplete = goal.IsComplete();

            goal.RecordEvent();

            if (goal is SimpleGoal simple)
            {
                if (!wasComplete && simple.IsComplete())
                {
                    _score += simple.Points;
                    Console.WriteLine($"You earned {simple.Points} points!");
                }
            }

            else if (goal is EternalGoal eternal)
            {
                _score += eternal.Points;
                Console.WriteLine($"You earned {eternal.Points} points!");
            }

            else if (goal is ChecklistGoal checklist)
            {
                _score += checklist.Points;
                Console.WriteLine($"You earned {checklist.Points} points!");

                if (checklist.IsComplete())
                {
                    _score += checklist.Bonus;
                    Console.WriteLine($"You earned {checklist.Bonus} bonus points!");
                }
            }

            UpdateLevel();
            Console.WriteLine("Event recorded successfully!");
            Console.WriteLine($"Current Score: {_score}");
        }


        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }


    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
    {
        outputFile.WriteLine(_score);
        
        foreach(Goal goal in _goals)
        {
            if (goal is SimpleGoal simple)
                outputFile.WriteLine($"SimpleGoal|{simple.ShortName}|{simple.Description}|{simple.Points}|{simple.IsComplete()}");
            else if (goal is EternalGoal eternal)
                outputFile.WriteLine($"EternalGoal|{eternal.ShortName}|{eternal.Description}|{eternal.Points}");
            else if (goal is ChecklistGoal checklist)
                outputFile.WriteLine($"ChecklistGoal|{checklist.ShortName}|{checklist.Description}|{checklist.Points}|{checklist.Target}|{checklist.Bonus}|{checklist.AmountCompleted}");
        }
    }
    }


    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string [] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i=1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                string type = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                Goal newGoal = null;

                if (type == "SimpleGoal")
                {
                    bool IsComplete = bool.Parse(parts[4]);
                    newGoal = new SimpleGoal(name, description, points);
                    if (IsComplete) newGoal.RecordEvent();
                }
                else if (type == "EternalGoal")
                {
                    newGoal = new EternalGoal(name, description, points);
                }
                else if (type == "ChecklistGoal")
                {
                    int target = int.Parse(parts[4]);
                    int bonus = int.Parse(parts[5]);
                    int amountCompleted = int.Parse(parts[6]);
                
                    newGoal = new ChecklistGoal(name, description, points, target, bonus);
                    ((ChecklistGoal)newGoal).SetAmountCompleted(amountCompleted);
                }

                if (newGoal != null)
                {
                    _goals.Add(newGoal);
                }
            }
            UpdateLevel();
            Console.WriteLine("Goals loadded!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}