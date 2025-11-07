using System;
using System.Collections.Generic;
public class PromptGenerator
{
    public List<string> _prompts;

    //List of prompts to randomly be selected.
    public PromptGenerator()
    {
        _prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What are you grateful for today?",
            "What would make today great?",
            "What was the highlight of your day?",
            "What lesson did you learn today?",
            "What is something you have always wanted to do but haven't?",
            "What values are most important to you, and how do you align with them?",
            "Describe a moment that helped shape you into who you are today."
        };
    }

    //Randomly select a prompt from the list.
    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(_prompts.Count);

        return _prompts[index];
    }
}