using UnityEngine;
using UnityEngine.UI;

public class PickupPanel : MonoBehaviour
{
    public static PickupPanel INSTANCE;

    [SerializeField] Text timeText;
    [SerializeField] Text pointsText;
    [SerializeField] Text redKeyText;
    [SerializeField] Text goldKeyText;
    [SerializeField] Text greenKeyText;

    [SerializeField] Image snowflakeImage;

    private void Awake()
    {
        if (INSTANCE == null)
            INSTANCE = this;
        else
            Destroy(this);
    }

    public void UpdateTime(int timeToSet)
    {
        timeText.text = timeToSet.ToString();
    }

    public void UpdatePoints(int pointsToSet)
    {
        pointsText.text = pointsToSet.ToString();
    }

    public void UpdateKeys(Keys keyType, int keyAmountToSet)
    {
        switch (keyType)
        {
            case Keys.RED:
                redKeyText.text = keyAmountToSet.ToString();
                break;
            case Keys.GREEN:
                greenKeyText.text = keyAmountToSet.ToString();
                break;
            case Keys.GOLD:
                goldKeyText.text = keyAmountToSet.ToString();
                break;
        }
        
    }

    public void SetSnowflake(bool shouldBeShown)
    {
        snowflakeImage.enabled = shouldBeShown;
    }
}
