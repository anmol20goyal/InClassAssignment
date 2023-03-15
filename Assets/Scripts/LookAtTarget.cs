using UnityEngine;
using UnityEngine.Events;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] private UnityEvent startLookAt, stopLookAt, clicked;

    public void onStartLookAt()
    {
        startLookAt.Invoke();
    }

    public void onStopLookAt()
    {
        stopLookAt.Invoke();
    }

    public void onClicked()
    {
        Debug.Log("clicked");
        clicked.Invoke();
    }
}
