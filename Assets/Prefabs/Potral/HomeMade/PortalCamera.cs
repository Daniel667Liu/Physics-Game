using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerFromPotralOffset = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerFromPotralOffset;

        float angularDiffBetweenPortalRotation = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotationDiff = Quaternion.AngleAxis(angularDiffBetweenPortalRotation, Vector3.up);
        Vector3 newCameraDirection = portalRotationDiff * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
