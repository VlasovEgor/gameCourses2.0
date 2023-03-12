using UnityEngine;

public class MoneyRepository : MonoBehaviour
{
    private const string PLAYER_PREFS_KEY = "MoneyData";

    public bool TryLoadMoney(out MoneyData data)
    {
        if (PlayerPrefs.HasKey(PLAYER_PREFS_KEY))
        {
            var json = PlayerPrefs.GetString(PLAYER_PREFS_KEY);
            data = JsonUtility.FromJson<MoneyData>(json);
            Debug.Log($"<color=orange>LOAD MONEY DATA {json}</color>");
            return true;
        }

        data = default;
        return false;
    }

    public void SaveMoney(MoneyData data)
    {
        var json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(PLAYER_PREFS_KEY, json);
        Debug.Log($"<color=yellow>SAVE MONEY DATA {json}</color>");
    }
}
