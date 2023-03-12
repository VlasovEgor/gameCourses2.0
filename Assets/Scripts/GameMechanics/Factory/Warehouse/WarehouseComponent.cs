using System.Collections.Generic;
using UnityEngine;

public class WarehouseComponent : MonoBehaviour,IWarehouseComponent
{
    [SerializeField] private ResourceCollectionMechanics _resourceCollectionMechanics;
    [SerializeField] private MechanicsResourceReduction _mechanicsResourceReduction;

    public void TakeResource(Ingredients Type, int Amount)
    {
        _resourceCollectionMechanics.TakeResources(Type, Amount);
    }

    public void GiveResource(Recipe recipe, Dictionary<Ingredients, WarehouseCollector> resourcesDictionary)
    {
        _mechanicsResourceReduction.DeleteResources( recipe, resourcesDictionary);
    }
}
