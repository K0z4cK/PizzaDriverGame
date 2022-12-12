using UnityEngine;

[DisallowMultipleComponent]
public class TouchManager : SingletonComponent<TouchManager>
{
    public void GetTouch()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase.Equals(TouchPhase.Began))
                {
                    GameManager.Instance.onTouchBeganUser(Input.GetTouch(0).position);
                }
                if (touch.phase.Equals(TouchPhase.Moved))
                {
                    GameManager.Instance.onTouchMovedUser(Input.GetTouch(0).position);
                }
                if (touch.phase.Equals(TouchPhase.Ended))
                {
                    GameManager.Instance.onTouchEndedUser();
                }
            }
        }

        // Simulate touch events from mouse events
        if (Input.touchCount == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.onTouchBeganUser(Input.mousePosition);
            }
            if (Input.GetMouseButton(0))
            {
                GameManager.Instance.onTouchMovedUser(Input.mousePosition);
            }
            if (Input.GetMouseButtonUp(0))
            {
                GameManager.Instance.onTouchEndedUser();
            }
        }
    }
    void Update()
    {
        GetTouch();
    }
}