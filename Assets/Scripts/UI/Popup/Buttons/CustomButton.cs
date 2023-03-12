using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class CustomButton : MonoBehaviour
{
    [SerializeField] protected Button button;

    [SerializeField] protected State state;

    public void AddListener(UnityAction action)
    {
        button.onClick.AddListener(action);
    }

    public void RemoveListener(UnityAction action)
    {
        button.onClick.RemoveListener(action);
    }

    public void SetAvailable(bool isAvailable)
    {
        var state = isAvailable ? State.AVAILABLE : State.LOCKED;
        SetState(state);
    }

    public void SetState(State state)
    {
        this.state = state;

        if (state == State.AVAILABLE)
        {
            button.interactable = true;
        }
        else if (state == State.LOCKED)
        {
            button.interactable = false;
        }
        else
        {
            throw new Exception($"Undefined button state {state}!");
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        try
        {
            SetState(state);
        }
        catch (Exception)
        {
            // ignored
        }
    }
#endif


    public enum State
    {
        AVAILABLE,
        LOCKED,
        MAX
    }
}
