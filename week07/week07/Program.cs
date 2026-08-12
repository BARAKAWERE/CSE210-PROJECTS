using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        // one of each type, per the assignment requirements
        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 3.0));
        activities.Add(new Cycling(new DateTime(2022, 11, 3), 30, 12.0));
        activities.Add(new Swimming(new DateTime(2022, 11, 3), 30, 30));

        // looping over them as the base Activity type - each one still
        // calls its own version of GetSummary because of polymorphism
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}