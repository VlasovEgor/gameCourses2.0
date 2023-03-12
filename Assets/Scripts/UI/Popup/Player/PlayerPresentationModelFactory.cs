using UnityEngine;

public class PlayerPresentationModelFactory : MonoBehaviour, IConstructListener
{
    private PlayerUpgrader _playerUpgrader;
    private MoneyStorage _moneyStorage;

    public void Construct(GameContext context)
    {
       // _playerUpgrader = context.GetService<PlayerUpgrader>();
       // _moneyStorage = context.GetService<MoneyStorage>();
    }

    public PlayerPresentationModel CreatePresenter(PlayerInfo player)
    {
        return new PlayerPresentationModel(player, _playerUpgrader, _moneyStorage);
    }
}