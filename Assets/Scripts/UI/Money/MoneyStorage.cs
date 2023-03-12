using UnityEngine;
using System;
using Sirenix.OdinInspector;

public class MoneyStorage : MonoBehaviour
{
    public event Action<int> OnMoneyChanged;

    public int Money
    {
        get { return _money; }
    }

    [ReadOnly]
    [ShowInInspector]
    private int _money;

    [Button]
    public void SetupMoney(int money)
    {
        _money = money;
        OnMoneyChanged?.Invoke(_money);
    }

    [Button]
    public void AddMoney(int range)
    {
        _money += range;
        OnMoneyChanged?.Invoke(_money);
    }

    [Button]
    public void SpendMoney(int range)
    {
        _money -= range;
        OnMoneyChanged?.Invoke(_money);
    }

    public bool CanSpendMoney(int amount)
    {
        return _money >= amount;
    }
}
