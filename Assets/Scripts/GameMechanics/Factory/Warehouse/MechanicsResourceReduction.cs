using System.Collections.Generic;
using UnityEngine;

public class MechanicsResourceReduction : MonoBehaviour
{
    [SerializeField] private Warehouse _warehouse;

    public void DeleteResources(Recipe recipe, Dictionary<Ingredients, WarehouseCollector> resourcesDictionary)
    {
        foreach (WarehouseCollector currentIngredient in recipe.RecipeDictionary.Values)
        {
            var amountIngredient = resourcesDictionary[currentIngredient.TypeIngredient];
            amountIngredient.AmountIngredient -= currentIngredient.AmountIngredient;
            resourcesDictionary[currentIngredient.TypeIngredient] = amountIngredient;
        }
    }
}
