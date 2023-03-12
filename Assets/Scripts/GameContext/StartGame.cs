using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private TimerBehaviour _timerGameStart;
    [SerializeField] private GameContext _context;

    private void OnEnable()
    {
        _timerGameStart.OnEnded += GameStarted;
    }

    private void OnDisable()
    {
        _timerGameStart.OnEnded -= GameStarted;
    }

    private void Start()
    {
        _context.ConstructGame();
        _context.InitializationGame();
        _timerGameStart.Play(); 
    }

    private void GameStarted()
    {
        _context.StartGame();
    }
}
