using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform closePosition, openPosition, door;
    public bool isOpen = false;
    public float speed = 5f;

    void Start()
    {
        door.position = closePosition.position;
    }
    public void Open()
    {
        isOpen = true;
    }
    void Update()
    {
        if (isOpen && Vector3.Distance(door.position, openPosition.position) > 0.001f)
        {
            door.position = Vector3.MoveTowards(door.position,
                openPosition.position,
                speed * Time.deltaTime);
        }
    }
}
