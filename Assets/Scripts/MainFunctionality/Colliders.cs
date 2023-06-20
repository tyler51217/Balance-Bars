using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders : MonoBehaviour
{
    private bool inTop;
    private bool inBottom;

    public SpriteRenderer topSprite;
    public SpriteRenderer bottomSprite;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Top")
        {
            inTop = true;
        }

        if (collision.tag == "Bottom")
        {
            inBottom = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Top")
        {
            inTop = false;
        }

        if (collision.tag == "Bottom")
        {
            inBottom = false;
        }
    }

    public bool GetInTop()
    {
        return inTop;
    }

    public bool GetInBottom()
    {
        return inBottom;
    }

    public SpriteRenderer GetTopSprite()
    {
        return topSprite;
    }

    public SpriteRenderer GetBottomSprite()
    {
        return bottomSprite;
    }
}
