using UnityEngine;

public class UpgradePresenter
{
    private readonly Upgrade _upgrade;
    private readonly UpgradeView _upgradeView;

    private UpgradesManager _upgradesManager;
    private MoneyStorage _moneyStorage;

    public UpgradePresenter(Upgrade upgrade, UpgradeView upgradeView)
    {
        _upgrade = upgrade;
        _upgradeView = upgradeView;
    }

    public void Construct(UpgradesManager upgradesManager, MoneyStorage moneyStorage)
    {
        _upgradesManager = upgradesManager;
        _moneyStorage = moneyStorage;
    }

    public void Start()
    {
        _upgradeView.UpgradeButton.AddListener(OnButtonClicked);
        _upgrade.OnLevelUp += OnLevelUp;
        _moneyStorage.OnMoneyChanged += OnMoneyChanged;

        UpdateTitle();
        UpdateStats();
        UpdateLevel();
        UpdateIcon();
        UpdateButtonPrice();
        UpdateButtonState();
    }

    public void Stop()
    {
        _upgradeView.UpgradeButton.RemoveListener(OnButtonClicked);
        _upgrade.OnLevelUp -= OnLevelUp;
    }

    private void OnMoneyChanged(int obj)
    {
        UpdateButtonState();
    }

    private void OnButtonClicked()
    {
        if(_upgradesManager.CanLevelUp(_upgrade))
        {
            _upgradesManager.LevelUp(_upgrade);
        }
    }

    private void OnLevelUp()
    {
        UpdateTitle();
        UpdateStats();
        UpdateLevel();
        UpdateButtonState();
        UpdateButtonPrice();
    }

    private void UpdateTitle()
    {
        _upgradeView.SetTitle(_upgrade.UpgradeInfo.Title);
    }

    private void UpdateLevel()
    {
        var text = $"Level: {_upgrade.Level}/ {_upgrade.MaxLevel}";
        _upgradeView.SetLevel(text);
    }

    private void UpdateIcon()
    {
        _upgradeView.SetIcon(_upgrade.UpgradeInfo.Icon);
    }

    private void UpdateStats()
    {
        var text = $"Value: {_upgrade.CurrentStats}";
        Debug.Log("Ý");
       if (!_upgrade.IsMaxLevel)
       {
           text += $" (+{_upgrade.NextImprovement})";
       }

        _upgradeView.SetStats(text);
    }

    private void UpdateButtonState()
    {
        if (_upgrade.IsMaxLevel == true)
        {
            _upgradeView.UpgradeButton.SetState(UpgradeButton.State.MAX);
            return;
        }
        
        if(_moneyStorage.CanSpendMoney(_upgrade.NextPrice))
        {
            _upgradeView.UpgradeButton.SetState(UpgradeButton.State.AVAILABLE); 
        }
        else
        {
            _upgradeView.UpgradeButton.SetState(UpgradeButton.State.LOCKED);
        }
    }

    private void UpdateButtonPrice()
    {
        if(_upgrade.IsMaxLevel==false)
        {
            _upgradeView.UpgradeButton.SetPrice(_upgrade.NextPrice.ToString());
        }
    }
}