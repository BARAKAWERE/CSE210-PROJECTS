using System;

public abstract class Goal
{
    protected string name;
    protected string description;
    protected int points;

    public Goal(string name, string description, int points)
    {
        this.name = name;
        this.description = description;
        this.points = points;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetails();
    public abstract string GetSaveString();
}

public class SimpleGoal : Goal
{
    private bool isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        this.isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        isComplete = true;
        return points;
    }

    public override bool IsComplete() => isComplete;

    public override string GetDetails()
    {
        string mark = isComplete ? "[X]" : "[ ]";
        return $"{mark} {name} ({description})";
    }

    public override string GetSaveString()
    {
        return $"SimpleGoal:{name},{description},{points},{isComplete}";
    }
}

public class EternalGoal : Goal
{
    private int timesDone;

    public EternalGoal(string name, string description, int points, int timesDone = 0)
        : base(name, description, points)
    {
        this.timesDone = timesDone;
    }

    public override int RecordEvent()
    {
        timesDone++;
        return points;
    }

    public override bool IsComplete() => false;

    public override string GetDetails()
    {
        return $"[ ] {name} ({description}) -- done {timesDone} times";
    }

    public override string GetSaveString()
    {
        return $"EternalGoal:{name},{description},{points},{timesDone}";
    }
}

public class ChecklistGoal : Goal
{
    private int timesDone;
    private int target;
    private int bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int timesDone = 0)
        : base(name, description, points)
    {
        this.target = target;
        this.bonus = bonus;
        this.timesDone = timesDone;
    }

    public override int RecordEvent()
    {
        timesDone++;
        if (timesDone == target)
            return points + bonus;
        return points;
    }

    public override bool IsComplete() => timesDone >= target;

    public override string GetDetails()
    {
        string mark = IsComplete() ? "[X]" : "[ ]";
        return $"{mark} {name} ({description}) -- Completed {timesDone}/{target} times";
    }

    public override string GetSaveString()
    {
        return $"ChecklistGoal:{name},{description},{points},{target},{bonus},{timesDone}";
    }
}