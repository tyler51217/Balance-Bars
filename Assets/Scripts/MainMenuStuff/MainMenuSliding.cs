using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSliding : MonoBehaviour
{
    public List<GameObject> panels;
    private int currentPanel = 0;
    float targetTime = 0.1f;

    Vector3 fastTarget = new Vector3(10f, 1.5f);
    Vector3 velocity = Vector3.zero;
    Vector3 targetPosition = new Vector3(Screen.width, 0, 0);

    public void ForwardButton()
    {
        for (int i = 0; i < panels.Count; i++)
        {
            StartCoroutine(SmoothMove(panels[i].transform.position, new Vector3 (panels[i].transform.position.x - targetPosition.x, panels[i].transform.position.y, panels[i].transform.position.z), targetTime));
        }
        currentPanel++;
    }

    public void BackwardButton()
    {
        for (int i = 0; i < panels.Count; i++)
        {
            
            StartCoroutine(SmoothMove(panels[i].transform.position, new Vector3(panels[i].transform.position.x + Screen.width, panels[i].transform.position.y, panels[i].transform.position.z), targetTime));
        }
        currentPanel--;
    }

    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;

        while(t <= 1)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }
}
