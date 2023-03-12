using System;

public class IngredientPresentationModel : IIngredientPresentationModel
{
    public event Action<bool> OnAddButtonStateChanged;
    public event Action<bool> OnIncreaseButtonStateChanged;
    public event Action<bool> OnDecreaseButtonStateChanged;

    public event Action OnStatsChanged;

    private readonly StorageComponent _storage;
    private readonly IngredientAdder _ingredientAdder;

    public IngredientPresentationModel(StorageComponent storage, IngredientAdder ingredientAdder)
    {
        _storage = storage;
        _ingredientAdder = ingredientAdder;
    }

    public string GetTitle()
    {
        return _storage.Type.ToString();
    }

    public string GetAmount()
    {
        return _ingredientAdder.Amount.ToString();
    }

    public bool CanIncrease()
    {
        return _ingredientAdder.CanIncrease(_storage);
    }

    public bool CanDecrease()
    {
        return _ingredientAdder.CanDecrease();
    }

    public bool CanAdd()
    {
        return _ingredientAdder.CanAdd(_storage) ;
    }

    public void OnIncreaseClicked()
    {
        _ingredientAdder.Increase(_storage);
        OnStatsChanged?.Invoke();
    }

    public void OnDecreaseClicked()
    {
        _ingredientAdder.Decrease();
        OnStatsChanged?.Invoke();
    }

    public void OnAddClicked()
    {
        _ingredientAdder.Add(_storage);
        OnStatsChanged?.Invoke();
    }

}