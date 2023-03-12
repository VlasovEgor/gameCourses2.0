
public struct WarehouseCollector
{
    public Ingredients TypeIngredient
    {
        get { return _typeIngredient; }
        set { _typeIngredient = value; }
    }

    public int AmountIngredient
    {
        get { return _amountIngredient; }
        set { _amountIngredient = value;}
    }

    private int _amountIngredient;
    private Ingredients _typeIngredient;

}