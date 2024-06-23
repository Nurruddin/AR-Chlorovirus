using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Swipe : MonoBehaviour
{


    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    public GameObject infoPanel;
    public GameObject videoPanel;



    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            Vector2 inputVector = endTouchPosition - startTouchPosition;
            if(Mathf.Abs(inputVector.x) > Mathf.Abs(inputVector.y))
            {
                if(inputVector.x > 0)
                {
                    RightSwipe();
                }
                else
                {
                    LeftSwipe();
                }
            }
            else
            {
                if (inputVector.y > 0)
                {
                    UpSwipe();
                }
                else
                {
                    DownSwipe();
                }
            }
        }

    }

    private void UpSwipe()
    {
        print("up");
    }
    private void DownSwipe()
    {
        print("down");
    }
    private void LeftSwipe()
    {
        if (infoPanel.activeSelf)
        {
            infoPanel.SetActive(false);
            videoPanel.SetActive(true);
        }
        Debug.Log("left");
    }
    private void RightSwipe()
    {
        if (videoPanel.activeSelf)
        {
            infoPanel.SetActive(true);
            videoPanel.SetActive(false);
        }
        print("right");
    }

}