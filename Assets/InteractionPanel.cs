using UnityEngine;
using UnityEngine.UI;

public class InteractionPanel : MonoBehaviour
{
    public static InteractionPanel INSTANCE;

    [SerializeField] Text interactionText;

    private void Awake()
    {
        if (INSTANCE == null)
            INSTANCE = this;
        else
            Destroy(this);
    }

    public void ShowGateInteraction()
    {
        interactionText.text = "PRESS E TO OPEN THE GATE";
    }

    public void Hide()
    {
        interactionText.text = "";
    }
}
