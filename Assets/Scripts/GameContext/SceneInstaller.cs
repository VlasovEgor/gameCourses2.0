using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private MonoBehaviour _monoBehaviour;

    public override void InstallBindings()
    {
        BindMonoBehaviour();
    }

    private void BindMonoBehaviour()
    {
        Container.Bind<MonoBehaviour>().
           FromInstance(_monoBehaviour).
           AsSingle();
    }
}