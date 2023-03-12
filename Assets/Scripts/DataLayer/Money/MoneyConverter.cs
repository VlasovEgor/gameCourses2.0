
public class MoneyConverter 
{
    public void SetupMoney(MoneyStorage moneyStorage, MoneyData data)
    {
       moneyStorage.SetupMoney(data.Money);
    }

    public MoneyData ConvertToData(MoneyStorage moneyStorage)
    {
        var data = new MoneyData
        {
            Money = moneyStorage.Money
        };

        return data;
    }
}
