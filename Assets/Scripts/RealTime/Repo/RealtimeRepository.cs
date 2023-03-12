
public sealed class RealtimeRepository : DataRepository<RealtimeData>
{
    protected override string Key => "UserSessionData";

    public bool LoadSession(out RealtimeData data)
    {
        return LoadData(out data);
    }

    public void SaveSession(RealtimeData data)
    {
        SaveData(data);
    }
}
