using System;
using TMPro;
using UnityEngine;

public class ScrollStorageElement : MonoBehaviour
{
    public StorageComponent StorageComponent;

    public event Action<StorageComponent> OnStorageSelected;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _value;
    [SerializeField] private SelectButton _selectionButton;

    private void OnEnable()
    {
        _selectionButton.OnButtomClick += StorageSelected;
    }

    private void OnDisable()
    {
        _selectionButton.OnButtomClick -= StorageSelected;
    }
    
    private void StorageSelected()
    {
        OnStorageSelected?.Invoke(StorageComponent);
    }

    private void Start()
    {
        UpdateStats();
    }

    public void UpdateStats()
    {
        _nameText.text = StorageComponent.Type.ToString();
        _value.text = StorageComponent.Value.ToString();
    }
}
