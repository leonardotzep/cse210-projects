using System;
using System.Diagnostics;
using System.Dynamic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(3.0, new DateTime(2022, 11, 3), 30));
        activities.Add(new StationaryBicycles(10.0, new DateTime(2022, 11, 3), 25));
        activities.Add(new Swimming(40, new DateTime(2022, 11, 3), 35));

        foreach(Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
