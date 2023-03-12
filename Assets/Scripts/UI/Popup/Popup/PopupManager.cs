using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour, Popup.ICallback
{ 
   [SerializeField] private PopupHolder[] allPopups;

    private readonly Dictionary<PopupName, Popup> _activePopups = new();

    private void Awake()
    {
        foreach (var popupHolder in allPopups)
        {
            popupHolder.popup.gameObject.SetActive(false);
        }
    }

    [Button]
    public void ShowPopup(PopupName name, object args=null)
    {
        if (IsPopupActive(name)==true)
        {
            return;
        }

        var popup = FindPopup(name);
        popup.gameObject.SetActive(true);
        popup.Show(args: args, callback: this);
        _activePopups.Add(name, popup);
    }

    [Button]
    public void HidePopup(PopupName name)
    {
        if (IsPopupActive(name)==false)
        {
            return;
        }

        var popup = _activePopups[name];
        popup.Hide();
        popup.gameObject.SetActive(false);
        _activePopups.Remove(name);
    }

    [Button]
    public bool IsPopupActive(PopupName name)
    {
        return _activePopups.ContainsKey(name);
    }

    void Popup.ICallback.OnClose(Popup popup)
    {
        var name = FindName(popup);
        HidePopup(name);
    }

    private PopupName FindName(Popup popup)
    {
        foreach (var holder in allPopups)
        {
            if (ReferenceEquals(holder.popup, popup))
            {
                return holder.name;
            }
        }

        throw new Exception($"Name of popup {popup.name} is not found!");
    }

    private Popup FindPopup(PopupName name)
    {
        foreach (var holder in allPopups)
        {
            if (holder.name == name)
            {
                return holder.popup;
            }
        }

        throw new Exception($"Popup with name {name} is not found!");
    }

    [Serializable]
    private struct PopupHolder
    {
        [SerializeField]
        public PopupName name;

        [SerializeField]
        public Popup popup;
    }
}
