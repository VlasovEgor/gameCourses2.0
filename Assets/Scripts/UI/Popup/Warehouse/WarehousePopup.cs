using System;
using TMPro;
using UnityEngine;

public class WarehousePopup : Popup
{
    [SerializeField] private TextMeshProUGUI _titleText;

    [SerializeField] private TextMeshProUGUI _amountIngredient;

    [SerializeField] private IngredientButton _increaseButton;
    [SerializeField] private IngredientButton _decreaseButton;
    [SerializeField] private IngredientButton _addButton;
    [SerializeField] private ScrollStoragesView _scrollView;


    private IWarehousePresentationModel _presenter;
    


    protected override void OnShow(object args)
    {
        if (args is not IWarehousePresentationModel presenter)
        {
            throw new Exception("Expected Presentation model!");
        }

        _presenter = presenter;
        _presenter.OnIncreaseButtonStateChanged += OnIncreaseuttonStateChanged;
        _presenter.OnDecreaseButtonStateChanged += OnDecreaseuttonStateChanged;
        _presenter.OnStatsChanged += UpdateStats;

        _increaseButton.AddListener(OnIncreaseButtonCliced);
        _decreaseButton.AddListener(OnDecreaseButtonCliced);
        _addButton.AddListener(OnAddButtonCliced);


        for (int i = 0; i < _scrollView.ScrollStorageElements.Count; i++)
        {
            _scrollView.ScrollStorageElements[i].OnStorageSelected += OnSelectButtonClicked;
        }

        OnSelectButtonClicked(_scrollView.ScrollStorageElements[0].StorageComponent);//костыль
    }


    private void UpdateStats()
    {
        _titleText.text = _presenter.GetTitle();
        _amountIngredient.text = _presenter.GetAmount();

        _increaseButton.SetAvailable(_presenter.CanIncrease());
        _decreaseButton.SetAvailable(_presenter.CanDecrease());
        _addButton.SetAvailable(_presenter.CanAdd());

        for (int i = 0; i < _scrollView.ScrollStorageElements.Count; i++)
        {
            _scrollView.ScrollStorageElements[i].UpdateStats();
        }
    }

    protected override void OnHide()
    {
        _increaseButton.RemoveListener(OnIncreaseButtonCliced);
        _decreaseButton.RemoveListener(OnDecreaseButtonCliced);
        _addButton.RemoveListener(OnAddButtonCliced);

        _presenter.OnIncreaseButtonStateChanged -= OnIncreaseuttonStateChanged;
        _presenter.OnDecreaseButtonStateChanged -= OnDecreaseuttonStateChanged;

        _presenter.OnStatsChanged -= UpdateStats;

        for (int i = 0; i < _scrollView.ScrollStorageElements.Count; i++)
        {
            _scrollView.ScrollStorageElements[i].OnStorageSelected -= OnSelectButtonClicked;
        }
    }

    private void OnIncreaseuttonStateChanged(bool isAvailabe)
    {
        _increaseButton.SetAvailable(isAvailabe);
    }

    private void OnDecreaseuttonStateChanged(bool isAvailabe)
    {
        _decreaseButton.SetAvailable(isAvailabe);
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

    private void OnSelectButtonClicked(StorageComponent component)
    {
        _presenter.OnButtonSelectionClicked(component);
    }
}