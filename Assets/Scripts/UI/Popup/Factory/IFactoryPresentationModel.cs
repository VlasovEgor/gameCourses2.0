using System;
using UnityEngine;

public interface IFactoryPresentationModel
{
    event Action<bool> OnCreateButtonStateChanged;

    event Action OnStatsChanged;

    Sprite GetIcon();

    string GetTitle();

    void OnCreateClicked();

    void OnButtonSelectionClicked(Recipe recipe);

    void SetProgress(ProgressBar progressBar);
}
