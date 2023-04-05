using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LightUpHallway : MonoBehaviour
{
    [SerializeField] private UnityEvent[] Events;

    [SerializeField] private float timer = 1f;

    private IEnumerator LightUpHall()
    {
        foreach (var e in Events)
        {
            e.Invoke();
            yield return new WaitForSeconds(timer);
        }
    }

    public void StartLighting()
    {
        StartCoroutine(LightUpHall());
    }

}