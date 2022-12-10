using UnityEngine;

[DisallowMultipleComponent]
public class GameManager : SingletonComponent<GameManager>
{

    public delegate void TouchBegan(Vector3 position);
    public event TouchBegan TouchBeganUser;

    public delegate void TouchMoved(Vector3 position);
    public event TouchMoved TouchMovedUser;

    public delegate void TouchEnded();
    public event TouchEnded TouchEndedUser;

    public void onTouchBeganUser(Vector3 position)
    {
        //Debug.Log("Touch begin");
        TouchBeganUser?.Invoke(position);
    }
    public void onTouchMovedUser(Vector3 position)
    {
        //Debug.Log("Touch Move");
        TouchMovedUser?.Invoke(position);
    }
    public void onTouchEndedUser()
    {
        //Debug.Log("Touch End");
        TouchEndedUser?.Invoke();
    }
}