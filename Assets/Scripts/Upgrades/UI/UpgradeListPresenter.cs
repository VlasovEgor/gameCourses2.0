using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeListPresenter : MonoBehaviour, IConstructListener
{
    [SerializeField] private UpgradeView _viewPrefab;
    [SerializeField] private Transform _viewContainer;

    private UpgradesManager _upgradesManager;
    private MoneyStorage _moneyStorage;

    private List<UpgradeView> _activeViews = new();
    private List<UpgradePresenter> _activePresenter = new();

    private GameContext _context;

    public void Construct(GameContext context)
    {
       // _upgradesManager = context.GetService<UpgradesManager>();
       // _moneyStorage = context.GetService<MoneyStorage>();
       // _context = context;
    }


    [Button]
    public void Show()
    {
        Upgrade[] upgrades = _upgradesManager.GetAllUpgrades();

        foreach (var upgrade in upgrades)
        {
            UpgradeView view = Instantiate(_viewPrefab, _viewContainer);
            _activeViews.Add(view);

            UpgradePresenter presenter = new(upgrade, view);
            presenter.Construct(_upgradesManager, _moneyStorage);

            _activePresenter.Add(presenter);

            _context.AddListener(upgrade);//SOS
        }

        foreach(var presenter in _activePresenter)
        {
            presenter.Start();
        }
    }

    [Button]
    public void Hide()
    {
        foreach (var presenter in _activePresenter)
        {
            presenter.Stop();
        }

        foreach (var view in _activeViews)
        {
            Destroy(view.gameObject);
        }

        _activeViews.Clear();
        _activePresenter.Clear();
        
    }
}