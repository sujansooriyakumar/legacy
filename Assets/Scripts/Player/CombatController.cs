using UnityEngine;

[RequireComponent(typeof(InputController))]
[RequireComponent(typeof(AnimationController))]

public class CombatController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    InputController inputController;
    AnimationController animationController;
    StateController stateController;
    private void Start()
    {
        inputController = GetComponent<InputController>();
        animationController = GetComponent<AnimationController>();
        stateController = StateController.Instance;
        inputController.OnLightAttackInputReceived += LightAttack;
        inputController.OnHeavyAttackInputReceived += HeavyAttack;
        inputController.OnBlockInputReceived += Block;

    }

    private void LightAttack()
    {
       
        if (stateController.GetState() == PlayerState.ACTIVE|| stateController.GetState() == PlayerState.LINK)
        {
            
            animationController.UpdateTriggerParam("light_atk");
            StateController.Instance.UpdateState(PlayerState.ATTACK);
        }

        
        
    }

    private void HeavyAttack()
    {
        if (stateController.GetState() == PlayerState.ACTIVE)
        {

            animationController.UpdateTriggerParam("heavy_atk");
            stateController.UpdateState(PlayerState.ATTACK);
        }
    }

    private void Block()
    {
        if (stateController.GetState() == PlayerState.ACTIVE)
        {
            animationController.UpdateBoolParam("block", true);
            stateController.UpdateState(PlayerState.BLOCK);
            return;
        }

        else if (stateController.GetState() == PlayerState.BLOCK)
        {
            animationController.UpdateBoolParam("block", false);
            stateController.UpdateState(PlayerState.ACTIVE);
        }
    }

    private void Roll()
    {
        if (stateController.GetState() == PlayerState.ACTIVE)
        {
            animationController.UpdateTriggerParam("roll");
            stateController.UpdateState(PlayerState.ROLL);
        }
    }
}
