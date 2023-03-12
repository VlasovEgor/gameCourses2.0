using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorZoneVisual : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _items;

    private int currentAmount;

    public void SetupItems(int currentAmount)
    {
        this.currentAmount = Mathf.Min(currentAmount, _items.Count);

        for (var i = 0; i < currentAmount; i++)
        {
            var item = _items[i];
            item.SetActive(true);
        }

        var count = _items.Count;
        for (var i = currentAmount; i < count; i++)
        {
            var item = _items[i];
            item.SetActive(false);
        }
    }

    public void IncrementItems(int range)
    {
        var previousAmount = currentAmount;
        var newAmount = Mathf.Min(currentAmount + range, _items.Count);
        currentAmount = newAmount;

        for (var i = previousAmount; i < newAmount; i++)
        {
            var item = _items[i];
            item.SetActive(true);
        }
    }

    public void DecrementItems(int range)
    {
        var previousAmount = currentAmount;
        var newAmount = Mathf.Max(currentAmount - range, 0);
        currentAmount = newAmount;

        for (var i = previousAmount - 1; i >= newAmount; i--)
        {
            var item = _items[i];
            item.SetActive(false);
        }
    }

#if UNITY_EDITOR
    [Button("Setup Items")]
    private void Editor_SetupItems()
    {
        _items = new List<GameObject>();
        foreach (Transform child in transform)
        {
            _items.Add(child.gameObject);
        }
    }
#endif

}
