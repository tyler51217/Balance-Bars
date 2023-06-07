using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuResizing : MonoBehaviour
{
    public RectTransform gameTypePanel;
    
    
    void Start()
    {
        Debug.Log(Screen.width);
        

        gameTypePanel.transform.position = new Vector3(Screen.width, gameTypePanel.transform.localPosition.y, gameTypePanel.transform.localPosition.z);
        gameTypePanel.sizeDelta = new Vector2(Screen.width * 2, gameTypePanel.sizeDelta.y);

        
        
    }

    
}
