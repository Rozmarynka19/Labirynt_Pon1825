using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 12f;
    CharacterController characterController;
    public Transform groundCheck;
    public LayerMask groundMask;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        CheckTheGround();

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
    }

    private void CheckTheGround()
    {
        RaycastHit hit;
        bool collided = Physics.Raycast(
                            groundCheck.position,
                            transform.TransformDirection(Vector3.down),
                            out hit,
                            0.4f,
                            groundMask);
        if (collided)
        {
            string objTag = hit.collider.gameObject.tag;
            switch(objTag)
            {
                case "Low":
                    speed = 3f;
                    break;
                case "High":
                    speed = 20f;
                    break;
                default:
                    speed = 12f;
                    break;
            }
        }
    }
}
