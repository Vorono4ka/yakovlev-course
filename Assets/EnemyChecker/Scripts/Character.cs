using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    private ICharacterFinder _characterFinder;
    private Func<Character, bool> _enemyPredicate;
    private bool _isInit;

    public void Initialize(ICharacterFinder characterFinder, Func<Character, bool> enemyPredicate)
    {
        _characterFinder = characterFinder;
        _enemyPredicate = enemyPredicate;

        _isInit = true;
    }

    private void Update()
    {
        if (_isInit == false)
            throw new InvalidOperationException(nameof(_isInit));

        IEnumerable<Character> characters = _characterFinder.Find();

        if (characters != null)
            Affect(characters.Where(_enemyPredicate));
    }

    protected abstract void Affect(IEnumerable<Character> characters);
}
