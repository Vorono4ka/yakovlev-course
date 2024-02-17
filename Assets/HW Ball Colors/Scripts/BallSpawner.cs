using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private Color[] _colors;
    [SerializeField, Range(1, 20)] private int _ballCount = 5;
    [SerializeField, Range(1, 20)] private int _maxRange = 10;

    private List<Ball> _balls = new List<Ball>();

    public void SpawnBalls()
    {
        Dictionary<int, int> ballsPerTypes = new Dictionary<int, int>();
        for (int i = 0; i < _colors.Length; i++)
        {
            ballsPerTypes[i] = 0;
        }

        for (int i = 0; i < _ballCount; i++)
        { 
            int x = Random.Range(-_maxRange, _maxRange + 1);
            int z = Random.Range(-_maxRange, _maxRange + 1);

            Ball ball = Instantiate(_ballPrefab, new Vector3(x, 1, z), Quaternion.identity);
            int randomType = Random.Range(0, _colors.Length);
            ball.Initialize(randomType, _colors[randomType]);
            _balls.Add(ball);

            ballsPerTypes[randomType]++;
        }

        EventManager.NotifyBallSpawned(ballsPerTypes);
    }

    public void DestroyAllBalls()
    {
        _balls.ForEach(ball => 
        { 
            if (ball != null) 
                Destroy(ball.gameObject); 
        });
        _balls.Clear();
    }
}
