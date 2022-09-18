using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void ClassicButton()
    {
        SceneManager.LoadScene("Game1");
    }

    public void ChaosButton()
    {
        SceneManager.LoadScene("GameChaos");
    }

    public void ChaosThreesButton()
    {
        SceneManager.LoadScene("ChaosThrees");
    }

    public void ShopButton()
    {

    }



}
