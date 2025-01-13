using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInputs : MonoBehaviour
{
    public static MobileInputs Instance { set; get; }
    private const float DEADZONE = 100.0f;
    public bool tap, swipeL, swipeR, swipeU, swipeD;
    private Vector2 swipeDelta, startTouch;
    public bool cheat;
    public bool Tap { get { return tap; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeL; } }
    public bool SwipeRight { get { return swipeR; } }
    public bool SwipeUp { get { return swipeU; } }
    public bool SwipeDown { get { return swipeD; } }
    public bool Cheat { get { return cheat; } }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        tap = swipeL = swipeR = swipeU = swipeD = false;

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Alouuuu");
            tap = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startTouch = swipeDelta = Vector2.zero;
        }
        #endregion

        #region Mobile Inputs
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                startTouch = Input.mousePosition;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                startTouch = swipeDelta = Vector2.zero;
            }

            if (Input.touchCount == 5)
            {
                cheat = true;
            }
        }

        #endregion

        swipeDelta = Vector2.zero;
        if (startTouch != Vector2.zero)
        {
            if (Input.touches.Length != 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        if (swipeDelta.magnitude > DEADZONE)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                    swipeL = true;
                else
                    swipeR = true;
            }
            else
            {
                if (y > 0)
                    swipeU = true;
                else
                    swipeD = true;

            }

            startTouch = swipeDelta = Vector2.zero;
        }
    }
}
