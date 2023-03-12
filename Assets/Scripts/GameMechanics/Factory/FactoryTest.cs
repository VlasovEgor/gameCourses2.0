using Sirenix.OdinInspector;
using UnityEngine;

public class FactoryTest : MonoBehaviour
{
    [SerializeField] private Entity _factory;

    [Button]
    private void LoadResources(int resourceCount, Ingredients type)
    {
        var loadComponents = _factory.Get<Warehouse>().GetComponent<Entity>().GetAll<IStorageComponent>();

        for (int i = 0; i < loadComponents.Length; i++)
        {
            if (loadComponents[i].Type == type && loadComponents[i].CanLoad())
            {
                loadComponents[i].Load(resourceCount);
            }
        }
    }
}
