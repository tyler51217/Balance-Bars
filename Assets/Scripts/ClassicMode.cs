using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClassicMode : MonoBehaviour, IDataPersistence
{

    public SpriteRenderer fillSprite;
    protected bool heldDown;
    protected float scale;
    protected float growthRate;
    //protected int lives;

    public Colliders fillCollider; //this is required to get information from the Colliders class. Fill is attached to this
    public Scoreboard scoreboard;

    
    public GameOverScreen gameOverScreen;

    public bool gameStarted;
    public EventTrigger gameButton;

    
    
    protected void Start()
    {
        QualitySettings.vSyncCount = 0; // this DOES affect mobile games
        Application.targetFrameRate = 60;

        heldDown = false;
        scale = 0.01f;
        growthRate = 0.01f;
        //lives = 2;
    }

    protected void Update()
    {
        

        if (heldDown && fillSprite.transform.localScale.y >= 1)
        {
            return;
        }
        if(!heldDown && fillSprite.transform.localScale.y <= 0)
        {
            return;
        }

        var sign = heldDown ? 1 : -1;
        scale += sign * growthRate;

        fillSprite.transform.localScale = new Vector3(1, scale, 1);

    }


    public void OnButtonChange()
    {
        gameStarted = true;

        if((fillCollider.GetInTop() && heldDown) || (fillCollider.GetInBottom() && !heldDown))
        {
            scoreboard.AddScore();
        }
        else
        {
            YouLose();
        }

        if (Lives.GetHealth() <= 0)
        {
            return;
        }

        AddSpeed();
        ShrinkTop();
        ShrinkBottom();

        if (!heldDown)
        {
            RandomizeBottom();
        }
        if (heldDown)
        {
            RandomizeTop();
        }

        heldDown = !heldDown;
    }


    

    protected virtual void AddSpeed()
    {
        if (scoreboard.GetScore() % 5 != 0)
        {
            return;
        }

        growthRate = growthRate + 0.001f;
    }

    protected void ShrinkTop()
    {
        if (scoreboard.GetScore() % 10 == 0 && fillCollider.GetTopSprite().transform.localScale.y > 0.1f)
        {
            SpriteRenderer top = fillCollider.GetTopSprite();
            fillCollider.GetTopSprite().transform.localScale = new Vector3(top.transform.localScale.x, top.transform.localScale.y - 0.01f, 1);
        }
    }

    protected void ShrinkBottom()
    {
        if (scoreboard.GetScore() % 10 == 1 && fillCollider.GetBottomSprite().transform.localScale.y > 0.1f)
        {
            SpriteRenderer bottom = fillCollider.GetBottomSprite();
            fillCollider.GetBottomSprite().transform.localScale = new Vector3(bottom.transform.localScale.x, bottom.transform.localScale.y - 0.01f, 1);
        }
    }


    protected void RandomizeTop()
    {
        SpriteRenderer top = fillCollider.GetTopSprite();
        fillCollider.GetTopSprite().transform.localPosition = new Vector3(top.transform.localPosition.x, Random.Range(0, 0.25f), 1); 

        

    }


    protected void RandomizeBottom()
    {
        SpriteRenderer bottom = fillCollider.GetBottomSprite();
        fillCollider.GetBottomSprite().transform.localPosition = new Vector3(bottom.transform.localPosition.x, Random.Range(-0.5f, -0.25f), 1);

        

    }

    protected void YouLose()
    {
        //Debug.Log(Lives.GetHealth());
        
        string temp = "FullHeart (" + Lives.LoseHealth() + ")";
        GameObject h = GameObject.Find(temp);

        h.SetActive(false);
        
            


        //lives -= 1;
        

        if (Lives.GetHealth() <= 0)
        {
            GameObject [] objs;

            objs = GameObject.FindGameObjectsWithTag("ButtonTag");
            

            foreach(GameObject button in objs)
            {
                button.SetActive(false);
            }

            //Button b = GetComponentInChildren<Button>(); // works
            //b.gameObject.SetActive(false);
            growthRate = 0;


            StartCoroutine(GameOver());

            


            




        }


    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1.2f);
        gameOverScreen.Setup(scoreboard.GetScore());
        
    }

    /*
    public int GetLives()
    {
        return lives;
    }
    */

    public void LoadData(GameData data)
    {
        //load the selected skin(s)
    }

    public void SaveData(ref GameData data)
    {
        data.coins += scoreboard.GetScore();
    }

    

}
