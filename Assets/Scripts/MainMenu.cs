using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    

    public void ClassicButton()
    {
        LoadTheScene("Game1");
    }

    public void ChaosButton()
    {
        LoadTheScene("GameChaos");
    }

    public void ClassicTwosButton()
    {
        LoadTheScene("ClassicTwos");
    }

    public void ChaosTwosButton()
    {
        LoadTheScene("ChaosTwos");
    }

    public void ClassicThreesButton()
    {
        LoadTheScene("ClassicThrees");
    }

    public void ChaosThreesButton()
    {
        LoadTheScene("ChaosThrees");
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
