using UnityEngine;

public class MediatorBootstrap : MonoBehaviour
{
    [SerializeField] private GameplayMediator _gameplayMediator;
    [SerializeField] private DefeatPanel _defeatPanel;

    private Level _level;

    private void Awake()
    {
        _level = new Level();

        _gameplayMediator.Initialize(_level);
        _defeatPanel.Initialize(_gameplayMediator);

        _level.Start();
    }

    // Ќ≈ѕ–ј¬»Ћ№Ќќ, в продакшен коде встречатьс€ такого не должно
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _level.OnDefeat();
    }
}
