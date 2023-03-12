using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Recipe", menuName = "Gameplay/ Recipe")]
public class Recipe : ScriptableObject
{
    public Recipes RecipeType;
    public Dictionary<Ingredients, WarehouseCollector> RecipeDictionary = new Dictionary<Ingredients, WarehouseCollector>();

    [Space]
    [SerializeField] private Material _productMaterial;
    [SerializeField] private Sprite _iconImage;
    [SerializeField] private float _productionTime;

    public Material GetMaterial()
    {
        return _productMaterial;
    }

    public float ProductionTime()
    {
        return _productionTime;
    }

    public Sprite IconImage
    {
        get
        {
            return _iconImage;
        }
    }

    [Button]
    public void SettingQuantityIngredient(Ingredients type, int quantity)
    {
        if (RecipeDictionary.ContainsKey(type)==false)
        {
            var recipeCollector = new WarehouseCollector
            {
                TypeIngredient = type,
                AmountIngredient = quantity,
            };
            RecipeDictionary.Add(type, recipeCollector);
        }
        else
        {
            var amountIngredient = RecipeDictionary[type];
            amountIngredient.AmountIngredient = quantity;
            RecipeDictionary[type] = amountIngredient;
        }


        Debug.Log($"»Õ√–»ƒ»≈Õ“¿ {RecipeDictionary[type].TypeIngredient} ¬ –≈÷≈œ“≈ {RecipeDictionary[type].AmountIngredient}  ÿ“” ");
    }

    [Button]
    public void TryRemoveIngredient(Ingredients type)
    {
        if (RecipeDictionary.ContainsKey(type) == true)
        {
            Debug.Log($"»Õ√–»ƒ»≈Õ“ {RecipeDictionary[type].TypeIngredient} ”ƒ¿À®Õ");
            RecipeDictionary.Remove(type);    
        }
        else
        {
            Debug.Log("“¿ Œ√Œ »Õ√–»ƒ»≈Õ“¿ » Õ≈ ¡€ÀŒ");
        }
    }

    [Button]
    public void ShowIngredients()
    {
        foreach (WarehouseCollector currentIngredient in RecipeDictionary.Values)
        {
            Debug.Log($"ƒÀﬂ “≈ ”Ÿ≈√Œ –≈÷≈œ“¿ Õ”∆ÕŒ {currentIngredient.AmountIngredient} ÿ“”  {currentIngredient.TypeIngredient}");
        }
    }
}