using UnityEngine;
using Zenject;

public class ChestFactory
{
    private DiContainer _container;

    private MonoBehaviour _monoContext;

    public ChestFactory(DiContainer diContainer)
    {
        _container = diContainer;

        _monoContext = _container.Resolve<MonoBehaviour>();
    }

    public Chest CreateChest(ChestConfig config)
    {
        var chest = config.InstatiateChest(_monoContext);
        return chest;
    }
}