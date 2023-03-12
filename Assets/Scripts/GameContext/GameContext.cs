using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;


public class GameContext : MonoBehaviour, IGameContext
{

    [ReadOnly] [ShowInInspector] private List<object> _listeners = new List<object>();

    public void AddListener(object listener)
    {
        _listeners.Add(listener);
    }

    public void RemoveListener(object listener)
    {
        _listeners.Remove(listener);
    }

    [Button]
    public void ConstructGame()
    {
        foreach (var listener in _listeners)
        {
            if (listener is IConstructListener constractListener)
            {
                constractListener.Construct(context: this);
            }
        }

        Debug.Log("Game construct");
    }

    [Button]
    public void InitializationGame()
    {
        foreach (var listener in _listeners)
        {
            if (listener is IInitGameListener initializationListener)
            {
                initializationListener.OnInitGame();
            }
        }

        Debug.Log("Game init");
    }

    [Button]
    public void StartGame()
    {
        foreach (var listener in _listeners)
        {
            if (listener is IStartGameListener startListener)
            {
                startListener.OnStartGame();
            }
        }

        Debug.Log("Game started");

    }

    [Button]
    public void FinishGame()
    {
        foreach (var listener in _listeners)
        {
            if (listener is IFinishGameListener finishListener)
            {
                finishListener.OnFinishGame();
            }
        }

        Debug.Log("Game finished");
    }


}