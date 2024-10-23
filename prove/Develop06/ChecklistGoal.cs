using System;

class ChecklistGoal : Goal
{
    private int _amountComplete;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int amountComplete, int target, int bonus) : base(shortName, description, points)
    {
        _amountComplete = amountComplete;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _amountComplete++;
    }

    public override bool IsComplete()
    {
        return _target <= _amountComplete;
    }

    public override string GetDetailsString()
    {
        var status = _amountComplete == _target ? "X" : " ";

        return $"[{status}] {_shortName} ({_description}) -- Currently completed: {_amountComplete}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal,{_shortName},{_description},{_points},{IsComplete()},{_amountComplete},{_target},{_bonus}";
    }

    public override int GetPoints()
    {
        return IsComplete() ? _points + _bonus : _points;
    }
}
