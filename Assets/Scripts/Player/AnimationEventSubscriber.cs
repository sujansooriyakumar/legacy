using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEventSubscriber : MonoBehaviour
{

    public void AttackComplete()
    {
        StateController.Instance.ResetState();
    }

    public void ResetState()
    {
        StateController.Instance.ResetState(); 
    }
}
