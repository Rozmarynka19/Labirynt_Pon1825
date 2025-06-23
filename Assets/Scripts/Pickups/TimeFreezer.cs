using UnityEngine;

public class TimeFreezer : Pickup
{
    [SerializeField] int freezeTime = 10;
    public override void Picked()
    {
        GameManager.INSTANCE.FreezeTime(freezeTime);
        Destroy(this.gameObject);
    }
}
