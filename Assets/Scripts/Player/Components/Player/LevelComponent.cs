using UnityEngine;

public class LevelComponent : MonoBehaviour,ILevelComponent
{
    [SerializeField] private IntBehaviour _levelBehavior;

    public int Value()
    {
        return _levelBehavior.Value;
    }

   
}
