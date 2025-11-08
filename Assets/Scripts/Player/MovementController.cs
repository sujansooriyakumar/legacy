using System;
using UnityEngine;

[RequireComponent(typeof(InputController))]
[RequireComponent(typeof(AnimationController))]

public class MovementController : MonoBehaviour
{
    InputController inputController;
    AnimationController animationController;
    private Vector3 walkVector;
    private bool running = false;
    public event Action OnWalk;

    private void Start() { 
        inputController = GetComponent<InputController>();
        animationController = GetComponent<AnimationController>();
        inputController.OnWalkInputReceived += Walk;
        inputController.OnRunInputReceived += Run;
        
    }
    private void Walk(Vector2 walkVector_){      
        walkVector = new Vector3(walkVector_.x, 0, walkVector_.y);
    }

    private void Run()
    {
        if (running) running = false;
        else running = true;
    }

    private void Update()
    {
        Animate();
        OnWalk?.Invoke();
    }

    private void Animate()
    {
        animationController.UpdateFloatParam("moveZ", walkVector.z);
        if(walkVector.z == 0) animationController.UpdateFloatParam("moveX", walkVector.x);
        animationController.UpdateBoolParam("run", running);
    }
}
