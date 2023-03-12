using Elementary;
using UnityEngine;

public class StorageComponent : MonoBehaviour, IStorageComponent
{
    [SerializeField] private Ingredients _type;

    [SerializeField] private LimitedIntBehavior _storage;

    private int _id;

    public Ingredients Type
    {
        get
        {
            return _type;
        }
    }

    public int Value
    {
        get
        {
            return _storage.Value;
        }
        set
        {
            _storage.Value = value;
        }
    }

    public int MaxValue
    {
        get
        {
            return _storage.MaxValue;
        }
        set
        {
            _storage.MaxValue = value;
        }
    }

    public int IdStorage
    {
        get 
        {
            return _id; 
        }
        set 
        {
            _id= value; 
        }
    }

    public bool CanLoad()
    {
        return !_storage.IsLimit;
    }

    public void Load(int resources)
    {
        _storage.Value += resources;
    }

    public bool CanUnload()
    {
        return _storage.Value > 0;
    }

    public int Unload(int amount)
    {
        if(amount< _storage.Value)
        {
            var result = amount;
            _storage.Value -= amount;
            return result;
        }
        else
        {
            return UnloadAll();
        }
    }

    public int UnloadAll()
    {
        var result = _storage.Value;
        _storage.Value = 0;
        return result;
    }
}