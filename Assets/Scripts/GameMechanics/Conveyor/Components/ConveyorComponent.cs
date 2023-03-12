using UnityEngine;

public class ConveyorComponent : MonoBehaviour, IConveyorComponent
{
    [SerializeField] private ConveyorMechanics _conveyorMechanics;

    public void TryStartWork(Recipe recipe)
    {
        _conveyorMechanics.TryStartWork(recipe);
    }
}
