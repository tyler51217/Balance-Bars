using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private string gameType = "Classic";
    private string gameMode = "Ones";
    public List<Text> gameTypeButtonsText;
    public List<Text> gameModeButtonsText;

    protected void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
    public void toMainMenu()
    {
        LoadTheScene("MainMenu");
    }
    public void toClassic()
    {
        gameType = "Classic";
        gameTypeButtonsText[0].color = Color.white;
        gameTypeButtonsText[1].color = Color.gray;
    }

    public void toChaos()
    {
        gameType = "Chaos";
        gameTypeButtonsText[0].color = Color.gray;
        gameTypeButtonsText[1].color = Color.white;
    }

    public void toSingles()
    {
        gameMode = "Ones";
        gameModeButtonsText[0].color = Color.white;
        gameModeButtonsText[1].color = Color.gray;
        gameModeButtonsText[2].color = Color.gray;
    }

    public void toDoubles()
    {
        gameMode = "Twos";
        gameModeButtonsText[0].color = Color.gray;
        gameModeButtonsText[1].color = Color.white;
        gameModeButtonsText[2].color = Color.gray;
    }

    public void toTriples()
    {
        gameMode = "Threes";
        gameModeButtonsText[0].color = Color.gray;
        gameModeButtonsText[1].color = Color.gray;
        gameModeButtonsText[2].color = Color.white;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(gameType + gameMode);
    }
    public void ShopButton()
    {
        LoadTheScene("Shop");
    }

    private void LoadTheScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
