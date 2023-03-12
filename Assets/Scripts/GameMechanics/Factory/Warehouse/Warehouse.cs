using System;
using UnityEngine;
using System.Collections.Generic;

public class Warehouse : MonoBehaviour
{
    [SerializeField] private MechanicsResourceReduction _resourceReduction;

    private static int _numberIngredients = Enum.GetNames(typeof(Ingredients)).Length;
    private Dictionary<Ingredients, WarehouseCollector> _resocrcesDictionary = new Dictionary<Ingredients,WarehouseCollector>();


    private void Awake()
    {
        for (int i = 0; i < _numberIngredients; i++)
        {   
            var resourcesCollector = new WarehouseCollector
            {
               TypeIngredient = (Ingredients)i,
               AmountIngredient = 0,
            };

            _resocrcesDictionary.Add(resourcesCollector.TypeIngredient, resourcesCollector);
        }

    }

    public void AddingResources(Ingredients type, int amount)
    {
        var ingredient = _resocrcesDictionary[type];
        ingredient.AmountIngredient += amount;
        _resocrcesDictionary[type] = ingredient;
    }

    public bool EnoughIngredients(Recipe recipe)
    {
        foreach (WarehouseCollector currentIngredient in recipe.RecipeDictionary.Values)
        {
            if (_resocrcesDictionary.ContainsKey(currentIngredient.TypeIngredient) == false)
            {
                Debug.Log("ÒÀÊÈÕ ÈÍÃÐÈÄÓÅÒÎÂ Ó ÍÀÑ ÍÅÒ");
                return false;
            }
            if (_resocrcesDictionary[currentIngredient.TypeIngredient].AmountIngredient < currentIngredient.AmountIngredient)
            {
                Debug.Log("ÈÍÃÐÈÄÈÅÒÎÂ ÍÅ ÕÂÀÒÀÅÒ");
                return false;
            }
        }

        return true;
    }

    public void DeleteResources(Recipe recipe)
    {
        _resourceReduction.DeleteResources(recipe, _resocrcesDictionary);
    }
}