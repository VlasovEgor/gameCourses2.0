using UnityEngine;
using Zenject;

public class MenuWarehouse : MonoBehaviour
{

    [SerializeField] private EventReceiver_Trigger _platformTrigger;

    private WarehouseShower _warehouseShower;

    private void OnEnable()
    {
        _platformTrigger.OnTriggerEntered += OnTriggerEntered;
    }

    private void OnDisable()
    {
        _platformTrigger.OnTriggerEntered -= OnTriggerEntered;
    }

    [Inject]
    public void Construct(WarehouseShower warehouseShower)
    {
        _warehouseShower = warehouseShower;
    }

    private void OnTriggerEntered(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            _warehouseShower.ShowWarehouse();

        }
    }
}
