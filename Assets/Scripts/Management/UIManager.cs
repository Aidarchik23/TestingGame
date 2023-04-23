using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timerTxt;
    [SerializeField]
    private TextMeshProUGUI _coinsTxt;
    [SerializeField]
    private TextMeshProUGUI _gameOverTxt;

    [SerializeField]
    private Button _retryBtn;
    
    private void Start()
    {
        GameManager.Instance.onTimerValue.AddListener(UpdateTimer);
        GameManager.Instance.onCoinsValue.AddListener(UpdateCoins);
        GameManager.Instance.onGameOver.AddListener(UpdateGameOverPanel);
        _retryBtn.onClick.AddListener(GameManager.Instance.RestartGame);
    }

    private void UpdateTimer(int time)
    {
        _timerTxt.text = time.ToString();
    }

    private void UpdateCoins(int coins)
    {
        _coinsTxt.text = coins.ToString();
    }

    private void UpdateGameOverPanel(bool win)
    {
        _gameOverTxt.text = win ? "Win" : "Lose";
    }
}
