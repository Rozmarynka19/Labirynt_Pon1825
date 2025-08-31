using UnityEngine;
using UnityEngine.UI;

public class GameStatusPanel : MonoBehaviour
{
    public static GameStatusPanel INSTANCE;

    [SerializeField] Text statusText;
    [SerializeField] Text subStatusText;

    private void Awake()
    {
        if (INSTANCE == null)
            INSTANCE = this;
        else
            Destroy(this);
    }

    public void ShowGamePaused()
    {
        statusText.text = "GAME PAUSED";
        subStatusText.text = "";
        gameObject.SetActive(true);
    }

    public void ShowWin()
    {
        statusText.text = "YOU WIN!";
        subStatusText.text = "Reload? Y/N";
        gameObject.SetActive(true);
    }

    public void ShowLose()
    {
        statusText.text = "YOU LOSE!";
        subStatusText.text = "Reload? Y/N";
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
