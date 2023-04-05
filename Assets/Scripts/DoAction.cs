using System.Collections;
using UnityEngine;

public class DoAction : MonoBehaviour
{
    #region GameObjects

    [SerializeField] private GameObject priceTag;

    [SerializeField] private MeshRenderer meshRenderer;

    [Header("GO emitting Particles")]
    [SerializeField] private ParticleSystem particles;
    
    [Tooltip("The object that has to be blown up when button is pressed")] 
    [SerializeField] private GameObject blowUpGO;

    [Tooltip("Chest GO in 4th Minor Assign")]
    [SerializeField] private Animation chestAnim;

    #endregion

    #region Materials

    [Header("Highlight the GO")]
    [SerializeField] private Material glowMat;
    private Material originalMat;

    #endregion

    #region Variables

    private bool isPressed;
    [SerializeField] private bool isOpen, isWorking;
    [SerializeField] private float zRotOpen, zRotClose;
    
    #endregion
    
    private void Start()
    {
        isPressed = false;
        if (meshRenderer != null)
        {
            originalMat = meshRenderer.sharedMaterial;
        }
    }

    #region Highlight Methods
    
    public void StartHighlight()
    {
        if (meshRenderer == null)
        {
            Debug.LogError("highlighted object is missing mesh renderer.");
            return;
        }
        meshRenderer.sharedMaterial = glowMat;
    }

    public void StopHighlight()
    {
        if (meshRenderer == null)
        {
            Debug.LogError("highlighted object is missing mesh renderer.");
            return;
        }
        meshRenderer.sharedMaterial = originalMat;
    }

    #endregion

    #region Particle System Methods

    public void StartParticles()
    {
        if (particles != null)
        {
            particles.gameObject.SetActive(true);
            particles.Play();
        }
        else
        {
            Debug.LogError("game object is missing particle system.");
        }
    }

    public void StopParticles()
    {
        if (particles != null)
        {
            particles.Stop();
        }
        else
        {
            Debug.LogError("game object is missing particle system.");
        }
    }
    
    #endregion

    #region onClicked Methods

    public void BlowUp()
    {
        if (!isPressed)
        {
            isPressed = true;
            StartCoroutine(PressPanicBtn());
            blowUpGO.GetComponent<AudioSource>().Play();
            blowUpGO.GetComponent<Rigidbody>().AddForce(-Time.deltaTime * 300 * new Vector3(0, 1, 1), ForceMode.Impulse);
        }
    }

    private IEnumerator PressPanicBtn()
    {
        var t = 0f;
        var originalPos = transform.localPosition;
        var pressTime = 1f;
        while (t < pressTime)
        {
            t += Time.deltaTime;
            var yPos = Mathf.Lerp(originalPos.x, -0.25f, t / pressTime) % 360;
            transform.localPosition = new Vector3(originalPos.x, yPos, originalPos.z);
            yield return null;
        }
    }

    public void OpenCloseRailwayCrossing()
    {
        if (!isOpen && !isWorking)
        {
            StartCoroutine(OpenCrossing());
        }
        else if (isOpen && !isWorking)
        {
            StartCoroutine(CloseCrossing());
        }
    }

    public void ChestActions()
    {
        chestAnim.Play("ChestOpen");
    }

    private IEnumerator OpenCrossing()
    {
        var t = 0f;
        isWorking = true;
        var openTime = 2f;
        while (t < openTime)
        {
            t += Time.deltaTime;
            var zRot = Mathf.Lerp(zRotClose, zRotOpen, t / openTime) % 360;
            transform.localEulerAngles = new Vector3(0, 0, zRot);
            yield return null;
        }

        isWorking = false;
        isOpen = true;
    }
    
    private IEnumerator CloseCrossing()
    {
        var t = 0f;
        isWorking = true;
        var openTime = 2f;
        while (t < openTime)
        {
            t += Time.deltaTime;
            var zRot = Mathf.Lerp(zRotOpen, zRotClose, t / openTime) % 360;
            transform.localEulerAngles = new Vector3(0, 0, zRot);
            yield return null;
        }

        isWorking = false;
        isOpen = false;
    }

    public void MoveOtherPlayer()
    {
        if (!isOpen && !isWorking)
        {
            StartCoroutine(MoveToDoor());
        }
        else if (isOpen && !isWorking)
        {
            StartCoroutine(MoveToOriginal());
        }
    }

    private IEnumerator MoveToDoor()
    {
        var t = 0f;
        isWorking = true;
        var oriPos = transform.localPosition;
        var openTime = 2f;
        while (t < openTime)
        {
            t += Time.deltaTime;
            var xPos = Mathf.Lerp(zRotClose, zRotOpen, t / openTime) % 360;
            transform.localPosition = new Vector3(xPos, oriPos.y, oriPos.z);
            yield return null;
        }

        isWorking = false;
        isOpen = true;
    }

    private IEnumerator MoveToOriginal()
    {
        var t = 0f;
        isWorking = true;
        var oriPos = transform.localPosition;
        var openTime = 2f;
        while (t < openTime)
        {
            t += Time.deltaTime;
            var xPos = Mathf.Lerp(zRotOpen, zRotClose, t / openTime) % 360;
            transform.localPosition = new Vector3(xPos, oriPos.y, oriPos.z);
            yield return null;
        }

        isWorking = false;
        isOpen = false;
    }

    #endregion

    #region ShowPriceTag

    public void ShowPriceTag()
    {
        if (priceTag == null)
        {
            Debug.Log("no Price Tag Found.");
            return;
        }
        priceTag.SetActive(true);
    }

    public void HidePriceTag()
    {
        if (priceTag == null)
        {
            Debug.Log("no Price Tag Found.");
            return;
        }
        priceTag.SetActive(false);
    }

    #endregion
}
