using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClassicMode : MonoBehaviour
{

    public SpriteRenderer fillSprite;
    private bool heldDown = false;
    private float scale = 0.01f;
    private float growthRate = 0.01f;
    private int lives = 2;

    public Colliders fillCollider; //this is required to get information from the Colliders class. Fill is attached to this
    public Scoreboard scoreboard;

    
    public GameOverScreen gameOverScreen;


    void Start()
    {
        QualitySettings.vSyncCount = 0; // this DOES affect mobile games and whoever said it doesnt is a liar
        Application.targetFrameRate = 60;
    }

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
        
        if(fillCollider.GetInBottom() == true)
        {
            scoreboard.AddScore();
        }
        else
        {
            
            YouLose();
        }

        if (lives >= 0)
        {
            AddSpeed();
            ShrinkTop();
            ShrinkBottom();
            RandomizeBottom();
        }

    }


    public void OnRelease()
    {
        heldDown = false;
        
        if(fillCollider.GetInTop() == true)
        {
            scoreboard.AddScore();
        }
        else
        {
            
            YouLose();
        }


        if (lives >= 0)
        {
            AddSpeed();
            ShrinkTop();
            ShrinkBottom();
            RandomizeTop();
        }
        

    }

    private void AddSpeed()
    {
        if (scoreboard.GetScore() % 5 == 0)
        {
            growthRate = growthRate + 0.001f;
        }
    }

    private void ShrinkTop()
    {
        if (scoreboard.GetScore() % 10 == 0 && fillCollider.GetTopSprite().transform.localScale.y > 0.1f)
        {
            SpriteRenderer top = fillCollider.GetTopSprite();
            fillCollider.GetTopSprite().transform.localScale = new Vector3(top.transform.localScale.x, top.transform.localScale.y - 0.01f, 1);
        }
    }

    private void ShrinkBottom()
    {
        if (scoreboard.GetScore() % 10 == 1 && fillCollider.GetBottomSprite().transform.localScale.y > 0.1f)
        {
            SpriteRenderer bottom = fillCollider.GetBottomSprite();
            fillCollider.GetBottomSprite().transform.localScale = new Vector3(bottom.transform.localScale.x, bottom.transform.localScale.y - 0.01f, 1);
        }
    }


    private void RandomizeTop()
    {
        SpriteRenderer top = fillCollider.GetTopSprite();
        fillCollider.GetTopSprite().transform.localPosition = new Vector3(top.transform.localPosition.x, Random.Range(0, 0.25f), 1); 

        

    }


    private void RandomizeBottom()
    {
        SpriteRenderer bottom = fillCollider.GetBottomSprite();
        fillCollider.GetBottomSprite().transform.localPosition = new Vector3(bottom.transform.localPosition.x, Random.Range(-0.5f, -0.25f), 1);

        

    }

    private void YouLose()
    {
        
        
        string temp = "FullHeart (" + lives + ")";
        GameObject h = GameObject.Find(temp);

        h.SetActive(false);

            


        lives = lives - 1;
        

        if (lives < 0)
        {
            Button b = GetComponentInChildren<Button>(); // works
            b.gameObject.SetActive(false);
            growthRate = 0;


            StartCoroutine(GameOver());

            

            




        }


    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.2f);
        gameOverScreen.Setup(scoreboard.GetScore());
    }

    public int GetLives()
    {
        return lives;
    }





}
