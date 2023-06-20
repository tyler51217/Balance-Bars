using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 panelLocation;
    public float percentThreshold = 0.2f;
    public float easing = 0.5f;

    public RectTransform rt;
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
            transform.position = panelLocation;
        }
        if(transform.position.x < (panelLocation.x * -1) + Screen.width)
        {
            transform.position = new Vector3((panelLocation.x * -1) + Screen.width, panelLocation.y, panelLocation.z);
        }
    }
}
