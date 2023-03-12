using System.Collections.Generic;
using UnityEngine;

public class ChestRewardGenerator 
{
    public List<Reward> GenerateRewards(Chest chest)
    {
        List<Reward> rewards = new List<Reward>();
        var chestConfig = chest.ChestConfig;

        var numberRewards = Random.Range(chestConfig.MinNumbersOfReward, chestConfig.MaxNumbersOfReward);

        for (int i = 0; i < numberRewards; i++)
        {
            var newReward = new Reward();
            newReward.RewardType = RewardType.MONEY;
            newReward.Amount = Random.Range(chestConfig.MinRewardAmount, chestConfig.MaxRewardAmount);

            rewards.Add(newReward);
        }

        return rewards;
    }
}
