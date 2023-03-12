using System;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public Action OnButtomClick;

    public void OnClick()
    {
        OnButtomClick?.Invoke();
    }
}
