using System.Collections.Generic;
using UnityEngine;

public class ScrollStoragesView : MonoBehaviour
{
    [SerializeField] private GameObject _scrollElementPrefab;
    [SerializeField] private Storages _storages;

    private List<ScrollStorageElement> _scrollStorageElements= new List<ScrollStorageElement>();

    public List<ScrollStorageElement> ScrollStorageElements
    {
        get 
        { 
            return _scrollStorageElements; 
        }
    }

    private void Awake()
    {   

        for (int i = 0; i < _storages.StorageComponents.Length; i++)
        {
            var view = Instantiate(_scrollElementPrefab);
            view.transform.SetParent(transform, false);

            var variables = view.GetComponent<ScrollStorageElement>();

            variables.StorageComponent = _storages.StorageComponents[i];
            _scrollStorageElements.Add(variables);
        }
    }
}
