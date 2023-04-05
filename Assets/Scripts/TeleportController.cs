using TMPro;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private TMP_Text teleportTxt;
    [SerializeField] private GameObject[] teleportPads;
    private int telePadCount;

    private void Start()
    {
        telePadCount = 0;
    }

    public void OnTeleport(int targetNum)
    {
        characterController.enabled = false;

        telePadCount = targetNum + 1;
        if (telePadCount >= teleportPads.Length) telePadCount = 0;
        var newPos = teleportPads[telePadCount].transform.position;
        transform.position = new Vector3(newPos.x - 10, newPos.y, newPos.z);
        teleportTxt.gameObject.SetActive(false);
        
        characterController.enabled = true;
    }

    public void OnTeleport(Vector3 targetPos)
    {
        characterController.enabled = false;
        transform.position = targetPos;
        characterController.enabled = true;
    }
}
