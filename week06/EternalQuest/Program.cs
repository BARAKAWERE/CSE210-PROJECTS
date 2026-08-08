using System;

// I added a simple leveling system to gamify the score  every 1000 points
// bumps the player up a level, and a "Level up!" message prints when it
// happens. It is a small touch but  gives some short term excitement on
// top of just watching the number going up, which was one of the ideas in
// the assignment.
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Eternal Quest!");
        GoalManager manager = new GoalManager();
        manager.Run();
    }
}