using UnityEngine;

public class SetLevelComponent : MonoBehaviour,ISetLevelComponent
{
    [SerializeField] private IntBehaviour _level;

    public void SetLevel(int level)
    {
        _level.Value = level;   
    }
}
