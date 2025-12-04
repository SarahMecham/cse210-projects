using System;
using System.Diagnostics;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(new DateTime(2025, 11, 04), 30, 3.6));
        activities.Add(new Cycling(new DateTime(2025, 11, 01), 45, 10));
        activities.Add(new Swimming(new DateTime(2025, 11, 02), 50, 24));

        foreach (Activity a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}