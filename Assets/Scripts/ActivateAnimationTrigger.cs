using UnityEngine;

public class ActivateAnimationTrigger : MonoBehaviour
{
    public string animationTrigger;
    private Animator animator;

    // Use this for initialization
    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Missing animator");
            Destroy(this);
        }
    }
    
    public void PlayAnimationTrigger()
    {
        animator.SetTrigger(animationTrigger);
    }
}