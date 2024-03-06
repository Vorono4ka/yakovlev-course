public class Timer
{
    private float _totalTime;
    private float _passedTime;

    public Timer()
    {
    }

    public Timer(float seconds)
    {
        Reset(seconds);
    }

    public void Reset(float seconds)
    {
        _totalTime = seconds;
        _passedTime = 0;
    }

    public void Update(float deltaTime)
    {
        _passedTime += deltaTime;
    }

    public bool IsRunning()
    {
        return _passedTime < _totalTime;
    }
}
