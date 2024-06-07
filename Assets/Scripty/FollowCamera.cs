using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public float zPosition = -10f;

    void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, zPosition);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
