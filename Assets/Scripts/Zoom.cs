using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    Camera mainCamera;

    float zoomModifierSpeed = -0.2f;

    public SpriteRenderer fillSprite;

    public ClassicMode classicMode;

    
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        
        
    }

    private void Awake()
    {
        
    }

    void Update()
    {
        
        if (classicMode.GetLives() < 0)
        {
            mainCamera.orthographicSize += zoomModifierSpeed;

            Vector3 targetPosition = new Vector3(fillSprite.transform.position.x, fillSprite.GetComponent<BoxCollider2D>().bounds.center.y, mainCamera.transform.position.z);
            Vector3 velocity = Vector3.zero;
            float targetTime = 0.3f;

            //mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, targetPosition, ref velocity, targetTime);
            mainCamera.transform.position = Vector3.MoveTowards(new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z), new Vector3(fillSprite.transform.position.x, fillSprite.GetComponent<BoxCollider2D>().bounds.center.y, mainCamera.transform.position.z), targetTime);

            

            mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, 2f, 10f);
            
            //the zoom sometimes finishes faster than the y axis movement
            //ideally we want them to finish at the same time
            
        }



        
    }


}
