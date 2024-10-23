// I exceeded the requirements of this program by making the goal manager automatically load
// goals from a file when it first starts. I also made it save the goals before the program exits.
// When the user manually tries to save/load goals, then they will be prompted for a filename.

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}