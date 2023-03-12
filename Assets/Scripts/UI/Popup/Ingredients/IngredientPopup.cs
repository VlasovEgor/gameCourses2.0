using System;
using TMPro;
using UnityEngine;

public class IngredientPopup : Popup
{
    [SerializeField] private TextMeshProUGUI _titleText;

    [SerializeField] private TextMeshProUGUI _amountIngredient;

    [SerializeField] private IngredientButton _increaseButton;
    [SerializeField] private IngredientButton _decreaseButton;
    [SerializeField] private IngredientButton _addButton;

    private IIngredientPresentationModel _presenter;

    protected override void OnShow(object args)
    {
        if (args is not IIngredientPresentationModel presenter)
        {
            throw new Exception("Expected Presentation model!");
        }

        _presenter = presenter;
        _presenter.OnIncreaseButtonStateChanged += OnIncreaseuttonStateChanged;
        _presenter.OnDecreaseButtonStateChanged += OnDecreaseuttonStateChanged;
        _presenter.OnAddButtonStateChanged += OnAddButtonStateChanged;
        _presenter.OnStatsChanged += UpdateStats;

        UpdateStats();

        _increaseButton.AddListener(OnIncreaseButtonCliced);
        _decreaseButton.AddListener(OnDecreaseButtonCliced);
        _addButton.AddListener(OnAddButtonCliced);
    }

    private void UpdateStats()
    {
        _titleText.text = _presenter.GetTitle();
        _amountIngredient.text = _presenter.GetAmount();

        _increaseButton.SetAvailable(_presenter.CanIncrease());
        _decreaseButton.SetAvailable(_presenter.CanDecrease());
        _addButton.SetAvailable(_presenter.CanAdd());
    }

    protected override void OnHide()
    {
        _increaseButton.RemoveListener(OnIncreaseButtonCliced);
        _decreaseButton.RemoveListener(OnDecreaseButtonCliced);
        _addButton.RemoveListener(OnAddButtonCliced);

        _presenter.OnIncreaseButtonStateChanged -= OnIncreaseuttonStateChanged;
        _presenter.OnDecreaseButtonStateChanged -= OnDecreaseuttonStateChanged;
        _presenter.OnAddButtonStateChanged -= OnAddButtonStateChanged;

        _presenter.OnStatsChanged -= UpdateStats;
    }

    private void OnIncreaseuttonStateChanged(bool isAvailabe)
    {
        _increaseButton.SetAvailable(isAvailabe);
    }

    private void OnDecreaseuttonStateChanged(bool isAvailabe)
    {
        _decreaseButton.SetAvailable(isAvailabe);
    }

    private void OnAddButtonStateChanged(bool isAvailabe)
    {
        _addButton.SetAvailable(isAvailabe);
    }

    private void OnIncreaseButtonCliced()
    {
        _presenter.OnIncreaseClicked();
    }

    private void OnDecreaseButtonCliced()
    {
        _presenter.OnDecreaseClicked();
    }

    private void OnAddButtonCliced()
    {
        _presenter.OnAddClicked();
    }
}
