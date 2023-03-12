using System;
using UnityEngine;

public interface IProductPresentationModel 
{
    event Action<bool> OnBuyButtonStateChanged;

    string GetTitle();

    string GetDescription();

    Sprite GetIcon();

    string GetPrice();

    bool CanBuy();

    void OnBuyClicked();

    void Start();

    void Stop();
}
