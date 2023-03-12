using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeView : MonoBehaviour
{   
    public UpgradeButton UpgradeButton
    { 
        get 
        {
            return _upgradeButton;
        }
    }

    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private TextMeshProUGUI _stats;

    [SerializeField] private Image _icon;

    [SerializeField] private UpgradeButton _upgradeButton;

    public void SetTitle(string title)
    { 
        _title.text = title; 
    }

    public void SetLevel(string level)
    { 
        _level.text = level;
    }

    public void SetStats(string stats)
    { 
        _stats.text = stats;
    }

    public void SetIcon(Sprite icon)
    { 
        _icon.sprite = icon;
    }
}
