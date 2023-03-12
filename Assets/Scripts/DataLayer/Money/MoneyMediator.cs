
using Zenject;

public class MoneyMediator
{
    private MoneyRepository _moneyRepository;
    private MoneyStorage _moneyStorage;
    private MoneyConverter _moneyConverter = new MoneyConverter();


    public void Construct(MoneyRepository repository, MoneyStorage moneyStorage)
    {
        _moneyRepository = repository;
    }

    public void LoadData(IGameContext context)
    {
        _moneyRepository.TryLoadMoney(out MoneyData data);

        //MoneyStorage moneyStorage = context.GetService<MoneyStorage>();

        //_moneyConverter.SetupMoney(moneyStorage, data);

    }

    public void SaveData(IGameContext context)
    {
       // MoneyStorage moneyStorage = context.GetService<MoneyStorage>();
       // var data = _moneyConverter.ConvertToData(moneyStorage);

        //_moneyRepository.SaveMoney(data);
    }
}
