using Sirenix.OdinInspector;
using UnityEngine;

public class IngredientShower : MonoBehaviour,IConstructListener
{
    private PopupManager _popupManager;
    private IngredientPresentationModelFactory _presenerFactory;

    public void Construct(GameContext context)
    {
        //_presenerFactory = context.GetService<IngredientPresentationModelFactory>();
        //_popupManager = context.GetService<PopupManager>();
    }

    [Button]
    public void ShowStorage(StorageComponent storage)
    {
        var presentationModel = _presenerFactory.CreatePresenter(storage);
        _popupManager.ShowPopup(PopupName.INGREDIENT, presentationModel);
    }
}
