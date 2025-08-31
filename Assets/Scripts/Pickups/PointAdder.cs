using UnityEngine;

public class PointAdder : Pickup
{
    [SerializeField] int points = 5;
    public override void Picked()
    {
        GameManager.INSTANCE.AddPoints(points);
        GameManager.INSTANCE.PlayClip(GameManager.INSTANCE.pickedClip);
        Destroy(this.gameObject);
    }
}
