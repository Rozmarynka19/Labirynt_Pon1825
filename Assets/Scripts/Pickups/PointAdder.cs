using UnityEngine;

public class PointAdder : Pickup
{
    [SerializeField] int points = 5;
    public override void Picked()
    {
        GameManager.INSTANCE.AddPoints(points);
        Destroy(this.gameObject);
    }
}
