using Sirenix.OdinInspector;
using UnityEngine;

public sealed class ProductBuyer : MonoBehaviour, IConstructListener
{
    private MoneyStorage moneyStorage;

    void IConstructListener.Construct(GameContext context)
    {
       // moneyStorage = context.GetService<MoneyStorage>();
    }

    [Button]
    public bool CanBuy(ProductInfo product)
    {
        return moneyStorage.Money >= product.Price;
    }

    [Button]
    public void Buy(ProductInfo product)
    {
        if (CanBuy(product))
        {
            moneyStorage.SpendMoney(product.Price);
            Debug.Log($"<color=green>Product {product.Title} successfully purchased!</color>");
        }
        else
        {
            Debug.LogWarning($"<color=red>Not enough money for product {product.Title}!</color>");
        }
    }
}