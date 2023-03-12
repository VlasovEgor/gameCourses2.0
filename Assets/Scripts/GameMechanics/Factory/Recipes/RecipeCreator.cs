using System;
using UnityEngine;

public class RecipeCreator : MonoBehaviour
{
    [SerializeField] private Recipe _recipeArmor;
    [SerializeField] private Recipe _recipeAxe;
    [SerializeField] private Recipe _recipeCrown;
    [SerializeField] private Recipe _recipeMagikStaff;

    private void Awake()
    {
        CreateArmorRecipe();
        CreateAxeRecipe();
        CreateCrownRecipe();
        CreateMagikStaffRecipe();
    }

    private void CreateArmorRecipe()
    {
        _recipeArmor.SettingQuantityIngredient(Ingredients.IRON, 3);
        _recipeArmor.SettingQuantityIngredient(Ingredients.WOOD, 1);
    }

    private void CreateAxeRecipe()
    {
        _recipeAxe.SettingQuantityIngredient(Ingredients.WOOD, 2);
        _recipeAxe.SettingQuantityIngredient(Ingredients.STONE, 3);
    }

    private void CreateCrownRecipe()
    {
        _recipeCrown.SettingQuantityIngredient(Ingredients.GOLD, 4);
        _recipeCrown.SettingQuantityIngredient(Ingredients.DIAMOND, 2);
    }

    private void CreateMagikStaffRecipe()
    {
        _recipeMagikStaff.SettingQuantityIngredient(Ingredients.WOOD, 2);
        _recipeMagikStaff.SettingQuantityIngredient(Ingredients.IRON, 4);
        _recipeMagikStaff.SettingQuantityIngredient(Ingredients.DIAMOND, 2);
    }

    
}
