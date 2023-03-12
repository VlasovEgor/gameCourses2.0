using UnityEngine;
using Zenject;

public class MoveController : MonoBehaviour, IStartGameListener, IFinishGameListener
{
    private IMovingComponent _movingComponent;
    private ManipulatorsInput _manipulatorsInput;

    [Inject]
    public void Construct(ManipulatorsInput manipulatorsInput, CharacterService characterService)
    {
        _manipulatorsInput = manipulatorsInput;
        _movingComponent = characterService.GetCharacter().Get<IMovingComponent>();
    }

    public void OnStartGame()
    {
        _manipulatorsInput.OnMove += Move;
    }

    public void OnFinishGame()
    {
        _manipulatorsInput.OnMove += Move;
    }

    public void Move(Vector3 inputVector)
    {
        _movingComponent.Movement(inputVector);
    }
}
