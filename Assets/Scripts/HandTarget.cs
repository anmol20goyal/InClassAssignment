using UnityEngine;
using UnityEngine.Events;

public class HandTarget : MonoBehaviour
{
    public bool isGrabbable;

    [SerializeField] private UnityEvent startProximity;
    [SerializeField] private UnityEvent stopProximity;
    [SerializeField] private UnityEvent startGrab;
    [SerializeField] private UnityEvent stopGrab;

    public void OnStartProximity()
    {
        startProximity.Invoke();
    }

    public void OnStopProximity()
    {
        stopProximity.Invoke();
    }

    public void OnStartGrab()
    {
        startGrab.Invoke();
    }

    public void OnStopGrab()
    {
        stopGrab.Invoke();
    }
}
