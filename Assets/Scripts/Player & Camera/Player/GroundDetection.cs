using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Casts a Ray downward to check for collision.
 * Red Ray means no collision has been detected.
 * Green mean there is collision.
 */
public class GroundDetection : MonoBehaviour
{
    public float rayLength;
    public LayerMask layerMask;
    public float originYOffset;

    public bool IsGrounded(Collider col)
    {
        var origin = col.bounds.center;
        origin.y -= col.bounds.extents.y - originYOffset;

        if (Physics.Raycast(origin, Vector3.down, rayLength, layerMask))
            Debug.DrawRay(origin, Vector3.down * rayLength, Color.green);
        else
            Debug.DrawRay(origin, Vector3.down * rayLength, Color.red);

        return Physics.Raycast(origin, Vector3.down, rayLength, layerMask);
    }
}
