using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ChestCatalog", menuName = "Chest/New ChestCatalog")]
public class ChestCatalog : ScriptableObject
{
    [SerializeField] private ChestConfig[] _configs;

    public ChestConfig[] GetAllChests()
    {
        return _configs;
    }

    public ChestConfig FindChests(string id)
    {
        var length = _configs.Length;
        for (var i = 0; i < length; i++)
        {
            var config = _configs[i];
            if (config.Id == id)
            {
                return config;
            }
        }

        throw new Exception($"Config with {id} is not found!");
    }
}
