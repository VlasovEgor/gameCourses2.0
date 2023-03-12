using UnityEngine;
using Zenject;

public class MenuPlatform : MonoBehaviour
{
    [SerializeField] private EventReceiver_Trigger _platformTrigger;
    [SerializeField] private StorageComponent _platformComponent;

    private IngredientShower _ingredientShower;

    private void OnEnable()
    {
        _platformTrigger.OnTriggerEntered += OnTriggerEntered;
    }

    private void OnDisable()
    {
        _platformTrigger.OnTriggerEntered -= OnTriggerEntered;
    }

    [Inject]
    public void Construct(IngredientShower ingredientShower)
    {
        _ingredientShower = ingredientShower;
    }

    private void OnTriggerEntered(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            _ingredientShower.ShowStorage(_platformComponent);
        }
    }

}