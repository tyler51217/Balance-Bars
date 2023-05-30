using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 panelLocation; //idle state of panel //gets from bottom left
    public float percentThreshold = 0.2f;
    public float easing = 0.5f; //how long in seconds we want our panel to ease into its location

    public RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        panelLocation = transform.position;
        
        rt = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData data)
    {
        transform.position += new Vector3(data.delta.x, 0, 0);



    }

    public void OnEndDrag(PointerEventData data)
    {
        
        if (transform.position.x > panelLocation.x)
        {
            //SmoothMove(transform.position, panelLocation, easing);
            transform.position = panelLocation;

        }
        if(transform.position.x < (panelLocation.x * -1) + Screen.width)
        {
            transform.position = new Vector3((panelLocation.x * -1) + Screen.width, panelLocation.y, panelLocation.z);
        }


    }

    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;

        while (t <= 1)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null; //waits for the next frame before continuing
        }

    }



}
