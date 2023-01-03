using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    public Toggle toggle;
    private bool IsOn;

    private void Start() //only runs when HelpPanel is .SetActive
    {
        

        //check playerprefs if open on start
        if(PlayerPrefs.GetInt("IsOn", 1) == 1)
        {
            toggle.isOn = true;
            ShowHelpWindow();
            
        }
        else
        {
            HideHelpWindow();
        }

        Debug.Log("current player pref: " + PlayerPrefs.GetInt("IsOn"));
        toggle.onValueChanged.AddListener(delegate
        {
            ToggleValueChanged(toggle);
        });

    }

    void ToggleValueChanged(Toggle toggleValue)
    {
        Debug.Log("toggle changed");

        

        

        if (PlayerPrefs.GetInt("IsOn") == 1)
        {
            
            PlayerPrefs.SetInt("IsOn", 0);
        }
        else
        {
            
            PlayerPrefs.SetInt("IsOn", 1);
            
        }

        

        

    }



    public void ShowHelpWindow()
    {
        gameObject.SetActive(true);


    }

    public void HideHelpWindow()
    {
        gameObject.SetActive(false);
    }

    


}
