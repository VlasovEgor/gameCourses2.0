

public interface IEntity
{
    public T Get<T>();

    public bool TryGet<T>(out T result);


}
