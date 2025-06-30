using UnityEngine;

public class Clock : Pickup
{
    [SerializeField] bool isAddingTime = false;
    [SerializeField] uint time = 5;

    public override void Picked()
    {
        int sign = isAddingTime ? 1 : -1;
        GameManager.INSTANCE.AddTime(sign * (int)time);
        Destroy(this.gameObject);
    }
}
