
public interface IGameContext
{
    public void AddListener(object listener);

    public void RemoveListener(object listener);

    public void ConstructGame();

    public void InitializationGame();

    public void StartGame();

    public void FinishGame();
}