using UnityEngine;

public class LookAtRayCast : MonoBehaviour
{
    [SerializeField] private float rayDistance = 10f;
    private RaycastHit rayHitInfo;
    [SerializeField] private bool castHit;
    public TeleportTarget teleporter;
    private LookAtTarget lastLookAt, current;

    private void CheckRay()
    {
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        castHit = Physics.Raycast(ray, out rayHitInfo, rayDistance);
        
        if (castHit)
        {
            Debug.DrawRay(ray.origin, ray.direction.normalized * rayDistance, Color.red);
            current = rayHitInfo.collider.gameObject.GetComponent<LookAtTarget>();

            if (current == null && lastLookAt != null)
            {
                lastLookAt.onStopLookAt();
                return;
            }

            if (lastLookAt != current && lastLookAt != null)
            {
                lastLookAt.onStopLookAt();
            }
            
            if (current != null)
            {
                current.onStartLookAt();
                lastLookAt = current;
            }
            else
            {
                lastLookAt = current;
            }
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction.normalized * rayDistance, Color.green);

            if (lastLookAt != null)
            {
                lastLookAt.onStopLookAt();
                lastLookAt = null;
            }
        }
    }

    private void Update()
    {
        CheckRay();

        if (current == lastLookAt && lastLookAt != null && Input.GetMouseButtonDown(0))
        {
            lastLookAt.onClicked();
        }
    }
}