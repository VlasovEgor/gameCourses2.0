using UnityEngine;

public abstract class BoosterConfig:ScriptableObject
{
    [SerializeField] public string Id;

    [SerializeField] public float DurationSeconds;

    public abstract Booster InstatiateBooster(MonoBehaviour context);
}