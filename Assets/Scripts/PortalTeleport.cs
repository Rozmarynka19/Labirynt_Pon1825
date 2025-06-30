using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{

    public Transform player;
    public Transform receiver;
    
    private bool playerIsOverlapping = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }

    private void FixedUpdate()
    {
        Teleportation();
    }

    private void Teleportation()
    {
        if (playerIsOverlapping == false) return;

        Vector3 portalToPlayer = player.position - transform.position;
        float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

        if (dotProduct > 0)
        {
            float rotationDiff =
                Quaternion.Angle(transform.rotation, receiver.rotation);
            rotationDiff += 180f;
            player.Rotate(Vector3.up, rotationDiff);


        }
    }
}
