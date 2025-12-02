using System;
using System.Collections.Generic;
public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of a time when you overcame a challenge."
    };
    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    
    //This prevents a question from being repeated before all questions have been used during a session.
    private List<string> _shuffledQuestions;
    private int _currentQuestionIndex = 0;

    private void ShuffledQuestions()
    {
        Random rand = new Random();
        _shuffledQuestions = new List<string>(_questions);

        for (int i = _shuffledQuestions.Count - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            string temp = _shuffledQuestions[i];
            _shuffledQuestions[i] = _shuffledQuestions[j];
            _shuffledQuestions[j] = temp;
        }

        _currentQuestionIndex = 0;
    }
    public ReflectingActivity(int duration)
    : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", duration)
    { }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    public string GetNextQuestion()
    {
        if (_shuffledQuestions == null || _currentQuestionIndex >= _shuffledQuestions.Count)
        {
            ShuffledQuestions();
        }
        return _shuffledQuestions[_currentQuestionIndex++];
    }

    public void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"----{prompt}----");  
    }
    
    public void DisplayQuestion()
    {
        string question = GetNextQuestion();
        Console.WriteLine($">{question}");
    }
    public void Run()
    {
        DisplayStartingMessage();

        int timeRemaining = _duration;

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:\n");
        DisplayPrompt();
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder each of the follow:");
        ShowSpinner(6);
        Console.Clear();

        while (timeRemaining >= 10)
        {
            DisplayQuestion();
            ShowSpinner(10);
            timeRemaining -= 10;
        }

        DisplayEndingMessage();
    }
}