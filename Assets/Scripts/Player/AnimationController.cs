using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    public void UpdateBoolParam(string param, bool val)
    {
        animator.SetBool(param, val);
    }

    public void UpdateIntParam(string param, int val)
    {
        animator.SetInteger(param, val);
    }

    public void UpdateFloatParam(string param, float val)
    {
        animator.SetFloat(param, val);
    }

    public void UpdateTriggerParam(string param)
    {
        animator.SetTrigger(param);
    }

 
}
