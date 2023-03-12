using System.Collections.Generic;
using UnityEngine;

public class SrollRecipesView : MonoBehaviour
{
    [SerializeField] private GameObject _scrollElementPrefab;
    [SerializeField] private ConveyorRecipes _recipes;

    private List<ScrollRecipeElement> _scrollRecipeElements = new List<ScrollRecipeElement>();

    public List<ScrollRecipeElement> ScrollRecipeElements
    {
        get
        {
            return _scrollRecipeElements;
        }
    }

    private void Awake()
    {
        for (int i = 0; i < _recipes._Recipes.Length; i++)
        {
            var view = Instantiate(_scrollElementPrefab);
            view.transform.SetParent(transform, false);

            var variables = view.GetComponent<ScrollRecipeElement>();

            variables.Recipe = _recipes._Recipes[i];
            _scrollRecipeElements.Add(variables);
        }
    }
}
