using UnityEngine;

public class TeleportTarget : MonoBehaviour
{
    private TeleportController teleportController;
    public int telePadNum;
    [SerializeField] private float vertOffset;
    
    private void Start()
    {
        teleportController = FindObjectOfType<TeleportController>();
    }

    public void Teleport()
    {
        teleportController.OnTeleport(transform.position + Vector3.up * vertOffset);
    }
}
