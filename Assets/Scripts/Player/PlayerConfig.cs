using UnityEngine;

public class PlayerConfig : MonoBehaviour
{
    [SerializeField] private Entity _entity;
    [SerializeField] private int _id;

    public int PlayerID
    {
        get { return _id; }
        set { _id = value; }
    }

    public Entity GetEntity()
    {
        return _entity;
    }
}
