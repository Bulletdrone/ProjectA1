using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeableUI : MonoBehaviour
{
    private Vector3 first;
    private Vector3 last;
    private Vector3 swipe;
    private Vector3 camStartPoint;

    public float speed;
    private float nearestPlane;
    float distance;

    private GameObject mainCam;
    private Transform[] planes;

    void Start()
    {
        planes = GameObject.Find("Planes").GetComponentsInChildren<Transform>();
        distance = Screen.height * 15 / 100;

        mainCam = Camera.main.gameObject;
        camStartPoint = mainCam.transform.position;
    }

    void Update()
    {
        SwipeOnPC();
        SwipeOnMobile();
    }

    void SwipeOnPC()
    {
        if (!Input.GetMouseButtonDown(0) && !Input.GetMouseButton(0))
        {
            foreach (Transform p in planes)
            {
                nearestPlane = (p.position - mainCam.transform.position).x;

                if (Mathf.Abs(nearestPlane) < 5)
                {
                    Vector3 newposition = new Vector3(p.position.x, mainCam.transform.position.y, mainCam.transform.position.z);
                    mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, newposition, .05f);
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            first = Input.mousePosition;
        }
        if (Input.GetMouseButton(0) || Input.GetMouseButtonUp(0))
        {
            last = Input.mousePosition;
            swipe = new Vector3(last.x - first.x, 0, 0);
        }

        //if (swipe.x >distance || swipe.x < -distance)
        {
            mainCam.transform.Translate(-swipe * speed * Time.deltaTime);
            swipe = new Vector3(0, 0, 0);
            first = last;
        }
    }

    void SwipeOnMobile()
    {
        //if (Input.touchCount == 0)
        //{
        //    foreach (Transform p in planes)
        //    {
        //        nearestPlane = (p.position - mainCam.transform.position).x;

        //        if (Mathf.Abs(nearestPlane) < 5)
        //        {
        //            Vector3 newposition = new Vector3(p.position.x, mainCam.transform.position.y, mainCam.transform.position.z);
        //            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, newposition, .05f);
        //        }
        //    }
        //}

        if (Input.touchCount == 1)
        {
            Touch touch1 = Input.GetTouch(0);
            if (touch1.phase == TouchPhase.Began)
            {
                first = touch1.position;
            }

            if (touch1.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Ended)
            {
                last = touch1.position;
                swipe = new Vector3(last.x - first.x, 0, 0);
            }
        }

        //if (swipe.x > distance || swipe.x < -distance)
        {
            mainCam.transform.Translate(-swipe * speed * Time.deltaTime);
            swipe = new Vector3(0, 0, 0);
            first = last;
        }
    }
}
