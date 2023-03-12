using UnityEngine;
using Zenject;

public class AttackController : MonoBehaviour, IStartGameListener, IFinishGameListener
{
    private IShotComponent _shotComponent;
    private ManipulatorsInput _manipulatorsInput;

    [Inject]
    public void Construct(ManipulatorsInput manipulatorsInput, CharacterService characterService)
    {
        _manipulatorsInput = manipulatorsInput;
        _shotComponent = characterService.GetCharacter().Get<IShotComponent>();
    }
    public void OnStartGame()
    {
        _manipulatorsInput.OnShoot += Shot;
    }

    public void OnFinishGame()
    {
        _manipulatorsInput.OnShoot += Shot;
    }

    private void Shot()
    {
        _shotComponent.Shoot();
    }
}
