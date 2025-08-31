using UnityEngine;

public class TimeFreezer : Pickup
{
    [SerializeField] int freezeTime = 10;
    public override void Picked()
    {
        GameManager.INSTANCE.FreezeTime(freezeTime);
        GameManager.INSTANCE.PlayClip(GameManager.INSTANCE.pickedClip);
        Destroy(this.gameObject);
    }
}
