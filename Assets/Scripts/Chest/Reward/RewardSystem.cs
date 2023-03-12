using System.Collections.Generic;
using Zenject;

public class RewardSystem
{
    [Inject] private MoneyStorage _moneyStorage;

    public void AccrueReward(List<Reward> rewards)
    {
        for (int i = 0; i < rewards.Count; i++)
        {
            if (rewards[i].RewardType == RewardType.MONEY)
            {
                _moneyStorage.AddMoney(rewards[i].Amount);
            }
        }
    }
}