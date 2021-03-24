using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Vector3 camOffset;
    public Transform target;
    public float lerpSpeed = 5f;

    private void Awake()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 calculatedPosition = target.position + camOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, calculatedPosition, lerpSpeed);
            transform.position = smoothedPosition;
        }
    }
}
