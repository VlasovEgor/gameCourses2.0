using UnityEngine;
using Zenject;

public class MoneyPanelAdapter : MonoBehaviour,IStartGameListener,IFinishGameListener
{
    [SerializeField] private MoneyPanel _moneyPanel;

    private MoneyStorage _moneyStorage;

    [Inject]
    public void Construct(MoneyStorage moneyStorage)
    {
        _moneyStorage = moneyStorage;
        _moneyPanel.SetupMoney(_moneyStorage.Money.ToString());
    }

    public void OnStartGame()
    {
        _moneyStorage.OnMoneyChanged += OnMoneyChanged;
    }

    public void OnFinishGame()
    {
        _moneyStorage.OnMoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _moneyPanel.UpdateMoney(money.ToString());
    }
}
