
public abstract class DataRepository<T>
{
    protected abstract string Key { get; }

    protected bool LoadData(out T data)
    {
        if (PlayerPreferences.KeyExists(Key))
        {
            data = PlayerPreferences.Load<T>(Key);
            return true;
        }

        data = default;
        return false;
    }

    protected virtual void SaveData(T data)
    {
        PlayerPreferences.Save<T>(Key, data);
    }

    protected virtual void RemoveData()
    {
        PlayerPreferences.Remove(Key);
    }
}
