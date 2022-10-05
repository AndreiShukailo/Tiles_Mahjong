using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _defeatScreen;
    [SerializeField] private GameObject _victoryScreen;
    [SerializeField] private TMP_Text _currentLevelText;


    public void ActiveDefeatScene()
    {
        _defeatScreen.SetActive(true);
    }

    public void ActiveVictoryScene()
    {
        _victoryScreen.SetActive(true);
    }

    public void RenderCurrentLevelText(int currentLevel)
    {
        _currentLevelText.text = currentLevel.ToString();
    }

    public void CloseAllScreen()
    {
        _defeatScreen.SetActive(false);
        _victoryScreen.SetActive(false);
    }
}
