using System;
using Zenject;

public class ChestsMediator: IInitializable, IDisposable
{
  // [Inject] private SceneContext _gameSceneContext;

    [Inject] private ChestsRepository _chestsRepository;
    [Inject] private ChestManager _manager;
    [Inject] private ChestsAssetSupplier _assetSupplier;

    void IInitializable.Initialize()
    {   
      //  _manager = _gameSceneContext.Container.Resolve<ChestManager>();
      //  _chestsRepository = _gameSceneContext.Container.Resolve<ChestsRepository>();
      //  _assetSupplier = _gameSceneContext.Container.Resolve<ChestsAssetSupplier>();
      
        if (_chestsRepository.LoadChests(out var boostersData))
        {
            LoadData(boostersData);
            return;
        }
    }

    void IDisposable.Dispose()
    {
        SaveData();
    }


    public void LoadData(ChestsData[] chestsData)
    {
        for (int i = 0, count = chestsData.Length; i < count; i++)
        {
            var data = chestsData[i];
            var config = _assetSupplier.GetChest(data.Id);
            var chest = _manager.LoadChest(config);
            chest.RemainingSeconds = data.RemainingTime;
        }
    }

    public void SaveData()
    {
        var chests = _manager.GetAllChests();
        var count = chests.Count;
        var chestsData = new ChestsData[count];

        for (var i = 0; i < count; i++)
        {
            var chest = chests[i];
            var data = new ChestsData
            {
                Id = chest.Id,
                RemainingTime = chest.RemainingSeconds
            };

            chestsData[i] = data;
        }

        _chestsRepository.SaveChests(chestsData);
    }
}