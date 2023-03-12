using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRecipeElement : MonoBehaviour
{
    public Recipe Recipe;

    public event Action<Recipe> OnRecipeSelected;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Image _image;
    [SerializeField] private SelectButton _selectionButton;

    private void OnEnable()
    {
        _selectionButton.OnButtomClick += StorageSelected;
    }

    private void OnDisable()
    {
        _selectionButton.OnButtomClick -= StorageSelected;
    }

    private void StorageSelected()
    {
        OnRecipeSelected?.Invoke(Recipe);
    }

    private void Start()
    {
        _nameText.text = Recipe.RecipeType.ToString();
        _image.sprite = Recipe.IconImage;
    }
}
