using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private Button _restart;
    [SerializeField] private Button _nextLevel;

    private void OnEnable()
    {
        if (_gameController.CurrentLevelNumber < _gameController.Levels.Count)
            _nextLevel.gameObject.SetActive(true);
        else _restart.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        _restart.gameObject.SetActive(false);
        _nextLevel.gameObject.SetActive(false);
    }
}
