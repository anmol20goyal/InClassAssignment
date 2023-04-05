using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlameAnimation : MonoBehaviour
{
    [SerializeField] private int lightMode;
    [SerializeField] private AnimationClip[] lightAnimClips;
    [SerializeField] private Animation lightAnims;
    [SerializeField] private ParticleSystem flameParticles;
    [SerializeField] private Light flameLight;
    [SerializeField] private AudioSource audio;

    private void Awake()
    {
        flameParticles = transform.GetChild(0).GetComponent<ParticleSystem>();
        flameLight = transform.GetChild(1).GetComponent<Light>();
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (flameParticles != null && flameLight != null) 
        {
            flameParticles.Stop();
            flameLight.enabled = false;
            audio.Stop();
        }
    }

    public void StartFlame()
    {
        if (flameParticles != null && flameLight != null)
        {
            flameParticles.Play();
            flameLight.enabled = true;
            audio.Play();
        }
    }

    private void Update()
    {
        if (flameLight.isActiveAndEnabled && lightMode == 0)
        {
            StartCoroutine(AnimateLight());
        }
    }

    private IEnumerator AnimateLight()
    {
        lightMode = Random.Range(1, 4);
        switch (lightMode)
        {
            case 1:
                lightAnims.Play("FlameAnim1");
                break;
            case 2:
                lightAnims.Play("FlameAnim2");
                break;
            case 3:
                lightAnims.Play("FlameAnim3");
                break;
        }

        yield return new WaitForSeconds(1f);
        lightMode = 0;
    }
}
