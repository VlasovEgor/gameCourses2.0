using UnityEngine;

[CreateAssetMenu(
        fileName = "ChestConfig",
        menuName = "Chest/New ChestConfig"
    )]
public class ChestConfig : ScriptableObject
{
    [SerializeField] public string Id;

    [SerializeField] public float DurationSeconds;

    [SerializeField] public int MaxNumbersOfReward;

    [SerializeField] public int MinNumbersOfReward;

    [SerializeField] public int MaxRewardAmount;

    [SerializeField] public int MinRewardAmount;

    public Chest InstatiateChest(MonoBehaviour context)
    {
        return new Chest(this, context);
    }
}