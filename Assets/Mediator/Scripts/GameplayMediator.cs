using UnityEngine;

public class GameplayMediator : MonoBehaviour
{
    // Не хорошо, в идеале вообще отойти от MonoBehaviour,
    [SerializeField] private DefeatPanel _defeatPanel;

    private Level _level;

    public void Initialize(Level level)
    {
        _level = level;
        _level.Defeat += OnLevelDefeat;
    }

    private void OnDestroy()
    {
        _level.Defeat -= OnLevelDefeat;
    }

    public void OnLevelDefeat() => _defeatPanel.Show();

    public void RestartLevel()
    {
        _defeatPanel.Hide();
        _level.Restart();
    }
}
