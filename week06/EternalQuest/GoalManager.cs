using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int score = 0;

    public void Run()
    {
        while (true)
        {
            Console.WriteLine($"\nYou have {score} points. Level {GetLevel()}.");
            Console.WriteLine("1. Create a goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record an event");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1") CreateGoal();
            else if (choice == "2") ListGoals();
            else if (choice == "3") RecordEvent();
            else if (choice == "4") Save();
            else if (choice == "5") Load();
            else if (choice == "6") break;
            else Console.WriteLine("Not a valid option.");
        }
    }

    // simple level system - every 1000 points is a new level, just for a bit of fun
    private int GetLevel() => (score / 1000) + 1;

    private void CreateGoal()
    {
        Console.WriteLine("What type of goal?");
        Console.WriteLine("1. Simple goal (done once)");
        Console.WriteLine("2. Eternal goal (never finishes)");
        Console.WriteLine("3. Checklist goal (done a set number of times, bonus at the end)");
        Console.Write("Type: ");
        string type = Console.ReadLine();

        Console.Write("Goal name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (type == "2")
        {
            goals.Add(new EternalGoal(name, desc, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times to complete it? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Bonus for finishing all of them: ");
            int bonus = int.Parse(Console.ReadLine());
            goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
        else
        {
            Console.WriteLine("That's not a valid type, goal was not created.");
        }
    }

    private void ListGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetails()}");
        }
    }

    private void RecordEvent()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        ListGoals();
        Console.Write("Which goal did you do? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= goals.Count)
        {
            Console.WriteLine("That's not a goal on the list.");
            return;
        }

        int before = GetLevel();
        int earned = goals[index].RecordEvent();
        score += earned;
        Console.WriteLine($"Nice, you earned {earned} points!");

        if (GetLevel() > before)
        {
            Console.WriteLine($"Level up! You're now level {GetLevel()}.");
        }
    }

    private void Save()
    {
        Console.Write("File name to save to: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(score);
            foreach (Goal g in goals)
            {
                writer.WriteLine(g.GetSaveString());
            }
        }
        Console.WriteLine("Saved.");
    }

    private void Load()
    {
        Console.Write("File name to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("Can't find that file.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        score = int.Parse(lines[0]);
        goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            string type = parts[0];
            string[] d = parts[1].Split(',');

            if (type == "SimpleGoal")
                goals.Add(new SimpleGoal(d[0], d[1], int.Parse(d[2]), bool.Parse(d[3])));
            else if (type == "EternalGoal")
                goals.Add(new EternalGoal(d[0], d[1], int.Parse(d[2]), int.Parse(d[3])));
            else if (type == "ChecklistGoal")
                goals.Add(new ChecklistGoal(d[0], d[1], int.Parse(d[2]), int.Parse(d[3]), int.Parse(d[4]), int.Parse(d[5])));
        }
        Console.WriteLine("Loaded.");
    }
}