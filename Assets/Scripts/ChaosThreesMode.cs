using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosThreesMode : ChaosMode
{

    // public Colliders fillCollider; //this is required to get information from the Colliders class. Fill is attached to this
    public Colliders fillColliderLeft; 
    public Colliders fillColliderRight;

    public SpriteRenderer fillSpriteLeft;
    public SpriteRenderer fillSpriteRight;

    

    protected bool heldDownLeft = false;
    protected bool heldDownRight = false;

    protected float scaleLeft = 0.1f;
    protected float scaleRight = 0.1f;

    

    void Update()
    {
        movement();
        movementLeft();
        movementRight();

        

        

    }

    protected void movement()
    {
        if (heldDown)
        {
            scale += growthRate;
            fillSprite.transform.localScale = new Vector3(1, scale, 1);
        }
        else
        {
            scale -= growthRate;
            fillSprite.transform.localScale = new Vector3(1, scale, 1);
        }


        if (fillSprite.transform.localScale.y >= 1)
        {
            fillSprite.transform.localScale = new Vector3(1, 1, 1);
            scale -= growthRate;
            //return;
        }
        if (fillSprite.transform.localScale.y <= 0)
        {
            fillSprite.transform.localScale = new Vector3(1, 0.01f, 1);
            scale += growthRate;
            //return;
        }
    }

    protected void movementLeft()
    {
        if (heldDownLeft)
        {
            scaleLeft += growthRate;
            fillSpriteLeft.transform.localScale = new Vector3(1, scaleLeft, 1);
        }
        else
        {
            scaleLeft -= growthRate;
            fillSpriteLeft.transform.localScale = new Vector3(1, scaleLeft, 1);
        }


        if (fillSpriteLeft.transform.localScale.y >= 1)
        {
            fillSpriteLeft.transform.localScale = new Vector3(1, 1, 1);
            scaleLeft -= growthRate;
            //return;
        }
        if (fillSpriteLeft.transform.localScale.y <= 0)
        {
            fillSpriteLeft.transform.localScale = new Vector3(1, 0.01f, 1);
            scaleLeft += growthRate;
            //return;
        }
    }

    protected void movementRight()
    {
        if (heldDownRight)
        {
            scaleRight += growthRate;
            fillSpriteRight.transform.localScale = new Vector3(1, scaleRight, 1);
        }
        else
        {
            scaleRight -= growthRate;
            fillSpriteRight.transform.localScale = new Vector3(1, scaleRight, 1);
        }


        if (fillSpriteRight.transform.localScale.y >= 1)
        {
            fillSpriteRight.transform.localScale = new Vector3(1, 1, 1);
            scaleRight -= growthRate;
            //return;
        }
        if (fillSpriteRight.transform.localScale.y <= 0)
        {
            fillSpriteRight.transform.localScale = new Vector3(1, 0.01f, 1);
            scaleRight += growthRate;
            //return;
        }
    }




    public void OnPressLeft()
    {
        heldDownLeft = true;

        if (fillColliderLeft.GetInBottom() == true)
        {
            scoreboard.AddScore();
        }
        else
        {

            YouLose();
        }

        if (lives >= 0)
        {
            RandomizeSpeed();
            ShrinkTop();
            ShrinkBottom();
            RandomizeBottomLeft();
        }

    }


    public void OnReleaseLeft()
    {
        heldDownLeft = false;

        if (fillColliderLeft.GetInTop() == true)
        {
            scoreboard.AddScore();
        }
        else
        {

            YouLose();
        }


        if (lives >= 0)
        {
            RandomizeSpeed();
            ShrinkTop();
            ShrinkBottom();
            RandomizeTopLeft();
        }


    }


    public void OnPressRight()
    {
        heldDownRight = true;

        if (fillColliderRight.GetInBottom() == true)
        {
            scoreboard.AddScore();
        }
        else
        {

            YouLose();
        }

        if (lives >= 0)
        {
            RandomizeSpeed();
            ShrinkTop();
            ShrinkBottom();
            RandomizeBottomRight();
        }

    }


    public void OnReleaseRight()
    {
        heldDownRight = false;

        if (fillColliderRight.GetInTop() == true)
        {
            scoreboard.AddScore();
        }
        else
        {

            YouLose();
        }


        if (lives >= 0)
        {
            RandomizeSpeed();
            ShrinkTop();
            ShrinkBottom();
            RandomizeTopRight();
        }


    }


    protected void RandomizeTopLeft()
    {
        SpriteRenderer topLeft = fillColliderLeft.GetTopSprite();
        fillColliderLeft.GetTopSprite().transform.localPosition = new Vector3(topLeft.transform.localPosition.x, Random.Range(0, 0.25f), 1);
    }


    protected void RandomizeBottomLeft()
    {
        SpriteRenderer bottomLeft = fillColliderLeft.GetBottomSprite();
        fillColliderLeft.GetBottomSprite().transform.localPosition = new Vector3(bottomLeft.transform.localPosition.x, Random.Range(-0.5f, -0.25f), 1);
    }

    protected void RandomizeTopRight()
    {
        SpriteRenderer topRight = fillColliderRight.GetTopSprite();
        fillColliderRight.GetTopSprite().transform.localPosition = new Vector3(topRight.transform.localPosition.x, Random.Range(0, 0.25f), 1);
    }


    protected void RandomizeBottomRight()
    {
        SpriteRenderer bottomRight = fillColliderRight.GetBottomSprite();
        fillColliderRight.GetBottomSprite().transform.localPosition = new Vector3(bottomRight.transform.localPosition.x, Random.Range(-0.5f, -0.25f), 1);
    }

    protected void ShrinkTop()
    {
        if (scoreboard.GetScore() % 10 == 0 && fillCollider.GetTopSprite().transform.localScale.y > 0.1f)
        {
            SpriteRenderer top = fillCollider.GetTopSprite();
            fillCollider.GetTopSprite().transform.localScale = new Vector3(top.transform.localScale.x, top.transform.localScale.y - 0.01f, 1); //shrink middle top
            fillColliderLeft.GetTopSprite().transform.localScale = new Vector3(top.transform.localScale.x, top.transform.localScale.y - 0.01f, 1); //shrink left top
            fillColliderRight.GetTopSprite().transform.localScale = new Vector3(top.transform.localScale.x, top.transform.localScale.y - 0.01f, 1); //shrink right top
        }
    }

    protected void ShrinkBottom()
    {
        if (scoreboard.GetScore() % 10 == 1 && fillCollider.GetBottomSprite().transform.localScale.y > 0.1f)
        {
            SpriteRenderer bottom = fillCollider.GetBottomSprite();
            fillCollider.GetBottomSprite().transform.localScale = new Vector3(bottom.transform.localScale.x, bottom.transform.localScale.y - 0.01f, 1); //shrink middle bottom
            fillColliderLeft.GetBottomSprite().transform.localScale = new Vector3(bottom.transform.localScale.x, bottom.transform.localScale.y - 0.01f, 1); //shrink left bottom
            fillColliderRight.GetBottomSprite().transform.localScale = new Vector3(bottom.transform.localScale.x, bottom.transform.localScale.y - 0.01f, 1); //shrink right bottom
        }
    }









}
