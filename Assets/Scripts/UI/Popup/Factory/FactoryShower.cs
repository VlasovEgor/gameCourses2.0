using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class FactoryShower : MonoBehaviour
{
    private PopupManager _popupManager;
    private FactoryPresentationModelFactory _presenerFactory;

   // [Inject]
   // public void Construct(FactoryPresentationModelFactory factoryPresentationModelFactory, PopupManager popupManager)
   // {
   //     _presenerFactory = factoryPresentationModelFactory;
   //     _popupManager = popupManager;
   // }

    [Button]
    public void ShowWarehouse()
    {
        var presentationModel = _presenerFactory.CreatePresenter();
        _popupManager.ShowPopup(PopupName.FACTORY, presentationModel);
    }
}
