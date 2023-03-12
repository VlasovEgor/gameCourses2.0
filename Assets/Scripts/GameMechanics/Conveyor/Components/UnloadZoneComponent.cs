using Elementary;
using UnityEngine;

public class UnloadZoneComponent : MonoBehaviour, IUnloadZoneComponent
{

    [SerializeField] private LimitedIntBehavior _unloadStorage;

    public int Value
    {
        get
        {
            return _unloadStorage.Value;
        }
        set
        {
            _unloadStorage.Value = value;
        }
    }

    public int MaxValue
    {
        get
        {
            return _unloadStorage.MaxValue;
        }
        set
        {
            _unloadStorage.MaxValue = value;
        }
    }

    public bool CanUnload()
    {
        return _unloadStorage.Value > 0;
    }

    public int UnloadAll()
    {
        var result = _unloadStorage.Value;
        _unloadStorage.Value = 0;
        return result;
    }
}