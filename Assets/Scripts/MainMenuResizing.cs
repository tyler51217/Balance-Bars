using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuResizing : MonoBehaviour
{
    public RectTransform gameTypePanel;
    public RectTransform gameModePanel;
    public Button [] arrowButtons;
    
    void Start()
    {
        
        if(Screen.width > Screen.height)
        {
            Debug.Log("landscape");
            gameTypePanel.transform.position = new Vector3(Screen.width / 2, gameTypePanel.transform.position.y, gameTypePanel.transform.position.z);
            gameModePanel.transform.position = new Vector3(Screen.width / 2, gameModePanel.transform.position.y, gameModePanel.transform.position.z);

            //disable arrow buttons
            foreach(Button button in arrowButtons)
            {
                button.enabled = false;
                button.image.color = Color.black;
                Debug.Log(button.enabled);
            }

            

        }
        if (Screen.height > Screen.width)
        {
            Debug.Log("portrait");
        }




    }

    
}
