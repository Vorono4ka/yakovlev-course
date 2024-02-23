using System;
using UnityEngine;

public class Level
{
    public event Action Defeat;

    public void Start()
    {
        // Логика старта
        Debug.Log("Level started.");
    }

    public void Restart()
    {
        // Логика очистки уровня
        Start();
    }

    public void OnDefeat()
    {
        // Логика остановки игры
        // Вывод панельки проигрыша

        // Второй метод обработки проигрыша, нет явной связи с Mediator
        Defeat?.Invoke();
    }
}
