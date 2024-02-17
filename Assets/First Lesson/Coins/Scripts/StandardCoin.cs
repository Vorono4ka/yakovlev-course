using UnityEngine;

public class StandardCoin : Coin
{
    [SerializeField, Range(1, 50)] private int _value;

    protected override void AddCoins(ICoinPicker coinPicker) => coinPicker.Add(_value);
}
