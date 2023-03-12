using UnityEngine;
using Zenject;

public class TimeSystemInstaller : MonoInstaller
{
    [SerializeField] private TimeShiftEmitter _timeShiftEmitter;

    public override void InstallBindings()
    {
        BindRealtimeRepository();
        BindTimeShiftEmitter();
        BindRealtimeSynchronizer();
        BindRealtimeSessionStarter();
    }

    private void BindRealtimeRepository()
    {
        Container.Bind<RealtimeRepository>().
            AsSingle();
    }

    private void BindTimeShiftEmitter()
    {
        Container.Bind<TimeShiftEmitter>().
            FromInstance(_timeShiftEmitter).    
           AsSingle();
    }

    private void BindRealtimeSynchronizer()
    {
        Container.BindInterfacesAndSelfTo<RealtimeSynchronizer>().
            AsSingle().
            NonLazy();
    }

    private void BindRealtimeSessionStarter()
    {
        Container.Bind<RealtimeSessionStarter>().
            AsSingle();
    }
}
