using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public sealed class ProductPopup : Popup
{
    [SerializeField] private TextMeshProUGUI _titleText;

    [SerializeField] private TextMeshProUGUI _descriptionText;

    [SerializeField] private Image _iconImage;

    [SerializeField] private BuyButton _buyButton;

    private IProductPresentationModel _presenter;

    protected override void OnShow(object args)
    {
        if (args is not IProductPresentationModel presenter)
        {
            throw new Exception("Expected Presentation model!");
        }

        _presenter = presenter;
        _presenter.OnBuyButtonStateChanged += OnBuyButtonStateChanged;
        _presenter.Start();

        _titleText.text = presenter.GetTitle();
        _descriptionText.text = presenter.GetDescription();
        _iconImage.sprite = presenter.GetIcon();

        _buyButton.SetPrice(presenter.GetPrice());
        _buyButton.SetAvailable(presenter.CanBuy());
        _buyButton.AddListener(OnBuyButtonClicked);
    }

    protected override void OnHide()
    {
        _buyButton.RemoveListener(OnBuyButtonClicked);
        _presenter.OnBuyButtonStateChanged -= OnBuyButtonStateChanged;
        _presenter.Stop();
    }

    private void OnBuyButtonStateChanged(bool isAvailabe)
    {
        _buyButton.SetAvailable(isAvailabe);
    }

    private void OnBuyButtonClicked()
    {
        _presenter.OnBuyClicked();
    }

}