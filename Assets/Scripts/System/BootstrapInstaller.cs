using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private RealtimeManager _realtimeManager;

    public override void InstallBindings()
    {
       // BindGameSceneContext();

        BindRealtimeManager();
        BindRealtimeRepository();
       // BindRealtimeSynchronizer();
      //  BindRealtimeSessionStarter();
        BindRealtimeSessionSaver();
        
        BindChestsData();
        BindChestsRepository();
       // BindChestsMediator();
       // BindChestsAssetSupplier();

    }

    private void BindGameSceneContext()
    {  
       // Container.Bind<SceneContext>().
       //     AsSingle().
       //     NonLazy();
    }


    private void BindRealtimeManager()
    {
        Container.Bind<RealtimeManager>().
            FromComponentInNewPrefab(_realtimeManager).
            AsSingle().
            NonLazy();
    }

    private void BindRealtimeRepository()
    {
        Container.Bind<RealtimeRepository>().
            AsSingle().
            NonLazy();
    }

    private void BindRealtimeSynchronizer()
    {
        Container.BindInterfacesAndSelfTo<RealtimeSynchronizer>().
            AsSingle().
            NonLazy();
    }

    private void BindRealtimeSessionStarter()
    {
        Container.BindInterfacesAndSelfTo<RealtimeSessionStarter>().
            AsSingle().
            NonLazy();
    }

    private void BindRealtimeSessionSaver()
    {
        Container.BindInterfacesAndSelfTo<RealtimeSessionSaver>().
            AsSingle().
            NonLazy();
    }

    private void BindChestsData()
    {
        Container.Bind<ChestsData>().
            AsSingle().
            NonLazy();
    }

    private void BindChestsRepository()
    {
        Container.Bind<ChestsRepository>().
            AsSingle().
            NonLazy();
    }

    private void BindChestsMediator()
    {
        Container.BindInterfacesAndSelfTo<ChestsMediator>().
            AsSingle().
            NonLazy();
    }

    private void BindChestsAssetSupplier()
    {
        Container.BindInterfacesAndSelfTo<ChestsAssetSupplier>().
          AsSingle().
          NonLazy();
    }
}
