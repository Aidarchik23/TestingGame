using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private TextMeshProUGUI pointText;
    [SerializeField]
    private TextMeshProUGUI gameOverText;

    [SerializeField]
    private Button retryButton;
    
    private void Start()
    {
        GameManager.Instance.onTimerValue.AddListener(SetTimeText);
        GameManager.Instance.onCoinsValue.AddListener(SetPointsText);
        GameManager.Instance.onGameOver.AddListener(UpdateGameOverPanel);
        retryButton.onClick.AddListener(GameManager.Instance.RestartGame);
    }

    private void SetTimeText(int time)
    {
        timerText.text = time.ToString();
    }

    private void SetPointsText(int coins)
    {
        pointText.text = coins.ToString();
    }

    private void UpdateGameOverPanel(bool win)
    {
        if (win == true)
        {
            gameOverText.text = "Win";
        }
        else
        {
            gameOverText.text = "Lose";
        }
    }
}
