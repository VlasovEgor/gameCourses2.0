
using System.Collections.Generic;

public abstract class DataArrayRepository<T>
{
    protected abstract string Key { get; }

    protected bool LoadData(out T[] dataArray)
    {
        if (PlayerPreferences.KeyExists(Key))
        {
            dataArray = PlayerPreferences.Load<T[]> (Key);
            return true;
        }

        dataArray = null;
        return false;
    }

    protected void SaveData(T[] data)
    {
        PlayerPreferences.Save(Key, data);
    }
}
