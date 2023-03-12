using Sirenix.OdinInspector;
using UnityEngine;

public class ConveyorTest : MonoBehaviour
{
    [SerializeField] private Entity _conveyor;

    [Button]
    private void LoadResources(int resourceCount)
    {
        var loadComponent = _conveyor.Get<ILoadZoneComponent>();
        if (loadComponent.CanLoad())
        {
            loadComponent.Load(resourceCount);
        }
    }

    [Button]
    private void TakeAllResources()
    {
        var unloadComponent = _conveyor.Get<IUnloadZoneComponent>();

        if (unloadComponent.CanUnload())
        {
            var extractedResources = unloadComponent.UnloadAll();
            Debug.Log($"Extracted resources {extractedResources}");
        }

    }
}
