using System;
public class BreathingActivity : Activity
{
    public BreathingActivity(int duration)
    : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", duration)
    { }
    
    public void Run()
    {
        DisplayStartingMessage();

        int timeRemaining = _duration;

        while (timeRemaining >= 12)
        {
            Console.WriteLine("\nBreath in...");
            ShowCountDown(6);
            timeRemaining -= 6;

            if (timeRemaining <= 0) break;

            Console.WriteLine("\nBreath out...");
            ShowCountDown(6);
            timeRemaining -= 6;
        }

        DisplayEndingMessage();
    }
}