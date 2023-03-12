using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeInfo", menuName = "Upgrade/ UpgradeUI")]

public class UpgradeInfo : ScriptableObject
{
    [PreviewField][SerializeField] public Sprite Icon;

    [SerializeField] public string Title;

    [SerializeField] public string Stats;

    [SerializeField] public int Price;
}
