using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActionAsset;



    private void Start()
    {
        InputActionMap actionMap = inputActionAsset.FindActionMap("Overworld");

        actionMap.FindAction("Walk").performed += WalkInput;
        actionMap.FindAction("Walk").canceled += WalkInput;

        actionMap.FindAction("Block").performed += BlockInput;
        actionMap.FindAction("Block").canceled+= BlockInput;

        actionMap.FindAction("Run").performed += RunInput;
        actionMap.FindAction("Run").canceled += RunInput;

        actionMap.FindAction("Roll").performed += RollInput;

        actionMap.FindAction("Light Attack").performed += LightAttackInput;
        actionMap.FindAction("Heavy Attack").performed += HeavyAttackInput;

        actionMap.FindAction("Crouch").performed += CrouchInput;



    }

    private void WalkInput(InputAction.CallbackContext c)
    {

    }

    private void BlockInput(InputAction.CallbackContext c)
    {

    }

    private void RunInput (InputAction.CallbackContext c)
    {

    }

    private void RollInput(InputAction.CallbackContext c)
    {

    }

    private void LightAttackInput(InputAction.CallbackContext c) {

    }
    
    private void HeavyAttackInput(InputAction.CallbackContext c)
    {

    }

    private void CrouchInput(InputAction.CallbackContext c) {

    }
}
