using System.Collections.Generic;
using System.Linq;

public class AllBallGameMode : IGameMode
{
    private int _targetBallCount;

    private int _pickedBallCount = 0;

    public void Initialize()
    {
        EventManager.BallPicked += OnBallPicked;
        EventManager.BallsSpawned += OnBallsSpawned;
    }

    public int GetBallToWin()
    {
        return _targetBallCount - _pickedBallCount;
    }

    private void OnBallPicked(int ballType)
    {
        _pickedBallCount++;

        if (_pickedBallCount == _targetBallCount)
        {
            EventManager.NotifyWin();
        }
    }

    private void OnBallsSpawned(Dictionary<int, int> ballsPerTypes)
    {
        _targetBallCount = ballsPerTypes.Sum(pair => pair.Value);
    }
}
