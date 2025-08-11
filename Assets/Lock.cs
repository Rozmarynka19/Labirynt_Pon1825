using UnityEngine;

public class Lock : MonoBehaviour
{
    public bool iCanOpen = false;
    public Door door;
    public Keys myColor;
    bool locked = false;
    Animator key;

    private void Start()
    {
        key = GetComponent<Animator>();
    }

    private void Update()
    {
        if (locked == false && iCanOpen && Input.GetKeyDown(KeyCode.E))
        {
            key.SetBool("useKey", CheckTheKey());
        }
    }

    public void UseKey()
    {
        door.Open();
    }

    public bool CheckTheKey()
    {
        if (locked == false && GameManager.INSTANCE.keys[myColor] > 0)
        {
            Debug.Log($"Masz {GameManager.INSTANCE.keys[myColor]} kluczy {myColor}");
            GameManager.INSTANCE.keys[myColor]--;
            locked = true;
            return true;
        }

        Debug.Log($"Nie masz klucza {myColor} lub brama jest ju¿ otwarta!");
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            iCanOpen = true;
            Debug.Log("You can use the lock");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            iCanOpen = false;
            Debug.Log("You cannot use the lock");
        }
    }
}
