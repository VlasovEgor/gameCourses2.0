using System;
using UnityEngine;

public class FactoryPresentationModel : IFactoryPresentationModel
{
    public event Action<bool> OnCreateButtonStateChanged;
    public event Action OnStatsChanged;

    private Recipe _recipe;
    private ObjectCreator _objectCreator;
    private IConveyorComponent _conveyorComponent;
    private IWorkComponent _workComponent;
    private ProgressBar _progressBar;

    public FactoryPresentationModel(ObjectCreator objectCreator,  IConveyorComponent conveyorComponent, IWorkComponent workComponent)
    {
        _objectCreator = objectCreator;
        _conveyorComponent = conveyorComponent;
        _workComponent= workComponent;
    }

    public Sprite GetIcon()
    {
        return _recipe.IconImage;
    }

    public string GetTitle()
    {
        return _recipe.RecipeType.ToString();
    }

    public void OnButtonSelectionClicked(Recipe recipe)
    {
        _recipe = recipe;
        OnStatsChanged?.Invoke();
    }

    public void OnCreateClicked()
    {
        _objectCreator.Create(_recipe, _conveyorComponent);
    }


    public void SetProgress(ProgressBar progressBar)
    {
        _progressBar = progressBar;
        _workComponent.OnProgress += ChangingLengthProgressBar;
    }

    private void ChangingLengthProgressBar(float progress)
    {
        _progressBar.SetProgress(progress);
    }

}