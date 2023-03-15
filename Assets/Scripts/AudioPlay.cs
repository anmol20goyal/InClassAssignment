using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlay : MonoBehaviour
{
    #region GameObjects

    [SerializeField] private AudioSource sound1, sound2;
    [SerializeField] private Rigidbody doorRB;

    #endregion

    #region Variables

    public bool blast;
    [SerializeField] private float thrustForce = 100f;

    #endregion


    private void Start()
    {
        blast = false;
    }

    private IEnumerator CountdownSound()
    {
        sound1.Play();
        yield return new WaitForSeconds(1f);
        sound1.Play();
        yield return new WaitForSeconds(1f);
        sound1.Play();
        yield return new WaitForSeconds(1f);
        sound2.Play();

        this.GetComponent<Rigidbody>().AddForce(new Vector3(1, 1, 0) * thrustForce, ForceMode.Force);
        if (blast)
        {
            doorRB.AddForce(new Vector3(1, 1, 0) * thrustForce, ForceMode.Force);
            this.gameObject.SetActive(false);
        }
        yield return null;
    }

    public void StartCountdownSound()
    {
        blast = false;
        StartCoroutine(CountdownSound());
    }

    public void BlastCountDown()
    {
        blast = true;
        StartCoroutine(CountdownSound());
    }

    public void PlaySound()
    {
        sound1.Play();
    }
}