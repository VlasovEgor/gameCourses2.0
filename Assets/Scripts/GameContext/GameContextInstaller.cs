using UnityEngine;
using Zenject;

public class GameContextInstaller : MonoInstaller
{
    [SerializeField] private MonoBehaviour[] _listeners;

    [SerializeField] private GameContext _gameContext;
    [SerializeField] private MoneyStorage _moneyStorage;
    [SerializeField] private ManipulatorsInput _manipulatorsInput;
    [SerializeField] private CharacterService _characterService;
    [SerializeField] private CameraService _cameraService;


    private void Awake()
    {
        foreach (var listener in _listeners)
        {
            _gameContext.AddListener(listener);
        }
    }

    public override void InstallBindings()
    {
        BindGameContext();
        BindMoneyStorage();
        BindManipulatorsInput();
        BindCharacterService();
        BindCameraService();
    }

    private void BindGameContext()
    {
        Container.Bind<IGameContext>().
            To<GameContext>().
            FromInstance(_gameContext).
            AsSingle();
    }

    private void BindMoneyStorage()
    {
        Container.Bind<MoneyStorage>().
            FromInstance(_moneyStorage).
            AsSingle();
    }

    private void BindManipulatorsInput()
    {
        Container.Bind<ManipulatorsInput>().
            FromInstance(_manipulatorsInput).
            AsSingle();
    }

    private void BindCharacterService()
    {
        Container.Bind<CharacterService>().
            FromInstance(_characterService).
            AsSingle();
    }

    private void BindCameraService()
    {
        Container.Bind<CameraService>().
            FromInstance(_cameraService).
            AsSingle();
    }

}
