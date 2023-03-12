using Elementary;
using UnityEngine;
using Sirenix.OdinInspector;

public class ConveyorMechanics : MonoBehaviour
{
    [SerializeField] private TimerBehaviour _workTimer;
    [SerializeField] private FloatBehaviour _workTimeMultiplication;
    [SerializeField] private LimitedIntBehavior _outputStorage;
    [SerializeField] private ConveyorRecipes _conveyorRecipes;
    [SerializeField] private IngredientDeliverer _ingredientDeliverer;
    [SerializeField] private UnloadZoneVisual _unloadZoneVisual;

    private Recipe _currentRecipe;

    private void OnEnable()
    {
        _workTimer.OnEnded += OnWorkFinished;
        _ingredientDeliverer.OnStartWork += StartWork;
    }

    private void OnDisable()
    {
        _workTimer.OnEnded -= OnWorkFinished;
        _ingredientDeliverer.OnStartWork -= StartWork;
    }

    [Button]
    public void TryStartWork(Recipe recipe)
    {
        if (_outputStorage.IsLimit || _workTimer.IsPlaying)
        {
            Debug.Log("conveyor is busy");
            return;
        }

        _currentRecipe = recipe;
        _ingredientDeliverer.RequestIngredients?.Invoke(recipe);
    }

    public void StartWork()
    {
        _workTimer.ResetTime();
        _workTimer.Duration = _currentRecipe.ProductionTime() / _workTimeMultiplication.Value;
        _workTimer.Play();
        
        Debug.Log("–¿¡Œ“¿ Õ¿◊¿“¿");
    }

    private void OnWorkFinished()
    {
        _unloadZoneVisual.Items[_unloadZoneVisual.CurrentAmount].GetComponent<MeshRenderer>().material = _currentRecipe.GetMaterial();
        _outputStorage.Value++;
        _unloadZoneVisual.SetupItems(_outputStorage.Value);
        Debug.Log("–¿¡Œ“¿ «¿ ŒÕ◊≈Õ¿");
    }
}