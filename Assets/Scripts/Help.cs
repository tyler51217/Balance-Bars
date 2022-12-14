using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public void ShowHelpWindow()
    {
        gameObject.SetActive(true);


    }

    public void HideHelpWindow()
    {
        gameObject.SetActive(false);
    }
}
