using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    void Update()
    {
        PortalCameraController();
    }

    private void PortalCameraController()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        float portalRotDiff = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion portalRotDiffQuat = Quaternion.AngleAxis(portalRotDiff, Vector3.up);
        Vector3 newCameraDirection = portalRotDiffQuat * playerCamera.forward;
        newCameraDirection = new Vector3(
            newCameraDirection.x * -1,
            newCameraDirection.y,
            newCameraDirection.z * -1
            );
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
