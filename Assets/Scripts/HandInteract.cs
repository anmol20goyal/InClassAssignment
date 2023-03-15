using UnityEngine;

public class HandInteract : MonoBehaviour
{
    #region GameObjects

    public MeshRenderer handModel;
    private HandTarget currentGrabbed;
    private HandTarget currentGrabbable;

    #endregion

    #region Variables

    //[SerializeField] private bool isGrabbed = false;

    #endregion


    private void OnTriggerEnter(Collider other)
    {
        HandTarget currentTarget = other.GetComponent<HandTarget>();

        if (currentTarget != null)
        {
            currentTarget.OnStartProximity();

            if (currentTarget.isGrabbable)
            {
                currentGrabbable = currentTarget;
            }
        }
        else
        { 
            Debug.Log("Collided object: " + other.gameObject.name); 
        }

    }

    private void OnTriggerExit(Collider other)
    {
        HandTarget currentTarget = other.GetComponent<HandTarget>();

        if (currentTarget != null)
        {
            currentTarget.OnStopProximity();
            currentGrabbable = null;
        }
    }

    private void LateUpdate()
    {
        if (currentGrabbable != null && currentGrabbed == null && Input.GetKeyDown(KeyCode.E))
        {
            currentGrabbable.OnStartGrab();
            currentGrabbed = currentGrabbable;

            Rigidbody rb = currentGrabbed.GetComponent<Rigidbody>();
            if (rb != null) rb.isKinematic = true;

            handModel.enabled = false;
        }
        else if (currentGrabbable != null && Input.GetKeyDown(KeyCode.E))
        {
            //isGrabbed = false;
            currentGrabbed.OnStopGrab();

            Rigidbody rb = currentGrabbed.GetComponent<Rigidbody>();
            if (rb != null) rb.isKinematic = false;

            currentGrabbed = null;
            handModel.enabled = true;
        }

        if (currentGrabbable != null && currentGrabbed != null)
        {
            currentGrabbed.transform.SetPositionAndRotation(transform.position, transform.rotation);
        }
    }

}
