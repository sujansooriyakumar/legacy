using System;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private InputController inputController;
    [SerializeField] private AnimationController animationController;
    public float walkSpeed;
    public float rotationSpeed;
    private Vector3 walkVector;
    public event Action OnWalk;

    private void Start() { inputController.OnWalkInputReceived += Walk; }
    private void Walk(Vector2 walkVector_){      
        walkVector = new Vector3(walkVector_.x, 0, walkVector_.y);
    }

    private void Update()
    {
       

        Vector3 moveDirection = transform.TransformDirection(walkVector.normalized);

        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

        transform.position += moveDirection * walkSpeed * Time.deltaTime;
        Animate();
        OnWalk?.Invoke();
    }

    private void Animate()
    {
        animationController.UpdateFloatParam("moveZ", walkVector.z);
        if(walkVector.z == 0) animationController.UpdateFloatParam("moveX", walkVector.x);
    }
}
