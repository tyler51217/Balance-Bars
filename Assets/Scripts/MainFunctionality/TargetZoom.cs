using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetZoom : MonoBehaviour
{
    public SpriteRenderer fillSprite;
    public void changeSprite()
    {
        Zoom.targetZoom = fillSprite;
    }
}
