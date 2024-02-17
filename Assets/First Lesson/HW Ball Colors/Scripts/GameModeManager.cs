using TMPro;
using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    [SerializeField] private GameObject _winText;
    [SerializeField] private GameObject _loseText;
    [SerializeField] private TMP_Text _ballCount;

    [SerializeField] private BallSpawner _spawner;

    [SerializeField] private string _ballLeftFormat;

    private IGameMode _gameMode;

    private void Start()
    {
        EventManager.Lost += () =>
        {
            _loseText.SetActive(true);
            _spawner.DestroyAllBalls();
        };
        EventManager.Won += () =>
        {
            _winText.SetActive(true);
            _spawner.DestroyAllBalls();
        };
        EventManager.BallCountChanged += UpdateBallCount;
    }

    public void SetAllBallGameMode()
    {
        SetGameMode(new AllBallGameMode());
    }

    public void SetSingleColorBallGameMode()
    {
        SetGameMode(new SingleColorBallGameMode());
    }

    private void SetGameMode(IGameMode gameMode)
    {
        _gameMode.Deinitialize();
        _spawner.DestroyAllBalls();
        _loseText.SetActive(false);
        _winText.SetActive(false);

        _gameMode = gameMode;
        _gameMode.Initialize();
        _spawner.SpawnBalls();
        UpdateBallCount();
    }

    private void UpdateBallCount()
    {
         _ballCount.text = string.Format(_ballLeftFormat, _gameMode.GetBallToWin());
    }
}
