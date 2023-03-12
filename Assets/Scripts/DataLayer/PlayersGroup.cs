using System;
using UnityEngine;

public class PlayersGroup : MonoBehaviour
{
    [SerializeField] private PlayerConfig[] _players;

    private void Awake()
    {
        _players = FindObjectsOfType<PlayerConfig>();
        SetPlayersID();
    }
    private void SetPlayersID()
    {
        for (var i = 0; i < _players.Length; i++)
        {
            var config = _players[i];
            config.PlayerID = i;
        }
    }

    public PlayerConfig[] GetAllPlayers()
    {
        return _players;
    }

    public PlayerConfig FindPlayer(int id)
    {
        for (var i = 0; i < _players.Length; i++)
        {
            var config = _players[i];
            if (config.PlayerID == id)
            {
                return config;
            }
        }

        throw new Exception($"Player with {id} is not found!");
    }
}