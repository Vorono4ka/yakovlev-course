using System;
using System.Collections.Generic;

public static class EventManager
{
    public static event Action<Dictionary<int, int>> BallsSpawned;
    public static event Action<int> BallPicked;
    public static event Action BallCountChanged;
    public static event Action Won;
    public static event Action Lost;

    public static void NotifyBallPicked(int ballType)
    {
        BallPicked?.Invoke(ballType);
    }

    public static void NotifyBallSpawned(Dictionary<int, int> ballsPerTypes)
    {
        BallsSpawned?.Invoke(ballsPerTypes);
    }

    public static void NotifyWin()
    {
        Won?.Invoke();
    }

    public static void NotifyLose()
    {
        Lost?.Invoke();
    }

    internal static void NotifyBallCountChanged()
    {
        BallCountChanged?.Invoke();
    }
}
