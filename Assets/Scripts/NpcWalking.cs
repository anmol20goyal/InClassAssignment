using UnityEngine;

public class NpcWalking : MonoBehaviour
{
    #region Variables

    public float speed;
    private float timer = 6f;
    private float currentTimer = 0f;
    public bool isWalking;

    #endregion

    #region GameObjects

    private Animator animator;

    #endregion

    private void Start()
    {
        isWalking = false;

        animator = GetComponent<Animator>();

        if (animator == null )
        {
            Debug.LogError("Missing animator");
            Destroy(this);
        }
    }

    private void Update()
    {
        if (isWalking)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    public void NpcWalkOnCommand()
    {
        // if isWalking == false...then start walking on click and set isWalking to true and vice versa
        animator.SetFloat("Speed", isWalking ? 0 : 1);
        isWalking = !isWalking;
    }

    public void NpcDance()
    {
        animator.SetTrigger("Dance");
        NpcClapStop();
    }

    public void NpcClapStop() 
    {
        animator.SetBool("Clap", false);
    }

    public void NpcClapStart()
    {
        animator.SetBool("Clap", true);
    }
}