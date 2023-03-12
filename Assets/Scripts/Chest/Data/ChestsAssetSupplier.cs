using UnityEngine;
using Zenject;

public class ChestsAssetSupplier : IInitializable
{
    public const string CHEST_CATALOG_RESOURCE_PATH = "ChestCatalog";

    [Inject] private ChestCatalog _catalog;

    public ChestConfig GetChest(string id)
    {
        return _catalog.FindChests(id);
    }

    public ChestConfig[] GetAllChests()
    {
        return _catalog.GetAllChests();
    }

    public void Initialize()
    {
        _catalog = Resources.Load<ChestCatalog>(CHEST_CATALOG_RESOURCE_PATH);
    }
}
