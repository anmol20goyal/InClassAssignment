using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform head;
    public float lookAtDistance = 7;
    public float lookAtSpeed = 3;

    Transform currentCamera;

    Quaternion startRotation;
    Quaternion currentRotation;

    private void Start()
    {
        currentCamera = Camera.main.transform;
        startRotation = head.rotation;
    }

    private void LateUpdate()
    {
        if (lookAtDistance > Vector3.Distance(head.position, currentCamera.position))
        {
            currentRotation = Quaternion.Slerp(currentRotation,
                                               Quaternion.LookRotation(currentCamera.position - head.position),
                                               Time.deltaTime * lookAtSpeed);
        }
        else
        {
            currentRotation = Quaternion.Slerp(currentRotation, head.rotation, Time.deltaTime * lookAtSpeed);
        }

        

        head.rotation = currentRotation;
    }
}
