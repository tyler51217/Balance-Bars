using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChaosMode : ClassicMode //i believe inheritence can inherit monobehavior like this
{

    protected float speed = 0f;




    void Update()
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
            return;
        }
        if (fillSprite.transform.localScale.y <= 0)
        {
            fillSprite.transform.localScale = new Vector3(1, 0.01f, 1);
            scale += growthRate;
            return;
        }




    }


    public void OnPress()
    {
        heldDown = true;

        if (fillCollider.GetInBottom() == true)
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
            RandomizeBottom();
        }

    }


    public void OnRelease()
    {
        heldDown = false;

        if (fillCollider.GetInTop() == true)
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
            RandomizeTop();
        }


    }

    protected void RandomizeSpeed()
    {
        if (scoreboard.GetScore() % 5 == 0)
        {
            speed = speed + 0.001f;

        }

        growthRate = Random.Range(speed + 0.01f, speed + 0.015f);
    }



    







    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.2f);
        gameOverScreen.Setup(scoreboard.GetScore());
    }




}