using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyStick : MonoBehaviour
{
    [SerializeField]
    private Transform _innerCircle;
    [SerializeField]
    private Transform _outerCircle;

    private Vector3 _touchPos, _movePos;

    private bool _isTouched;

    private void Awake()
    {
        GameManager.Instance.TouchBeganUser += (pos) => ScreenTouch(pos);
        GameManager.Instance.TouchMovedUser += (pos) => TouchMoved(pos);
        GameManager.Instance.TouchEndedUser += EndTouch;       
    }
    private void Update()
    {
        if (!_isTouched)
            return;
        Vector2 offset = _movePos - _touchPos;
        Vector2 direction = Vector2.ClampMagnitude(offset, 200f);
        _innerCircle.transform.position = new Vector2(_touchPos.x + direction.x, _touchPos.y + direction.y);
    }
    private void ScreenTouch(Vector3 pos)
    {
        _touchPos = pos;
        _innerCircle.transform.position = _touchPos;
        _outerCircle.transform.position = _touchPos;

        _innerCircle.GetComponent<Image>().enabled = true;
        _outerCircle.GetComponent<Image>().enabled = true;
    }
    private void TouchMoved(Vector3 pos)
    {
        _movePos = pos;
        _isTouched = true;
    }
    private void EndTouch()
    {
        _isTouched = false;
        _innerCircle.GetComponent<Image>().enabled = false;
        _outerCircle.GetComponent<Image>().enabled = false;
    }


}
