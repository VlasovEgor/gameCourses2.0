using UnityEngine;

public class InformationAboutWarehouse : MonoBehaviour, IInformationAboutWarehouse
{
    [SerializeField] private Warehouse _warehouse;
    [SerializeField] private IngredientDeliverer _ingredientDeliverer;

    private void OnEnable()
    {
        _ingredientDeliverer.RequestIngredients += CheckingIngredients;
    }

    private void OnDisable()
    {
        _ingredientDeliverer.RequestIngredients -= CheckingIngredients;
    }

    public void CheckingIngredients(Recipe recipe)
    {
        if(_warehouse.EnoughIngredients(recipe) == false)
        {
            Debug.Log("ÈÍÃĞÅÄÈÅÍÒÎÂ ÍÅÒ È ÒÎ×ÊÀ");
        }
        else
        {
            Debug.Log("ÈÍÃĞÅÄÈÅÍÒÛ ÅÑÒÜ È ÒÎ×ÊÀ");
            _warehouse.DeleteResources(recipe);

            _ingredientDeliverer.OnStartWork?.Invoke();
        }
    }
}