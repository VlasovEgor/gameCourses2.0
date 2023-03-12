using System;

public interface IIngredientPresentationModel
{
    event Action<bool> OnIncreaseButtonStateChanged;
    event Action<bool> OnDecreaseButtonStateChanged;
    event Action<bool> OnAddButtonStateChanged;

    event Action OnStatsChanged;

    string GetTitle();

    string GetAmount();

    bool CanIncrease();

    bool CanDecrease();

    bool CanAdd();

    void OnIncreaseClicked();

    void OnDecreaseClicked();

    void OnAddClicked();
}
