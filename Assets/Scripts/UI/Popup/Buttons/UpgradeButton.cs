using System;
using TMPro;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    [Space]
    [SerializeField] private Image _buttonBackground;

    [SerializeField] private Sprite _availableButtonSprite;

    [SerializeField] private Sprite _lockedButtonSprite;

    [SerializeField] private Sprite _maxButtonSprite;

    [Space]
    [SerializeField] private TextMeshProUGUI _priceText;

    [Space]
    [SerializeField] private GameObject _maxTextGO;

    [SerializeField] private GameObject _titleTextGO;

    [SerializeField] private GameObject _priceContainer;

    [Space]
    [SerializeField] private State _state;

    public void AddListener(UnityAction action)
    {
        _button.onClick.AddListener(action);
    }

    public void RemoveListener(UnityAction action)
    {
        _button.onClick.RemoveListener(action);
    }

    public void SetPrice(string price)
    {
        _priceText.text = price;
    }

    public void SetState(State state)
    {
        _state = state;

        if (state == State.AVAILABLE)
        {
            _button.interactable = true;
            _buttonBackground.sprite = _availableButtonSprite;

            _priceContainer.SetActive(true);
            _titleTextGO.SetActive(true);
            _maxTextGO.SetActive(false);
        }
        else if (state == State.LOCKED)
        {
            _button.interactable = false;
            _buttonBackground.sprite = _lockedButtonSprite;

            _priceContainer.SetActive(true);
            _titleTextGO.SetActive(true);
            _maxTextGO.SetActive(false);
        }
        else if (state == State.MAX)
        {
            _button.interactable = false;
            _buttonBackground.sprite = _maxButtonSprite;

            _priceContainer.SetActive(false);
            _titleTextGO.SetActive(false);
            _maxTextGO.SetActive(true);
        }
        else
        {
            throw new Exception($"Undefined button state {state}!");
        }
    }

    public enum State
    {
        AVAILABLE,
        LOCKED,
        MAX
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        try
        {
            SetState(_state);
        }
        catch (Exception)
        {
            // ignored
        }
    }
#endif
}
