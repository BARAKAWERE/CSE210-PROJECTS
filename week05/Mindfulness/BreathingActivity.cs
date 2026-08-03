using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        bool breatheIn = true;
        while (DateTime.Now < endTime)
        {
            Console.Write(breatheIn ? "Breathe in..." : "Breathe out...");
            ShowCountDown(4);
            Console.WriteLine();
            breatheIn = !breatheIn;
        }

        DisplayEndingMessage();
    }
}