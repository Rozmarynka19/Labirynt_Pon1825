using UnityEngine;

public class Key : Pickup
{
    [SerializeField] Keys keyColor;

    public override void Picked()
    {
        GameManager.INSTANCE.AddKey(keyColor);
        GameManager.INSTANCE.PlayClip(GameManager.INSTANCE.pickedClip);
        Destroy(this.gameObject);
    }
}
