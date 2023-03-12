using UnityEngine;

public class IngredientPresentationModelFactory : MonoBehaviour, IConstructListener
{
    private IngredientAdder _ingredientAdder;

    public void Construct(GameContext context)
    {
        //_ingredientAdder = context.GetService<IngredientAdder>();
    }

    public IngredientPresentationModel CreatePresenter(StorageComponent storage)
    {
        return new IngredientPresentationModel(storage, _ingredientAdder);
    }
}
