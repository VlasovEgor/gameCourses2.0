using UnityEngine;

public class ProductPresentationModelFactory : MonoBehaviour,IConstructListener
{
    private ProductBuyer _productBuyer;
    private MoneyStorage _moneyStorage;

    public void Construct(GameContext context)
    {
        //_productBuyer = context.GetService<ProductBuyer>();
        //_moneyStorage = context.GetService<MoneyStorage>();
    }

    public ProductPresentationModel CreatePresenter(ProductInfo product)
    {
        return new ProductPresentationModel(product , _productBuyer, _moneyStorage);
    }
}
