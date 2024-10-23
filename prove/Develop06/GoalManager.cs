using System;

class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>{};
        _score = 0;
    }

    public void Start()
    {
        string input;

        if (File.Exists("goals.txt"))
        {
            Console.WriteLine("Existing goals file found. Loading goals... ");
            LoadGoals(false);
            Console.WriteLine();
        }

        do
        {
            DisplayPlayerInfo();

            Console.WriteLine();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            Console.Write("Select a choice from the menu: ");
            input = Console.ReadLine();

            Console.Clear();

            switch (input)
            {
                case "1":
                    ListGoalNames();
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    Console.WriteLine();
                    break;
                case "3":
                    SaveGoals(true);
                    Console.WriteLine();
                    break;
                case "4":
                    LoadGoals(true);
                    Console.WriteLine();
                    break;
                case "5":
                    ListGoalNames();
                    RecordEvent();
                    break;
                case "6":
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        } while (input != "6");

        SaveGoals(false);

        Console.WriteLine();
        Console.WriteLine("Goodbye!");
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    private void CreateGoal()
    {
        var goalNames = new List<string>{ "Simple Goal", "Eternal Goal", "Checklist Goal" };

        Console.WriteLine("The types of Goals are:");

        for (int i = 0; i < goalNames.Count; i++)
        {
            Console.WriteLine($"  {i+1}. {goalNames[i]}");
        }

        while (true)
        {
            Console.Write("Which type of goal would you like to create? ");
            string goalType = Console.ReadLine();

            if (goalType != "1" && goalType != "2" && goalType != "3")
            {
                Console.WriteLine("Invalid input. Please try again.");
                continue;
            }

            Console.Write("What is the name of your goal? ");
            string goalName = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string goalDescription = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            int goalPoints = int.Parse(Console.ReadLine());

            switch (goalType)
            {
                case "1":
                    _goals.Add(new SimpleGoal(goalName, goalDescription, goalPoints, false));
                    break;
                case "2":
                    _goals.Add(new EternalGoal(goalName, goalDescription, goalPoints));
                    break;
                case "3":
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int goalTarget = int.Parse(Console.ReadLine());

                    Console.Write("What is the bonus for completing it that many times? ");
                    int goalBonus = int.Parse(Console.ReadLine());

                    _goals.Add(new ChecklistGoal(goalName, goalDescription, goalPoints, 0, goalTarget, goalBonus));
                    break;
            }

            Console.WriteLine();

            break;
        }
    }

    private void ListGoalDetails()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i+1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void SaveGoals(bool prompt = true)
    {
        string filename = "goals.txt";

        if (prompt)
        {
            Console.Write("What is the filename for the goals file? ");
            filename = Console.ReadLine();
        }

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved!");
    }

    private void LoadGoals(bool prompt = true)
    {
        string filename = "goals.txt";

        if (prompt)
        {
            Console.Write("What is the filename for the goals file? ");
            filename = Console.ReadLine();
        }

        _goals = new List<Goal>{};

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');

                string goalType = parts[0];
                string goalName = parts[1];
                string goalDescription = parts[2];
                int goalPoints = int.Parse(parts[3]);
                bool goalComplete = bool.Parse(parts[4]);

                int goalAmountComplete = 0;
                int goalTarget = 0;
                int goalBonus = 0;

                if (parts.Length > 5)
                {
                    goalAmountComplete = int.Parse(parts[5]);
                    goalTarget = int.Parse(parts[6]);
                    goalBonus = int.Parse(parts[7]);
                }

                switch (goalType)
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(goalName, goalDescription, goalPoints, goalComplete));
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(goalName, goalDescription, goalPoints));
                        break;
                    case "ChecklistGoal":
                        _goals.Add(new ChecklistGoal(goalName, goalDescription, goalPoints, goalAmountComplete, goalTarget, goalBonus));
                        break;
                }
            }

            _score = 0;
            foreach (var goal in _goals)
            {
                if (goal.IsComplete())
                {
                    _score += goal.GetPoints();
                }
            }
        }

        Console.WriteLine("Goals loaded!");
    }

    private void RecordEvent()
    {
        int goalIndex;

        while(true)
        {
            Console.Write("Which goal did you accomplish? ");

            goalIndex = int.Parse(Console.ReadLine()) - 1;

            if (goalIndex < 0 || goalIndex >= _goals.Count)
            {
                Console.WriteLine("Invalid input. Please try again.");
                continue;
            }

            break;
        }

        var goal = _goals[goalIndex];

        goal.RecordEvent();

        if (goal.IsComplete())
        {
            _score += goal.GetPoints();

            Console.WriteLine($"Congratulations! You have earned: {goal.GetPoints()}!");
        }
    }

    private void ListGoalNames()
    {
        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i+1}. {_goals[i].GetShortName()}");
        }
    }
}
