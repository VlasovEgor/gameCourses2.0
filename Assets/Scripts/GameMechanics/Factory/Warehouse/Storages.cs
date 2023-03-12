using UnityEngine;

public class Storages : MonoBehaviour
{
    public StorageComponent[] StorageComponents;

    private void Awake()
    {
        for (int i = 0; i < StorageComponents.Length; i++)
        {
            StorageComponents[i].IdStorage = i;
        }
    }
}
