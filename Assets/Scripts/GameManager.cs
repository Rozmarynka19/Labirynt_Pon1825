using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    [SerializeField] int timeToEnd;
    bool gamePaused = false;

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
        InvokeRepeating(nameof(Stopper), 2f, 1f);
    }
    private void Stopper()
    {
        timeToEnd--;
        Debug.Log($"Time: {timeToEnd}s");
    }
    private void Update()
    {
        PauseCheck();
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
}
