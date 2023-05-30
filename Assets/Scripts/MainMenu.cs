using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private string gameType = "Classic";
    private string gameMode = "Singles";

    
    public void toClassic()
    {
        gameType = "Classic";
    }

    public void toChaos()
    {
        gameType = "Chaos";
    }

    public void toSingles()
    {
        gameMode = "Ones";
    }

    public void toDoubles()
    {
        gameMode = "Twos";
    }

    public void toTriples()
    {
        gameMode = "Threes";
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
