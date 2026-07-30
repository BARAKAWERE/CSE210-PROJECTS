using System;

// Walks the user through slow breathing by alternating "Breathe in..." and
// "Breathe out..." with a short countdown after each one.
public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
        : base("Breathing",
            "This activity will help you relax by walking you through breathing in and " +
            "out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        bool breatheIn = true;

        while (DateTime.Now < endTime)
        {
            Console.Write(breatheIn ? "Breathe in..." : "Breathe out...");
            ShowCountDown(4);
            Console.WriteLine();
            breatheIn = !breatheIn;
        }
    }
}