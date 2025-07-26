using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float speed = 3f;  
    private Transform target;

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * speed);
        }
    }

    public void MoveToTarget(Transform newTarget)
    {
        target = newTarget;
    }
}

