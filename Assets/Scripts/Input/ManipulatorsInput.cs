using System;
using UnityEngine;

public class ManipulatorsInput : MonoBehaviour,IStartGameListener,IFinishGameListener
{
    public event Action<Vector3> OnMove;
    public event Action OnJump;
    public event Action OnShoot;

    private void Awake()
    {
        enabled = false;
    }

    void IStartGameListener.OnStartGame()
    {
        enabled = true;
    }

    void IFinishGameListener.OnFinishGame()
    {
        enabled = false;
    }

    private void Update()
    {
        HandleMoveKeyboard();
        HandleJumpKeyboard();
        ProcessingMouseClicks();
    }

    private void ProcessingMouseClicks()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        OnShoot?.Invoke();
    }

    private void HandleMoveKeyboard()
    {
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Move(inputVector);
    }

    private void Move(Vector3 inputVector)
    {
        OnMove?.Invoke(inputVector);
    }

    private void HandleJumpKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        OnJump?.Invoke();
    }
}