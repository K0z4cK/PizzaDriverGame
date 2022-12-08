using UnityEngine;

[DisallowMultipleComponent]
public class TouchManager : SingletonComponent<TouchManager>
{
    [SerializeField] private Camera cam;
    public bool Raycast<T>(Vector2 touch, out T component) where T : Component
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(touch);
        print("TouchMammager raycast start origin" + ray.origin + " direct " + ray.direction);
        component = null;
        Debug.DrawRay(ray.origin, ray.direction * float.MaxValue, Color.red, 2);
        Physics.Raycast(ray, out hit, Mathf.Infinity);
        print("TouchMammager raycast hit");
        if (hit.collider != null)
        {
            print(hit.collider);
            if (hit.collider.TryGetComponent(out component))
                return true;
        }
        return false;
    }
    // user touch event occurred
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
                GameManager.Instance.onTouchBeganUser((Vector2)Input.mousePosition);
            }
            if (Input.GetMouseButton(0))
            {
                GameManager.Instance.onTouchMovedUser((Vector2)Input.mousePosition);
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