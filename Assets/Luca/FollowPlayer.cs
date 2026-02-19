using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    public Transform target;      // Assign the object to follow in the inspector
    private Vector3 offset = new Vector3(0f, 0.8f, 0f);        // Optional: offset from the target's position

    void LateUpdate()
    {
        if (target != null)
        {
            // Copy the target's position plus offset, but do not change rotation
            transform.position = target.position + offset;
        }
    }
}
