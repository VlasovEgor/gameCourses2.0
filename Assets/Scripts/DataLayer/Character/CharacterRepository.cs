using UnityEngine;

public class CharacterRepository
{
    private string PLAYER_PREFS_KEY = "CharacterData";

    public bool TryLoadStats(out CharacterData data,int id)
    {
        if (PlayerPrefs.HasKey(PLAYER_PREFS_KEY + id.ToString()))
        {
            var json = PlayerPrefs.GetString(PLAYER_PREFS_KEY + id.ToString());
            data = JsonUtility.FromJson<CharacterData>(json);
            Debug.Log($"<color=orange>LOAD CHARACTER DATA {json}</color>");
            return true;
        }
        else
        {
            Debug.Log("lox");
        }

        data = default;
        return false;
    }

    public void SaveStats(CharacterData data,int id)
    {
        var json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(PLAYER_PREFS_KEY + id.ToString(), json) ;
        Debug.Log($"<color=yellow>SAVE CHARACTER DATA {json}</color>");
    }
}