using UnityEngine;

public class UpgradesRepository : MonoBehaviour
{
    private const string PLAYER_PREFS_KEY = "UpgradesData";

    public bool TryLoadStats(out UpgradesPlayerData data)
    {
        if (PlayerPrefs.HasKey(PLAYER_PREFS_KEY))
        {
            var json = PlayerPrefs.GetString(PLAYER_PREFS_KEY);
            data = JsonUtility.FromJson<UpgradesPlayerData>(json);
            Debug.Log($"<color=orange>LOAD Upgrades DATA {json}</color>");
            return true;
        }

        data = default;
        return false;
    }

    public void SaveStats(UpgradesPlayerData data)
    {
        var json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(PLAYER_PREFS_KEY, json);
        Debug.Log($"<color=yellow>SAVE Upgrades DATA {json}</color>");
    }
}