using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

public class GoalManager
{
    protected List<Goal> _goals;
    protected int _score;
    private string _choice;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            DisplayPlayerInfo();

            Console.WriteLine("Menu options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Quit");
            Console.Write("Select a choice from the menu: ");

            _choice = Console.ReadLine();

            switch (_choice)
            {
                case "1": 
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.\n");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            string checkbox = _goals[i].IsComplete() ? "[x]" : "[ ]";
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nYour goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            string checkbox = _goals[i].IsComplete() ? "[x]" : "[ ]";
            Console.WriteLine($"{i + 1}. {checkbox} {_goals[i].GetDetailsString()}");
        }

        Console.WriteLine();
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");
        Console.WriteLine("Which type of goal would you like to create?");

        string type = Console.ReadLine();

        Console.WriteLine("What is the name of your goal?");
        string name = Console.ReadLine();

        Console.WriteLine("What is a short description of your goal?");
        string description = Console.ReadLine();

        Console.WriteLine("What is the amount of points associated with this goal?");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        } 
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.WriteLine("How many times does this goal need to be accomplished?");
            int target = int.Parse(Console.ReadLine());

            Console.WriteLine($"What is the bonus for accomplishing this goal {target} times?");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("\nWhich goal did you accomplish?");
        ListGoalNames();

        int choice = int.Parse(Console.ReadLine()) - 1;
        Goal goal = _goals[choice];

        goal.RecordEvent();

        if (goal is SimpleGoal || goal is EternalGoal)
        {
            _score += goal.GetPoints();
        }
        else if (goal is ChecklistGoal checklist)
        {
            _score += goal.GetPoints();

            if (checklist.IsComplete())
            {
                _score += checklist.GetBonus();
                Console.WriteLine("Bonus earned!");
            }
        }

        Console.WriteLine($"You now have {_score} points!\n");
    }

    public void SaveGoals()
    {   
        Console.WriteLine("What is the name of the file you would like to save to?");
        string fileName = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        
        Console.WriteLine("Goals Saved!\n");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i]))
                continue;

            string[] parts = lines[i].Split("|");

            if (parts.Length == 0)
                continue;

            string type = parts[0];

            try
            {
                if (type == "SimpleGoal")
                {
                    SimpleGoal goal = new SimpleGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3])
                    );

                    if (bool.Parse(parts[4]))
                    {
                        goal.RecordEvent();
                    }

                    _goals.Add(goal);
                }
                else if (type == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3])
                    ));
                }
                else if (type == "ChecklistGoal")
                {
                    if (parts.Length < 7)
                    {
                        Console.WriteLine($"⚠ Skipping corrupted checklist entry: {lines[i]}");
                        continue;
                    }

                    ChecklistGoal goal = new ChecklistGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]),
                        int.Parse(parts[4]),
                        int.Parse(parts[5])
                    );

                    int completed = int.Parse(parts[6]);

                    for (int j = 0; j < completed; j++)
                    {
                        goal.RecordEvent();
                    }

                    _goals.Add(goal);
                }
            }
            catch
            {
                Console.WriteLine($"⚠ Error loading line: {lines[i]}");
            }
        }

        Console.WriteLine("Goals loaded successfully.\n");
    }

}