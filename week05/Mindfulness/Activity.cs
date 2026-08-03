using System;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting the {_name} activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How many seconds would you like for this activity? ");
        int seconds;
        while (!int.TryParse(Console.ReadLine(), out seconds) || seconds <= 0)
        {
            Console.Write("Please enter a number greater than 0: ");
        }
        _duration = seconds;

        Console.WriteLine("Get ready...");
        ShowCountDown(3);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(2);
        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
        ShowSpinner(2);
        Console.WriteLine();
    }

    public void ShowSpinner(int seconds)
    {
        string[] animation = { "/", "-", "\\", "|" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(animation[i % animation.Length]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i++;
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}