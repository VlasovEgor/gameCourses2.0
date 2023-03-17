
public class ChestsRepository : DataArrayRepository<ChestsData>
{
    protected override string Key => "Chests";

    public bool LoadChests(out ChestsData[] chestsData)
    {
        return LoadData(out chestsData);
    }

    public void SaveChests(ChestsData[] chestsData)
    {
        SaveData(chestsData);
    }
}
