using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActionAsset;
    StateController controller;
    public event Action<Vector2> OnWalkInputReceived;
    public event Action OnBlockInputReceived;
    public event Action OnRunInputReceived;
    public event Action OnRollInputReceived;
    public event Action OnLightAttackInputReceived;
    public event Action OnHeavyAttackInputReceived;
    public event Action OnCrouchInputReceived;
    private void Start()
    {
        InputActionMap actionMap = inputActionAsset.FindActionMap("Overworld");
        actionMap.Enable();
        actionMap.FindAction("Walk").performed += WalkInput;
        actionMap.FindAction("Walk").canceled += WalkInput;

        actionMap.FindAction("Block").performed += BlockInput;
        actionMap.FindAction("Block").canceled += BlockInput;

        actionMap.FindAction("Run").performed += RunInput;
        actionMap.FindAction("Run").canceled += RunInput;

        actionMap.FindAction("Roll").performed += RollInput;

        actionMap.FindAction("Light Attack").performed += LightAttackInput;
        actionMap.FindAction("Heavy Attack").performed += HeavyAttackInput;

        actionMap.FindAction("Crouch").performed += CrouchInput;

        controller = StateController.Instance;
    }

    private void WalkInput(InputAction.CallbackContext c)
    {
        if (controller.GetState() == PlayerState.ACTIVE) OnWalkInputReceived?.Invoke(c.ReadValue<Vector2>());
    }

    private void BlockInput(InputAction.CallbackContext c)
    {
        if (controller.GetState() == PlayerState.ACTIVE || controller.GetState() == PlayerState.BLOCK) OnBlockInputReceived?.Invoke();

    }

    private void RunInput(InputAction.CallbackContext c)
    {

        if (controller.GetState() == PlayerState.ACTIVE) OnRunInputReceived?.Invoke();
    }

    private void RollInput(InputAction.CallbackContext c)
    {
        OnRollInputReceived?.Invoke();
    }

    private void LightAttackInput(InputAction.CallbackContext c) {
        if (controller.GetState() == PlayerState.ACTIVE || controller.GetState() == PlayerState.LINK) OnLightAttackInputReceived?.Invoke();
    }
    
    private void HeavyAttackInput(InputAction.CallbackContext c)
    {
        if (controller.GetState() == PlayerState.ACTIVE) OnHeavyAttackInputReceived?.Invoke();
    }

    private void CrouchInput(InputAction.CallbackContext c) {
        OnCrouchInputReceived?.Invoke();
    }
}
