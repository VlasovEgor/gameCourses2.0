using UnityEngine;
using Zenject;

public class JumpController : MonoBehaviour, IStartGameListener, IFinishGameListener
{
    private IJumpComponent _jumpComponent;
    private ManipulatorsInput _manipulatorsInput;

    [Inject]
    public void Construct(ManipulatorsInput manipulatorsInput, CharacterService characterService)
    {
        _manipulatorsInput = manipulatorsInput;
        _jumpComponent = characterService.GetCharacter().Get<IJumpComponent>();
    }

    public void OnStartGame()
    {
        _manipulatorsInput.OnJump += Jump;
    }

    public void OnFinishGame()
    {
        _manipulatorsInput.OnJump -= Jump;
    }

    private void Jump()
    {
        _jumpComponent.Jump();
    }
}
