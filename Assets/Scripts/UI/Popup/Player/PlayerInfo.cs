using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "Gameplay/ PopupPlayer")]
public class PlayerInfo : ScriptableObject
{
    [PreviewField][SerializeField] public Sprite Icon;

    [SerializeField] public string Name;

    [SerializeField] public int Level;

    [SerializeField] public int HealthPoints;

    [SerializeField] public int Damage;

    [SerializeField] public int Price;
}