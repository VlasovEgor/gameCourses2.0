using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    public void Create(Recipe recipe, IConveyorComponent conveyorComponent)
    {
        conveyorComponent.TryStartWork(recipe);
    }
}
