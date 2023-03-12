using System;
using UnityEngine;

public interface IPlayerPresentationModel
{
    event Action<bool> OnBuyButtonStateChanged;
    event Action OnLevelUp;

    string GetPlayerName();

    string GetLevel();

    string GetHealthPoints();

    string GetDamage();

    Sprite GetIcon();

    string GetPrice();

    bool CanBuy();

    void OnBuyClicked();

    void Start();

    void Stop();
}
