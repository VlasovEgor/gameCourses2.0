using UnityEngine;

public class UpgradesMediator : MonoBehaviour
{
    private UpgradesRepository _upgradesRepository;
    private UpgradesConverter _upgradesConverter = new UpgradesConverter();

    public void Construct(UpgradesRepository repository)
    {
        _upgradesRepository = repository;
    }

    public void LoadData(PlayerInfo playerUpgrade)
    {
        _upgradesRepository.TryLoadStats(out UpgradesPlayerData data);
        _upgradesConverter.SetupStats(playerUpgrade, data);
    }


    public void SaveData(PlayerInfo playerUpgrade)
    {
        var data = _upgradesConverter.ConvertToData(playerUpgrade);
        _upgradesRepository.SaveStats(data);
    }
}
