using System;
using UnityEngine;

public class ProductPresentationModel: IProductPresentationModel
{
    public event Action<bool> OnBuyButtonStateChanged;

    
    private readonly ProductBuyer _productBuyer;
    private readonly MoneyStorage _moneyStorage;
    private readonly ProductInfo _product;

    public ProductPresentationModel(ProductInfo product, ProductBuyer productBuyer, MoneyStorage moneyStorage)
    {
        _productBuyer = productBuyer;
        _moneyStorage = moneyStorage;
        _product = product;
    }

    public void Start()
    {
        _moneyStorage.OnMoneyChanged += OnMoneyChanged;
    }

    public void Stop()
    {
        _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        var canBuy = _productBuyer.CanBuy(_product);
        OnBuyButtonStateChanged?.Invoke(canBuy);
    }

    string IProductPresentationModel.GetTitle()
    {
        return _product.Title;
    }

    string IProductPresentationModel.GetDescription()
    {
        return _product.Description;
    }

    Sprite IProductPresentationModel.GetIcon()
    {
        return _product.Icon;
    }

    string IProductPresentationModel.GetPrice()
    {
         return _product.Price.ToString();
    }

    bool IProductPresentationModel.CanBuy()
    {
        return _productBuyer.CanBuy(_product);
    }

    void IProductPresentationModel.OnBuyClicked()
    {
        _productBuyer.Buy(_product);
    }

}
