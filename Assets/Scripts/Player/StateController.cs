using UnityEngine;

public class StateController:MonoBehaviour
{
    public PlayerState currentState = PlayerState.ACTIVE;

    public static StateController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public void UpdateState(PlayerState newState)
    {
        currentState = newState;
    }

    public void ResetState() {   currentState = PlayerState.ACTIVE;  }

    public PlayerState GetState() { return currentState; }

}

public enum PlayerState
{
    ACTIVE,
    HITSTUN,
    ROLL,
    BLOCK,
    ATTACK,
    LINK
}
