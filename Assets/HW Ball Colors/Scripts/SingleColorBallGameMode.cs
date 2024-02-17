using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SingleColorBallGameMode : IGameMode
{
    private int _targetBallCount;
    private int _targetBallType;

    private int _pickedBallCount = 0;
    private Dictionary<int, int> _ballsPerTypes;

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
        if (_targetBallType == -1)
        {
            _targetBallType = ballType;
            _targetBallCount = _ballsPerTypes[ballType];
        }

        if (ballType != _targetBallType)
        {
            EventManager.NotifyLose();
            return;
        }

        _pickedBallCount++;
        EventManager.NotifyBallCountChanged();

        if (_pickedBallCount == _targetBallCount)
        {
            EventManager.NotifyWin();
        }
    }

    private void OnBallsSpawned(Dictionary<int, int> ballsPerTypes)
    {
        _ballsPerTypes = ballsPerTypes;
        _targetBallType = -1;
        _pickedBallCount = 0;
        _targetBallCount = _ballsPerTypes.Min(pair => pair.Value);
    }
}
