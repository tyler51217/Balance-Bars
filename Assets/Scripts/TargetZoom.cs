using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetZoom : MonoBehaviour
{

    //have  a method that changes the static fillsprite
    public SpriteRenderer fillSprite;
    public void changeSprite()
    {
        Zoom.targetZoom = fillSprite;
    }


    //have a method that returns a fillsprite



}
