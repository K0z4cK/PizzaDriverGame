using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Canvas _joyStickCanvas;
    [SerializeField]
    private Text _panelText;
    [SerializeField]
    private Button _restartBtn;
    [SerializeField]
    private Transform _panel;

    private bool _isWin;
    private void Awake()
    {
        EventManager.Instance.gameWined += () => _isWin = true;
        EventManager.Instance.gameLosed += () => _isWin = false;
        EventManager.Instance.gameWined += SetText;
        EventManager.Instance.gameLosed += SetText;

        _restartBtn.onClick.AddListener(RestartBtnClick);
    }

    private void SetText()
    {
        _joyStickCanvas.gameObject.SetActive(false);
        _panel.gameObject.SetActive(true);
        Time.timeScale = 0;
        if (_isWin)
            _panelText.text = "PIZAA DELIVERED";
        else
            _panelText.text = "YOU LOSE";
    }

    private void RestartBtnClick()
    {
        Time.timeScale = 1;
        Application.LoadLevel("Game");
    }

}
