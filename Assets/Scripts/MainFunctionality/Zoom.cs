using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
    Camera mainCamera;
    float zoomModifierSpeed;
    public SpriteRenderer fillSprite;
    public static SpriteRenderer targetZoom;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        zoomModifierSpeed = -0.2f;
        targetZoom = fillSprite;
    }

    void Update()
    {
        if (Lives.GetHealth() <= 0)
        {
            Vector3 targetPosition = new Vector3(targetZoom.transform.position.x, targetZoom.GetComponent<BoxCollider2D>().bounds.center.y, mainCamera.transform.position.z);
            mainCamera.orthographicSize += zoomModifierSpeed;

            Vector3 velocity = Vector3.zero;
            float targetTime = 0.3f;

            mainCamera.transform.position = Vector3.MoveTowards(new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z), targetPosition, targetTime);
            mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, 2f, 10f); 
        }
    }
}
