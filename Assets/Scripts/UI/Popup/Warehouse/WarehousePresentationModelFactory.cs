using UnityEngine;

public class WarehousePresentationModelFactory : MonoBehaviour,IConstructListener
{
    private WarehouseAdder _warehouseAdder;
    IWarehouseComponent _warehouseComponent;

    public void Construct(GameContext context)
    {
        //_warehouseAdder = context.GetService<WarehouseAdder>();
        //_warehouseComponent= context.GetService<IWarehouseComponent>();
    }

    public WarehousePresentationModel CreatePresenter()
    {
        return new WarehousePresentationModel(_warehouseAdder, _warehouseComponent);
    }
}
