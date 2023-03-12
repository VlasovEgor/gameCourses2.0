using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FactoryPopup : Popup
{
    [SerializeField] private TextMeshProUGUI _titleText;

    [SerializeField] private IngredientButton _createButton;
    [SerializeField] private Image _iconImage;
    [SerializeField] private SrollRecipesView _scrollView;
    [SerializeField] private ProgressBar _progressBar;

    private IFactoryPresentationModel _presenter;

    protected override void OnShow(object args)
    {
        if (args is not IFactoryPresentationModel presenter)
        {
            throw new Exception("Expected Presentation model!");
        }

        _presenter = presenter;
        _presenter.OnStatsChanged += UpdateStats;
        SetProgress();

        _createButton.AddListener(OnCreateButtonCliced);
        for (int i = 0; i < _scrollView.ScrollRecipeElements.Count; i++)
        {
            _scrollView.ScrollRecipeElements[i].OnRecipeSelected += OnSelectButtonClicked;
        }

       OnSelectButtonClicked(_scrollView.ScrollRecipeElements[0].Recipe);//костыль
    }


    private void UpdateStats()
    {
        _titleText.text = _presenter.GetTitle();
        _iconImage.sprite = _presenter.GetIcon();
    }

    protected override void OnHide()
    {
        _presenter.OnStatsChanged -= UpdateStats;

        _createButton.RemoveListener(OnCreateButtonCliced);

        for (int i = 0; i < _scrollView.ScrollRecipeElements.Count; i++)
        {
            _scrollView.ScrollRecipeElements[i].OnRecipeSelected -= OnSelectButtonClicked;
        }
    }

    private void OnCreateButtonCliced()
    {
        _presenter.OnCreateClicked();
    }

    private void OnSelectButtonClicked(Recipe recipe)
    {
        _presenter.OnButtonSelectionClicked(recipe);
    }

    private void SetProgress()
    {
        _presenter.SetProgress(_progressBar);
    }
}