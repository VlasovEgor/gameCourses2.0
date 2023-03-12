using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class ChestManager :IDisposable
{
    public event Action<Chest> OnChestLaunched;

    public event Action<Chest> OnChestStarted;

    public event Action<Chest> OnChestFinished;

    [Inject] private RewardSystem _rewardSystem;
    [Inject] private ChestRewardGenerator _chestRewardGenerator;
    [Inject] private Chest.Factory _factory;

    [PropertySpace(8), ReadOnly, ShowInInspector] 
    private Dictionary<string, Chest> _chests = new();

    public void Setup(List<Chest> chests)
    {
        _chests = chests.ToDictionary(it => it.Id);
        StartAllChests();
    }

    public Chest LoadChest(ChestConfig chestConfig)
    {
        var chest = _factory.Create(chestConfig);
        chest.OnCompleted += OnEndChest;

        _chests.Add(chest.Id, chest);
        StartAllChests();

        return chest;
    }

    public List<Chest> GetAllChests()
    {
        var activeChests = new List<Chest>();

        foreach (var currentChest in _chests)
        {
            activeChests.Add(currentChest.Value);
        }

        return activeChests;
    }

    public List<Chest> GetActiveChests()
    {
        var activeChests = new List<Chest>();

        foreach (var currentChest in _chests)
        {

            if (currentChest.Value.IsActive == true)
            {
                activeChests.Add(currentChest.Value);
            }
        }

        return activeChests;
    }

    public void OpenChest(string chestId)
    {
        var currentChest = _chests[chestId];

        if (currentChest.IsActive == true)
        {
            Debug.Log("≈Ÿ® –¿ÕŒ Œ“ –€¬¿“‹");
        }
        else
        {
            var rewards = _chestRewardGenerator.GenerateRewards(currentChest);
            _rewardSystem.AccrueReward(rewards);
            currentChest.Start();
        }
    }

    void IDisposable.Dispose()
    {
        StopAllChests();
    }

    private void StartAllChests()
    {
        foreach (var keyValue in _chests)
        {
            var currentChest = keyValue.Value;
            if (currentChest.IsActive == true)
            {
                continue;
            }

            currentChest.Start();

            OnChestStarted?.Invoke(currentChest);
            OnChestLaunched?.Invoke(currentChest);
        }
    }

    private void StopAllChests()
    {
        foreach (var keyValue in _chests)
        {
            var currentChest = keyValue.Value;

            if (currentChest.IsActive == false)
            {
                continue;
            }

            currentChest.OnCompleted -= OnEndChest;
            currentChest.Stop();
        }
    }

    private void OnEndChest(Chest chest)
    {
        chest.OnCompleted -= OnEndChest;
        OnChestFinished?.Invoke(chest);
    }
}