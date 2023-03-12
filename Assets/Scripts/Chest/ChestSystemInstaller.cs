using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ChestSystemInstaller : MonoInstaller
{
    [SerializeField] private ChestCatalog _chestCatalog;

    [ShowInInspector]
    private ChestManager _manager;

    private Chest.Factory _chestFactory;

    public override void InstallBindings()
    {
        BindChestFactory();
        BindChestManager();
        BindChestsMediator(); 
        BindChestsCatalog();
        BindChestsAssetSupplier();
    }

    private void BindChestFactory()
    {
        Container.BindFactory<ChestConfig, Chest, Chest.Factory>();
        _chestFactory = Container.Resolve<Chest.Factory>();
    }

    private void BindChestManager()
    {
        _manager = Container.Instantiate<ChestManager>();

         Container.BindInterfacesAndSelfTo<ChestManager>().
            FromInstance(_manager).
            AsSingle().
            NonLazy();
    }

    private void BindChestsMediator()
    {
        Container.BindInterfacesAndSelfTo<ChestsMediator>().
            AsSingle().
            NonLazy();
    }

    private void BindChestsCatalog()
    {
        Container.Bind<ChestCatalog>().
            FromInstance(_chestCatalog).
            AsSingle().
            NonLazy();
    }

    private void BindChestsAssetSupplier()
    {
        Container.BindInterfacesAndSelfTo<ChestsAssetSupplier>().
          AsSingle().
          NonLazy();
    }

    public List<Chest> CreateChests()
    {
        var chestConfigs = _chestCatalog.GetAllChests();
        var chestList = new List<Chest>();

        for (int i = 0; i < chestConfigs.Length; i++)
        {
            var chest = _chestFactory.Create(chestConfigs[i]);
            chestList.Add(chest);
        }

        return chestList;
    }

    [Button]
    public void SetupChest()
    {
        _manager.Setup(CreateChests());
    }

    [Button]
    public void OpenChest(string chestId)
    {
        _manager.OpenChest(chestId);
    }
}