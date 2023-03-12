using Elementary;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class UnloadZoneVisual : MonoBehaviour
{
    public int CurrentAmount;

    [SerializeField] public List<GameObject> Items;
    [SerializeField] private LimitedIntBehavior _outputStorage;

    private void Awake()
    {
        SetupItems(_outputStorage.Value);
    }

    public void SetupItems(int currentAmount)
    {
        CurrentAmount = Mathf.Min(currentAmount, Items.Count);

        for (int i = 0; i < currentAmount; i++)
        {
            var item = Items[i];
            item.SetActive(true);
        }

        int count = Items.Count;
        for (int i = currentAmount; i < count; i++)
        {
            var item = Items[i];
            item.SetActive(false);
        }
    }

#if UNITY_EDITOR
    [Button("Setup Items")]
    private void Editor_SetupItems()
    {
        Items = new List<GameObject>();
        foreach (Transform child in transform)
        {
            Items.Add(child.gameObject);
        }
    }
#endif

}