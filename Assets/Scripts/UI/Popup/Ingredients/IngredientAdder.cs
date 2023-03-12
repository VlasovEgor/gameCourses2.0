using UnityEngine;

public class IngredientAdder : MonoBehaviour
{
    public int Amount;

    private int _numberChanges=1;


    public void Add(StorageComponent storage)
    {
        if (CanAdd(storage))
        {
            storage.Load(Amount);
        }
    }

    public bool CanAdd(StorageComponent storage)
    {
        return storage.CanLoad() && CanIncrease(storage) && CanDecrease();
    }

    public void Increase(StorageComponent storage)
    {
        if(CanIncrease(storage)) 
        {
            Amount += _numberChanges;
        }
    }

    public bool CanIncrease(StorageComponent storage)
    {
        return Amount <= (storage.MaxValue - storage.Value);
    }

    public void Decrease()
    {
        if(CanDecrease())
        {
            Amount -= _numberChanges;
        }
    }

    public bool CanDecrease()
    {
        return Amount > 0;
    }

}
