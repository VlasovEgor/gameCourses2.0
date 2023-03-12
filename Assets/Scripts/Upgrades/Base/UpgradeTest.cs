using Sirenix.OdinInspector;
using UnityEngine;

public class UpgradeTest: MonoBehaviour
{
    [SerializeField] private UpgradeConfig _config;
    [SerializeField] private GameContext _context;

    private Upgrade _upgrade;

    private void Awake()
    {
        _upgrade = _config.InstantiateUpgrade();
        _context.AddListener(_upgrade);
    }

    [Button]
    private void DoUpgrade()
    {
        if (_upgrade.IsMaxLevel==false)
        {
            _upgrade.LevelUp();
            Debug.Log($"Level up {_config} {_upgrade.Level}");
        }
    }
}

