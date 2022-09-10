using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    

    private void Update()
    {
        if (this)
        {
            //gameObject.transform.position = Vector3.MoveTowards(new Vector3(0, gameObject.transform.position.y, 0), new Vector3(0, Camera.main.transform.position.y, 0), 0.2f);

            Vector3 fastTarget = new Vector3(10f, 1.5f);
            float targetTime = 0.1f;
            Vector3 velocity = Vector3.zero;
            Vector3 targetPosition = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, gameObject.transform.position.z); 
            gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPosition, ref velocity, targetTime);
            
        }
        
    }

    public void Setup(int score)
    {
        
        gameObject.SetActive(true);
        

        //gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));//this doesnt work as intended
        //i want to put the top of this to the bottom of the main camera


        


        pointsText.text = score.ToString() + " Points";

        
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game1"); //change this to current scene
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    


}
