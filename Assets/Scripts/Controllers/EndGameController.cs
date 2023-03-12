using UnityEngine;
using Zenject;

public class EndGameController : MonoBehaviour, IStartGameListener, IFinishGameListener
{
    private IGameContext _context;
    private ITriggerComponent _playerComponent;

    [Inject]
    public void Construct(IGameContext gameContext,CharacterService characterService)
    {
        _context = gameContext;
        _playerComponent = characterService.GetCharacter().Get<ITriggerComponent>();
    }

    public void OnStartGame()
    {
        _playerComponent.OnTriggerEntered += OnTriggerEntered;
    }

    public void OnFinishGame()
    {
        _playerComponent.OnTriggerEntered -= OnTriggerEntered;
    }

    private void OnTriggerEntered(Collider obj)
    {
        if (obj.CompareTag("Finish"))
        {
            _context.FinishGame();
        }
    }
}