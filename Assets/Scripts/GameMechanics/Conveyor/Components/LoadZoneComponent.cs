using Elementary;
using UnityEngine;

public class LoadZoneComponent : MonoBehaviour,ILoadZoneComponent
{
    [SerializeField] private LimitedIntBehavior _loadStorage;

    public bool CanLoad()
    {
        return !_loadStorage.IsLimit;
    }

    public void Load(int resources)
    {
        _loadStorage.Value += resources;
    }

   
}
