using Elementary;
using UnityEngine;

public class ConveyorZoneVisualAdapter : MonoBehaviour
{
    [SerializeField] private ConveyorZoneVisual _view;

    [SerializeField] private LimitedIntBehavior _inputStorage;

    private void OnEnable()
    {
        _view.SetupItems(_inputStorage.Value);
        _inputStorage.OnValueChanged += _view.SetupItems;
    }

    private void OnDisable()
    {
        _inputStorage.OnValueChanged -= _view.SetupItems;
    }

    private void OnValidate()
    {
        if (_view != null && _inputStorage != null)
        {
            _inputStorage.OnValueChanged -= _view.SetupItems;
            _inputStorage.OnValueChanged += _view.SetupItems;
        }
    }
}
