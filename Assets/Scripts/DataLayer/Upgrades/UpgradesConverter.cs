using UnityEngine;

public class UpgradesConverter : MonoBehaviour
{
    public void SetupStats(PlayerInfo playerUpgrade, UpgradesPlayerData data)
    {
        playerUpgrade.Level = data.Level;
        playerUpgrade.Icon = data.Icon;
        playerUpgrade.Price = data.Price;
        playerUpgrade.Damage= data.Damage;
        playerUpgrade.Name = data.Name;
    }

    public UpgradesPlayerData ConvertToData(PlayerInfo playerUpgrade)
    {
        var data = new UpgradesPlayerData
        {   
            Level= playerUpgrade.Level,
            Damage= playerUpgrade.Damage,
            HealthPoints= playerUpgrade.HealthPoints,
            Icon= playerUpgrade.Icon,
            Name= playerUpgrade.Name,
            Price= playerUpgrade.Price,

        };

        return data;
    }
}