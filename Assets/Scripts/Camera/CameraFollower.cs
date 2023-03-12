using UnityEngine;
using Zenject;

public class CameraFollower : MonoBehaviour, IStartGameListener, IFinishGameListener
{
    private Transform _targetCamera;
    private IGetPositionComponent _PositionComponent;

    private void Awake()
    {
        enabled = false;
    }

    private void LateUpdate()
    {
        _targetCamera.position = _PositionComponent.GetPosition();
    }

    [Inject]
    public void Construct(CameraService cameraService, CharacterService characterService)
    {
        _targetCamera = cameraService.CameraTransfrom;
        _PositionComponent = characterService.GetCharacter().Get<IGetPositionComponent>();
    }

    public void OnStartGame()
    {
        enabled = true;
    }

    public void OnFinishGame()
    {
        enabled = false;
    }
}
