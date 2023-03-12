using System;
using UnityEngine;

public class IngredientDeliverer : MonoBehaviour
{   
    public Action<Recipe> RequestIngredients;

    public Action OnStartWork;

}