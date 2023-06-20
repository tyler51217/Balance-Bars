using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    private void Start() //only runs when HelpPanel is .SetActive
    {
        if(PlayerPrefs.GetInt("IsOn", 0) == 0)
        {
            ShowHelpWindow();
        }
        else
        {
            HideHelpWindow();
        }
    }
    public void ShowHelpWindow()
    {
        gameObject.SetActive(true);
    }

    public void HideHelpWindow()
    {
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("IsOn", 1);
    }
}
