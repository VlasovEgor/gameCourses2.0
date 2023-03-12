using Sirenix.OdinInspector;
using UnityEngine;

public class WarehouseShower : MonoBehaviour, IConstructListener
{
    private PopupManager _popupManager;
    private WarehousePresentationModelFactory _presenerFactory;

    public void Construct(GameContext context)
    {
       // _presenerFactory = context.GetService<WarehousePresentationModelFactory>();
       // _popupManager = context.GetService<PopupManager>();
    }

    [Button]
    public void ShowWarehouse()
    {
        var presentationModel = _presenerFactory.CreatePresenter();
        _popupManager.ShowPopup(PopupName.WAREHOUSE, presentationModel);
    }
}
