using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levels;
    [SerializeField] private UI _ui;

    private GameObject _currentLevel;
    private int _currentLevelNumber;

    public int CurrentLevelNumber => _currentLevelNumber;
    public List<GameObject> Levels => _levels;

    private void Start()
    {
        InitialLevel(1);
    }

    private void InitialLevel(int level)
    {
        Instantiate(_levels[level - 1], this.transform);
        _currentLevel = _levels[level - 1];
        _ui.RenderCurrentLevelText(level);
        _currentLevelNumber = level;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        if (_currentLevelNumber < _levels.Count)
        {
            Destroy(transform.GetChild(_currentLevelNumber - 1).gameObject);
            _currentLevelNumber++;
            InitialLevel(_currentLevelNumber);
        }

        _ui.CloseAllScreen();
    }
}
