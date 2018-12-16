using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{

    bool dragging = false;
    float distance;
    Vector3 offset;
    Vector3 screenSpace;
    Vector3 curPosition;
    float scaleX = 5.3f * EventHandler.scale, scaleY = 5.3f * EventHandler.scale;
    float deltaX, deltaY, coef = 3 * EventHandler.scale;
    int stepsX, stepsY;
    string[] prevName;
    // Use this for initialization
    void Start()
    {
        prevName = name.Split('_');
        stepsX = Int32.Parse(prevName[1])%10;
        if (prevName[1][1] == null)
        {
            stepsY = 0;
        }
        else
        {
            stepsY = Int32.Parse(prevName[1])/10;
        }
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
    void OnMouseDown()
    {

    }
    /*void OnMouseDrag()
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Moved)
        {
            deltaX += touch.deltaPosition.x;
            deltaY += touch.deltaPosition.y;

            Transform cam = GameObject.Find("ARCamera").GetComponent<Transform>();
            if (cam.eulerAngles.y >= 45 && cam.eulerAngles.y < 135)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + scaleX);
            }
            else if (cam.eulerAngles.y >= 135 && cam.eulerAngles.y < 225)
            {

            }else

            if (deltaX > coef && stepsX%10 + 1 <= 9)
            {
                //transform.position = new Vector3(transform.position.x + scaleX, transform.position.y, transform.position.z);
                stepsX++;
                name = "Ship" + "_" + ((stepsY > 0) ? stepsY.ToString() : "") + stepsX % 10 + "_" + prevName[2];

                deltaX = 0;
            }else if (deltaX < -coef && stepsX%10-1>-1)
            {
                transform.position = new Vector3(transform.position.x - scaleX, transform.position.y, transform.position.z);
                stepsX--;
                name = "Ship" + "_" + ((stepsY > 0) ? stepsY.ToString() : "") + stepsX % 10 + "_" + prevName[2];
                deltaX = 0;
            }

            if (deltaY > coef && (stepsY + 1 <= 9))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + scaleY);
                stepsY++;
                if (prevName[1].Length > 1)
                {
                    prevName[1] = (stepsY * 10 + Int32.Parse(prevName[1][1].ToString())).ToString();
                }
                name = "Ship" + "_" + ((stepsY > 0) ? stepsY.ToString() : "") + stepsX % 10 + "_" + prevName[2];

                deltaY = 0;
            }else if (deltaY < -coef && (stepsY - 1 > -1))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - scaleY);
                stepsY--;
                if (prevName[1].Length>1)
                {
                    prevName[1] = (stepsY * 10 - Int32.Parse(prevName[1][1].ToString())).ToString();
                }
                if (stepsY == 0)
                {
                    prevName[1] = stepsX.ToString();
                }
                name = "Ship" + "_" + ((stepsY > 0) ? stepsY.ToString() : "") + stepsX % 10 + "_" + prevName[2];

                deltaY = 0;
            }
        }
    }*/
    void OnMouseUp()
    {

    }
    // Update is called once per frame
    void Update()
    {
    }
}
