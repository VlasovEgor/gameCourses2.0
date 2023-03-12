using UnityEngine;

public class WarehouseAdder : MonoBehaviour
{
    private int _amount;

    private int _numberChanges = 1;
    private StorageComponent _storageComponent;

    public int Amount
    { 
        get 
        {
            return _amount; 
        }
    }

    public void Increase(StorageComponent storage)
    {
        _storageComponent=storage;
        if (CanIncrease(_storageComponent))
        {
            _amount += _numberChanges;
        }
    }

    public bool CanIncrease(StorageComponent storage)
    {
        return _amount <= storage.Value;
    }

    public void Decrease(StorageComponent storage)
    {
        _storageComponent = storage;
        if (CanDecrease())
        {
            _amount -= _numberChanges;
        }
    }

    public bool CanDecrease()
    {
        return _amount > 0;
    }

    public void Add(IWarehouseComponent warehouseComponent,StorageComponent storageComponent)
    {   
        if(CanAdd(storageComponent))
        {
            warehouseComponent.TakeResource(storageComponent.Type, _amount);
            _amount = 0;
        }
    }

    public bool CanAdd(StorageComponent storage)
    {
        return CanIncrease(storage) & CanDecrease();
    }
}
