using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public UnityEvent<int> onCoinsValue { get; private set; } = new UnityEvent<int>();
    public UnityEvent<int> onTimerValue { get; private set; } = new UnityEvent<int>();

    public UnityEvent<bool> onGameOver { get; private set; } = new UnityEvent<bool>();

    public bool gameIsOver { get; private set; } = false;

    [SerializeField]
    private GameObject MenuPanel;
    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private int startTimer = 15;
    [SerializeField]
    private int coinsToWin = 10;
    [SerializeField]
    private int _addTime = 5;

    private int _timer;
    private int _coins;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        SetActiveGameOverPanel(false);

        _timer = startTimer;
        _coins = 0;

        UpdateCoins();
        InvokeRepeating(nameof(UpdateTimer), 1, 1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddCoins()
    {
        _coins++;
        _timer = Mathf.Min(startTimer, _timer + _addTime);
        UpdateCoins();
    }


    private void UpdateTimer()
    {
        _timer--;

        if (_timer <= 0)
        {
            SetActiveGameOverPanel(true);
            onGameOver?.Invoke(false);
            DeInit();
            return;
        }

        int res = Mathf.Min(startTimer, _timer);
        onTimerValue?.Invoke(res);
    }

    private void UpdateCoins()
    {
        onTimerValue?.Invoke(_timer);
        onCoinsValue?.Invoke(_coins);

        if (_coins >= coinsToWin)
        {
            SetActiveGameOverPanel(true);
            onGameOver?.Invoke(true);
            DeInit();
        }
    }

    private void SetActiveGameOverPanel(bool value)
    {
        MenuPanel.SetActive(!value);
        gameOverPanel.SetActive(value);
        gameIsOver = value;
    }

    private void DeInit()
    {
        CancelInvoke();
    }
}
