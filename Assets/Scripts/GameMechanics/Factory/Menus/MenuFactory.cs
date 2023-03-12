using UnityEngine;
using Zenject;

public class MenuFactory : MonoBehaviour
{
    [SerializeField] private EventReceiver_Trigger _platformTrigger;

    private FactoryShower _factoryShower;

    private void OnEnable()
    {
        _platformTrigger.OnTriggerEntered += OnTriggerEntered;
    }

    private void OnDisable()
    {
        _platformTrigger.OnTriggerEntered -= OnTriggerEntered;
    }

    [Inject]
    public void Construct(FactoryShower factoryShower)
    {
        _factoryShower = factoryShower;
    }

    private void OnTriggerEntered(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            _factoryShower.ShowWarehouse();

        }
    }
}
