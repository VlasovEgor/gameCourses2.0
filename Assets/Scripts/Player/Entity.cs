using System;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IEntity
{
    [SerializeField] private MonoBehaviour[] _components;

    public T Get<T>()
    {
        for (int i = 0; i < _components.Length; i++)
        {
            
            if (_components[i] is T result)
            {
                return result;
            }

        }

        throw new Exception($"Component of type {typeof(T).Name} is not found!");
    }

    public T[] GetAll<T>()
    {
        var result = new List<T>();
        for (int i = 0; i < _components.Length; i++)
        {
            if (_components[i] is T element)
            {
                result.Add(element);
            }
        }

        return result.ToArray();
    }
    

    public bool TryGet<T>(out T result)
    {
        for (int i = 0; i < _components.Length; i++)
        {

            if (_components[i] is T tComponent)
            {
                result = tComponent;
                return true;
            }

        }

        result = default;
        return false;
    }
}
