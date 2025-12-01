using System;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity!\n");
        Console.WriteLine(_description);
        Console.WriteLine("\nGet ready...");
        ShowSpinner(4);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell Done!");
        ShowSpinner(4);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(4);

    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i >= 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    
    public void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        int counter = 0;
        int elapsed = 0;

        while (elapsed < seconds * 1000)
        {
            Console.Write(spinner[counter]);
            Thread.Sleep(250);
            Console.Write("\b");

            counter = (counter + 1) % spinner.Length;
            elapsed += 250;
        }

        Console.Write(" ");
        Console.Write("\b");

    }
}