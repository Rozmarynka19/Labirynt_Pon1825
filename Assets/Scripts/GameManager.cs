using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    [SerializeField] int timeToEnd;
    bool gamePaused = false;
    bool gameEnded = false;
    bool isWin = false;
    [SerializeField] int points = 0;
    public Dictionary<Keys, int> keys = new Dictionary<Keys, int>();

    private void Start()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (timeToEnd <= 0)
        {
            timeToEnd = 100;
        }

        keys[Keys.RED] = 0;
        keys[Keys.GREEN] = 0;
        keys[Keys.GOLD] = 0;

        InvokeRepeating(nameof(Stopper), 2f, 1f);
    }
    private void Stopper()
    {
        timeToEnd--;
        Debug.Log($"Time: {timeToEnd}s");

        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            gameEnded = true;
        }

        if (gameEnded)
        {
            EndGame();
        }
    }
    private void EndGame()
    {
        CancelInvoke(nameof(Stopper));
        if (isWin)
        {
            Debug.Log("You win!");
        }
        else
        {
            Debug.Log("You lose!");
        }
    }
    private void Update()
    {
        PauseCheck();
        LogKeys();
    }
    private void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
                ResumeGame();
            else
                PauseGame();
        }
    }
    public void PauseGame()
    {
        Debug.Log("Game paused");
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void ResumeGame()
    {
        Debug.Log("Game resumed");
        Time.timeScale = 1f;
        gamePaused = false;
    }
    public void AddPoints(int points)
    {
        this.points += points;
    }
    public void AddTime(int addTime)
    {
        timeToEnd += addTime;
    }
    public void FreezeTime(int freezeTime)
    {
        CancelInvoke(nameof(Stopper));
        InvokeRepeating(nameof(Stopper), freezeTime, 1f);
    }
    public void AddKey(Keys key)
    {
        keys[key]++;
    }
    void LogKeys()
    {
        if (Input.GetKeyDown(KeyCode.L) == false) return;

        foreach(var keyEntry in keys)
        {
            Debug.Log($"{keyEntry.Key} = {keyEntry.Value}");
        }
    }
}
